using UnityEngine;
using System.Collections;

public class CubeMoveLeft : MonoBehaviour {

    public float moveSpeed = 0.05f;

	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
