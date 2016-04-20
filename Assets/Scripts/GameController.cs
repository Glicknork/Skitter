using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public int numberOfBlanks = 8;

    public float blockTransformSpeed = 0.05f;

    public float spawnSpeed = 0.5f;
       

    public GameObject blankBlock;

    public Transform upperBlockSpawn;
    public Transform lowerBlockSpawn;
     

    public GameObject[] blockList;
    List<GameObject> blocksSpawned = new List<GameObject>();


    int layerMask = 1 << 8;

    bool blankBlockSpawned;

    void Start()
    {
        SpawnBlockSet();
        StartCoroutine("SpawnBlock");
    }

    IEnumerator SpawnBlock()
    {
        yield return new WaitForSeconds(spawnSpeed);        
        SpawnBlockSet();        
        StartCoroutine("SpawnBlock");
    }

    void SpawnBlockSet()
    {
        for (float i = 0; i < 150f; i++)
        {
            GameObject upperBlockClone = (GameObject)Instantiate(ReturnNewSpawnBlock(), upperBlockSpawn.position, upperBlockSpawn.rotation);
            Vector3 rotationVector = upperBlockClone.transform.rotation.eulerAngles;
            rotationVector.x = 90;
            upperBlockClone.transform.rotation = Quaternion.Euler(rotationVector);
            upperBlockClone.transform.position = new Vector3((upperBlockClone.transform.position.x + (i + 1f)), upperBlockClone.transform.position.y, upperBlockClone.transform.position.z);
            // instantiates a lowerblock clone at the spawn spot
            GameObject lowerBlockClonce = (GameObject)Instantiate(ReturnNewSpawnBlock(), lowerBlockSpawn.position, lowerBlockSpawn.rotation);
            lowerBlockClonce.transform.position = new Vector3((lowerBlockClonce.transform.position.x + (i + 1f)), lowerBlockClonce.transform.position.y, lowerBlockClonce.transform.position.z);
        }
    }



    // Update is called once per frame
    void FixedUpdate ()
    {
        //spawnSpeed = 2f / blockTransformSpeed;
    }

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
        int blanks = 0;
        for (int i = 0; i < blocksSpawned.Count; i++)
        {
            if (blocksSpawned[i].GetComponent<CubeMoveLeft>().blockType == CubeMoveLeft.BlockType.BLANK)
            {
                blanks += 1;
            }
            if (blanks > numberOfBlanks)
            {
                blocksSpawned.Clear();
                return true;
            }
        }
        if (blocksSpawned.Count > numberOfBlanks + 1)
        {
            blocksSpawned.Clear();
        }
        return false;
    }
}
