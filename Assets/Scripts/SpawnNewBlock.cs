using UnityEngine;
using System.Collections;

public class SpawnNewBlock : MonoBehaviour {

    public GameObject[] blocks;

    public GameObject blankBlock; 
    
    public Transform upperBlockSpawn;
    public Transform lowerBlockSpawn;

    public Transform spawnCheckerUpper;
    public Transform spawnCheckerLower;
        

    int layerMask = 1 << 8;
        

	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Block")
        {
            // instanatiates an upperblock clone at the spawn spot and rotates it so it's pointing down
            GameObject upperBlockClone = (GameObject) Instantiate(ReturnNewSpawnBlock(), upperBlockSpawn.position, upperBlockSpawn.rotation);
            Vector3 rotationVector = upperBlockClone.transform.rotation.eulerAngles;
            rotationVector.x = 90;
            upperBlockClone.transform.rotation = Quaternion.Euler(rotationVector);            
            // instantiates a lowerblock clone at the spawn spot
            GameObject lowerBlockClonce = (GameObject)Instantiate(ReturnNewSpawnBlock(), lowerBlockSpawn.position, lowerBlockSpawn.rotation);
        }        
       
    }

    GameObject ReturnNewSpawnBlock()
    {
        if (Physics.Raycast(spawnCheckerLower.position, lowerBlockSpawn.position, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide) &&
            Physics.Raycast(spawnCheckerUpper.position, upperBlockSpawn.position, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide))
        {
            Debug.Log("blank FOUND");
            return blocks[Random.Range(0, blocks.Length)];
        }
        else
        {
            Debug.Log("blank not found");
            return blankBlock;
        }
        
    }



}
