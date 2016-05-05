using System;
using UnityEngine;
//------------------------------------------------------------------------
public class Spawner : BaseBlock
{
    //------------------------------------------------------------------------
    public float Block_Size = 2.0f;
    public Vector3 Default_Delta_Normal = new Vector3(-1f, 0f, 0f);
    public Vector3 Default_Delta_Scale = new Vector3(0.2f, 0f, 0f);
    public float Default_Delta_Speed = 1f;

    public Vector3 Angle = new Vector3(90f, 0f, 0f);
    public bool Is_Spawning = true;
    //------------------------------------------------------------------------
    public BlockArray Block_Pool;
    public GameObject Single_Block;
    public GameObject[] Sibling_Spawners;
    //------------------------------------------------------------------------
    public GameObject _Last_Spawned_Object;
    //------------------------------------------------------------------------
    public GameObject Floor;
    //------------------------------------------------------------------------
    public GameObject NewBlock(GameObject BlockType, Vector3 Delta_Normal, Vector3 Delta_Scale, float Delta_Speed, Vector3 Angle, Vector3 Position)
    {
        BaseBlock BaseBlock = BlockType.GetComponent<BaseBlock>() as BaseBlock;

        GameObject New = (GameObject)Instantiate(
                BlockType,
                new Vector3(Position.x + BaseBlock.Offset.x, Position.y + BaseBlock.Offset.y, Position.z + BaseBlock.Offset.z),
                Quaternion.Euler(Angle.x, Angle.y, Angle.z));
        BaseBlock NewBaseBlock = New.GetComponent<BaseBlock>() as BaseBlock;
        NewBaseBlock.Parent_Spawner_Set(this as Spawner);
        if (NewBaseBlock != null)
        {
            NewBaseBlock.Delta_Normal = Delta_Normal;
            NewBaseBlock.Delta_Scale = Delta_Scale;
            NewBaseBlock.Delta_Speed = Delta_Speed;
        }
        New.transform.parent = transform;
        return New;
    }
    //------------------------------------------------------------------------
    void Start()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(false);
        GameObject New = (GameObject)Instantiate(
                Single_Block,
                new Vector3(transform.position.x -35f, transform.position.y + (Angle.x > 0 ? Block_Size : -Block_Size ), transform.position.z),
                Quaternion.Euler(Angle.x, Angle.y, Angle.z));
        New.transform.localScale = new Vector3(4000f, 100f, 100f);
        New.transform.parent = this.transform;
        New.tag = "Floor";        
        /* 
        BoxCollider BoxCollider = New.GetComponent<BoxCollider>() as BoxCollider;
        BoxCollider.enabled = false;
        */
        BaseBlock NewBaseBlock = New.GetComponent<BaseBlock>() as BaseBlock;
        NewBaseBlock.Parent_Spawner_Set(this as Spawner);
        _Last_Spawned_Object = RandomBlock();
    }
    //------------------------------------------------------------------------
    // This is badly written and needs to be made better
    public GameObject RandomBlock()
    {
        float max = 0;

        foreach (GameObject GO in Block_Pool.Blocks) {
            BaseBlock GOBB = GO.GetComponent<BaseBlock>() as BaseBlock;
            max += GOBB.Spawn_Chance;
        }

        int index = -1;
        double r = UnityEngine.Random.Range(0, max);

        foreach (GameObject GO in Block_Pool.Blocks)
        {
            BaseBlock GOBB = GO.GetComponent<BaseBlock>() as BaseBlock;
            r -= GOBB.Spawn_Chance;
            if (GOBB.Spawn_Chance == 0) index++;
            index++;
            index = index % Block_Pool.Count;
            if (r <= 0)            
                break;            
        }
               
        return NewBlock(
            Block_Pool == null ? Single_Block : Block_Pool[index],
            Default_Delta_Normal,
            Default_Delta_Scale,
            Default_Delta_Speed,
            Angle,
            new Vector3(transform.position.x, transform.position.y, transform.position.z)
         );
    }
    //------------------------------------------------------------------------
    void Update()
    {
        if (!Is_Spawning) return;

        if (_Last_Spawned_Object == null)
        {
            _Last_Spawned_Object = RandomBlock();
        }
        else {
            float Delta = Vector3.Distance(transform.position, _Last_Spawned_Object.transform.position);
            if (Delta >= Block_Size)
            {
                _Last_Spawned_Object = RandomBlock();
            }
        }
    }
    //------------------------------------------------------------------------

    //------------------------------------------------------------------------
}
//------------------------------------------------------------------------
