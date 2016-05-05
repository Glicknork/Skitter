using UnityEngine;
using System.Collections;
using System;
//------------------------------------------------------------------------
public enum BlockType
{
    BLANK,
    FLOOR,
    BLOCK_PURPLE_BEZZEL,
    BLOCK_GRAY,
    ICO_SPHERE,
    CUBE_ODD,
    CRAZY,
    CONE_PURPLE,
    CONE_GRAY,
    SPAWNER,
    BLANK_11,
    BLANK_12,
    BLANK_13,
    BLANK_14,
    BLANK_15,
    BLANK_16,
    BLANK_17,
    BLANK_18,
    BLANK_19,
    BLANK_20,
    BLANK_21,
    BLANK_22,
    BLANK_23,
    BLANK_24,
    BLANK_25
}
//------------------------------------------------------------------------
public class BaseBlock : MonoBehaviour
{
    public bool Destroy_On_Contact = false;
    //------------------------------------------------------------------------
    [SerializeField]
    private float _Spawn_Chance;
    public float Spawn_Chance
    {
        get { return _Spawn_Chance; }
        set { _Spawn_Chance = value; }
    }
    //------------------------------------------------------------------------
    [SerializeField]
    private Vector3 _Delta_Normal;
    public Vector3 Delta_Normal
    {
        get { return _Delta_Normal; }
        set { _Delta_Normal = value.normalized; }
    }
    //------------------------------------------------------------------------
    [SerializeField]
    private Vector3 _Delta_Rotate;
    public Vector3 Delta_Rotate
    {
        get { return _Delta_Rotate; }
        set { _Delta_Rotate = value; }
    }
    //------------------------------------------------------------------------
    [SerializeField]
    private float _Delta_Speed;
    public float Delta_Speed
    {
        get { return _Delta_Speed; }
        set { _Delta_Speed = value; }
    }
    //------------------------------------------------------------------------
    [SerializeField]
    private Vector3 _Delta_Scale;
    public Vector3 Delta_Scale
    {
        get { return _Delta_Scale; }
        set { _Delta_Scale = value; }
    }
    //------------------------------------------------------------------------
    public BlockType Block_Type;
    //------------------------------------------------------------------------
    [SerializeField]
    private float _Damage_Per_Second;
    public float Damage_Per_Second
    {
        get { return _Damage_Per_Second; }
        set { _Damage_Per_Second = value; }
    }
    //------------------------------------------------------------------------
    public Vector3 Offset = new Vector3(0f, 0f, 0f);
    //------------------------------------------------------------------------
    private Spawner _Parent_Spawner;
    public Spawner Parent_Spawner { get { return _Parent_Spawner; } }
    //------------------------------------------------------------------------
    public Spawner Parent_Spawner_Set(Spawner New_Parent_Spawner) {
        if (New_Parent_Spawner == null)
            throw new NullReferenceException("Parent_Spawner_Set(Spawner New_Parent_Spawner) New_Parent_Spawner is null!");
        _Parent_Spawner = New_Parent_Spawner;
        return Parent_Spawner;
    }
    //------------------------------------------------------------------------
    // Do stuff when a ball contacts this block
    internal void Contact()
    {

    }
    //------------------------------------------------------------------------
    // Do stuf when the block dies
    internal void Die()
    {

    }
    //------------------------------------------------------------------------

    //------------------------------------------------------------------------
    void FixedUpdate()
    {        
        transform.position = new Vector3(
            transform.position.x + (Delta_Scale.x * Delta_Normal.x * Delta_Speed),
            transform.position.y + (Delta_Scale.y * Delta_Normal.y * Delta_Speed),
            transform.position.z + (Delta_Scale.z * Delta_Normal.z * Delta_Speed)
        );
        transform.Rotate(Delta_Rotate);
    }
    //------------------------------------------------------------------------

    //------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        
    }
    //------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
        
    }


}
//------------------------------------------------------------------------