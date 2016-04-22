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

    public BlockType blockType;


    void Start()
    {
        moveSpeed = GD.gameController.levelSpeed;
    }

	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = new Vector3(transform.position.x - GD.gameController.levelSpeed, transform.position.y, transform.position.z);
	}
    /*
    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }*/
}
