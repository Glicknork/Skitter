using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNewBlock : MonoBehaviour
{

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

    public GameObject LastUpperSpawned;
    public GameObject LastLowerSpawned;

    public void Spawn(bool IsUpper)
    {
        if (IsUpper)
        {
            Vector3 LastUpperPos = new Vector3(LastUpperSpawned.transform.position.x + 2f, LastUpperSpawned.transform.position.y, LastUpperSpawned.transform.position.z);
            GameObject RandomBlock = blockList[Random.Range(0, blockList.Length)];
            GameObject upperBlockClone = (GameObject)Instantiate(RandomBlock, LastUpperPos, RandomBlock.transform.rotation);
            upperBlockClone.tag = LastUpperSpawned.tag;
            LastUpperSpawned = upperBlockClone;
        }
        else
        {            
            Vector3 LastLowerPos = new Vector3(LastLowerSpawned.transform.position.x + 2f, LastLowerSpawned.transform.position.y, LastLowerSpawned.transform.position.z);
            GameObject RandomBlock = blockList[Random.Range(0, blockList.Length)];
            GameObject lowerBlockClone = (GameObject)Instantiate(RandomBlock, LastLowerPos, Quaternion.Euler(-90, 0, 0));
            lowerBlockClone.tag = LastLowerSpawned.tag;
            LastLowerSpawned = lowerBlockClone;
        }
    }
    /*
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
            if (blocksSpawned[i].GetComponent<CubeMoveLeft>().blockType == CubeMoveLeft.BlockType.BLANK)
            {
                numberOfBlanks += 1;
            }
            if (numberOfBlanks > 5)
            {
                blocksSpawned.Clear();
                return true;
            }
        }
        if (blocksSpawned.Count > 6)
        {
            blocksSpawned.Clear();
        }
        return false;
    }
    */
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
