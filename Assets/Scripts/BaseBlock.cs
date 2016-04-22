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
    BLANK_10,
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
    private Vector3 _Delta_Speed;
    public Vector3 Delta_Speed
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
    // Do stuf when the block dies
    internal void Die()
    {

    }
    //------------------------------------------------------------------------

    //------------------------------------------------------------------------
    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x + (Delta_Normal.x * Delta_Scale.x * Delta_Speed.x),
            transform.position.y + (Delta_Normal.y * Delta_Scale.y * Delta_Speed.y),
            transform.position.z + (Delta_Normal.z * Delta_Scale.z * Delta_Speed.z)
        );
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