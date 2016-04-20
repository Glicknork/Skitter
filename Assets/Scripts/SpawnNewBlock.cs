using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNewBlock : MonoBehaviour {

    public float spawnSpeed = 0.5f;

    public GameObject[] blocks;

    public GameObject blankBlock; 
    
    public Transform upperBlockSpawn;
    public Transform lowerBlockSpawn;

    public Transform spawnCheckerUpper;
    public Transform spawnCheckerLower;

    public GameObject[] blockList;
    public List<GameObject> blocksSpawned = new List<GameObject>();
        

    int layerMask = 1 << 8;

    bool blankBlockSpawned;

    void Start()
    {
        StartCoroutine("SpawnBlock");
    }

    IEnumerator SpawnBlock()
    {
        yield return new WaitForSeconds(spawnSpeed);
        // instanatiates an upperblock clone at the spawn spot and rotates it so it's pointing down
        GameObject upperBlockClone = (GameObject)Instantiate(ReturnNewSpawnBlock(), upperBlockSpawn.position, upperBlockSpawn.rotation);
        Vector3 rotationVector = upperBlockClone.transform.rotation.eulerAngles;
        rotationVector.x = 90;
        upperBlockClone.transform.rotation = Quaternion.Euler(rotationVector);
        // instantiates a lowerblock clone at the spawn spot
        GameObject lowerBlockClonce = (GameObject)Instantiate(ReturnNewSpawnBlock(), lowerBlockSpawn.position, lowerBlockSpawn.rotation);
        StartCoroutine("SpawnBlock");
    }


	/*void OnTriggerEnter(Collider coll)
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
    }*/

    GameObject ReturnNewSpawnBlock()
    {
        if (BlankThresholdReached())
        {
            GameObject block = blockList[Random.Range(0, blockList.Length)];
            blocksSpawned.Add(block);
            return block;
        }
        blocksSpawned.Add(blankBlock);
        return blankBlock;
    }

    bool BlankThresholdReached()
    {
        int numberOfBlanks = 0;
        for (int i = 0; i < blocksSpawned.Count; i++)
        {
            if(blocksSpawned[i].GetComponent<CubeMoveLeft>().blockType == CubeMoveLeft.BlockType.BLANK)
            {
                numberOfBlanks += 1;
            }
            if (numberOfBlanks > 5)
            {
                blocksSpawned.Clear();
                return true;
            }
        }
        if(blocksSpawned.Count > 6)
        {
            blocksSpawned.Clear();
        }
        return false;
    }

    /*GameObject[] FillBlockArray()
    {
       GameObject[] tempArray = new GameObject[blockList.Count];
       for(int i = 0; i < blockList.Count; i++)
        {
            tempArray[i] = blockList[i];
        }     



    }*/


    /*GameObject ReturnNewSpawnBlock()
    {
        if (Physics.Raycast(spawnCheckerLower.position, lowerBlockSpawn.position, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide) &&
            Physics.Raycast(spawnCheckerUpper.position, upperBlockSpawn.position, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide))
        {
            //Debug.Log("blank FOUND");
            return blocks[Random.Range(0, blocks.Length)];
        }
        else
        {
            //Debug.Log("blank not found");
            return blankBlock;
        }
        
    }*/



}
