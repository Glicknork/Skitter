using UnityEngine;
using System.Collections;

public class CubeMoveLeft : MonoBehaviour {

    public float moveSpeed;

    public enum BlockType
    {
        BLANK,
        CUBE,
        CONE
    }

    public enum BlockPosition
    {
        UPPER,
        LOWER
    }

    public BlockType blockType;

    public BlockPosition blockPosition;


    void Start()
    {
        moveSpeed = GD.gameController.blockTransformSpeed;
    }

    public static CubeMoveLeft NewCubeMoveLeft(Transform spawnTransform, ref CubeMoveLeft cubeMoveLeft)
    {
        CubeMoveLeft blockClone = (CubeMoveLeft)Instantiate(cubeMoveLeft, spawnTransform.position, spawnTransform.rotation);
        Vector3 rotationVector = cubeMoveLeft.transform.rotation.eulerAngles;
        rotationVector.x = 90;
        //upperBlockClone.transform.rotation = Quaternion.Euler(rotationVector);
        //upperBlockClone.transform.position = new Vector3((upperBlockClone.transform.position.x + (i + 1f)), upperBlockClone.transform.position.y, upperBlockClone.transform.position.z);
        return blockClone;
    }


	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = new Vector3(transform.position.x - GD.gameController.blockTransformSpeed, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }


}
