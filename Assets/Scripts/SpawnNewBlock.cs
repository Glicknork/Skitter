using UnityEngine;
using System.Collections;

public class SpawnNewBlock : MonoBehaviour {

    public GameObject[] blocks; 
    
    public Transform upperBlockSpawn;
    public Transform lowerBlockSpawn;

	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Block")
        {            
            Instantiate(ReturnNewSpawnBlock(), upperBlockSpawn.position, upperBlockSpawn.rotation);
            Instantiate(ReturnNewSpawnBlock(), lowerBlockSpawn.position, lowerBlockSpawn.rotation);
        }        
       
    }

    GameObject ReturnNewSpawnBlock()
    {
        return blocks[Random.Range(0, blocks.Length)];
    }



}
