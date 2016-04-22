using UnityEngine;
using System.Collections;
//------------------------------------------------------------------------
public class BlockArray : MonoBehaviour {
    //------------------------------------------------------------------------
    // Contains a list of the block types, and attached to a single static game object
    public GameObject[] Blocks;
    //------------------------------------------------------------------------
    public int Count { get { return Blocks.Length; } }
    //------------------------------------------------------------------------
    public GameObject this[int i]
    {
        get { return Blocks[i];}
        //set { Blocks[i] = value;}
    }
    //------------------------------------------------------------------------
    // Use this for initialization
    void Start () {
	
	}
    //------------------------------------------------------------------------
    // Update is called once per frame
    void Update () {
	
	}
}
//------------------------------------------------------------------------