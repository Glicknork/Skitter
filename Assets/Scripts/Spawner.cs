using System;
using UnityEngine;
//------------------------------------------------------------------------
public class Spawner : MonoBehaviour
{
    //------------------------------------------------------------------------
    private float Block_Size = 2.0f;
    private Vector3 Default_Delta_Normal = new Vector3(-1f, 0f, 0f);
    private Vector3 Default_Delta_Scale = new Vector3(0.2f, 0f, 0f);
    private Vector3 Default_Delta_Speed = new Vector3(1f, 0f, 0f);
    public Vector3 Angle = new Vector3(90f, 0f, 0f);
    //------------------------------------------------------------------------
    public BlockArray Block_Pool;
    public GameObject Single_Block;
    public GameObject[] Sibling_Spawners;
    //------------------------------------------------------------------------
    public GameObject _Last_Spawned_Object;
    //------------------------------------------------------------------------
    public GameObject Floor;
    //------------------------------------------------------------------------
    public GameObject NewBlock(GameObject BlockType, Vector3 Delta_Normal, Vector3 Delta_Scale, Vector3 Delta_Speed, Vector3 Angle, Vector3 Position)
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
    public GameObject RandomBlock()
    {
        return NewBlock(
            Block_Pool == null ? Single_Block : Block_Pool[UnityEngine.Random.Range(0, Block_Pool.Count)],
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
        if (_Last_Spawned_Object == null) return;
        float Delta = transform.position.x - _Last_Spawned_Object.transform.position.x;
        if (Delta >= Block_Size)
        {
            _Last_Spawned_Object = NewBlock(
                Block_Pool == null ? Single_Block : Block_Pool[UnityEngine.Random.Range(0, Block_Pool.Count)],
                Default_Delta_Normal,
                Default_Delta_Scale,
                Default_Delta_Speed,
                Angle,
                new Vector3(_Last_Spawned_Object.transform.position.x + Block_Size, transform.position.y, transform.position.z)
             );
        }
    }
    //------------------------------------------------------------------------

    //------------------------------------------------------------------------
}
//------------------------------------------------------------------------
