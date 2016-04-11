using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {


    Rigidbody body;

	// Use this for initialization
	void Start ()
    {

        body = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.RightArrow))
            {
            body.AddForce(50, 0, 0);            
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.velocity = new Vector3(body.velocity.x, 2f, body.velocity.z);
        }

    }
}
