using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float gravity = 20f;

    public float smallJump = 20f;

    public float bigJump = 30f;

    bool grounded;

    bool jumped = false;

    Rigidbody body;

    Collider contactDetector;

    float xPos;
    float zPos;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -gravity, 0.0f);
        xPos = body.position.x;
        zPos = body.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        body.position = new Vector3(xPos, body.position.y, zPos);

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumped == false)
        {
            jumped = true;
            if (Physics.gravity.y < 0f)
            {
                body.velocity = new Vector3(0f, smallJump, body.velocity.z);
            }
            if (Physics.gravity.y > 0f)
            {
                body.velocity = new Vector3(0f, -smallJump, body.velocity.z);
            }

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            jumped = true;
            if (Physics.gravity.y < 0f)
            {
                body.velocity = new Vector3(0f, bigJump, body.velocity.z);
            }
            if (Physics.gravity.y > 0f)
            {
                body.velocity = new Vector3(0f, -bigJump, body.velocity.z);
            }
        }

        if (grounded)
        {             
            jumped = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.gravity.y < 0f)
            {
                Physics.gravity = new Vector3(0.0f, gravity, 0.0f);
            }
            else if(Physics.gravity.y > 0f)
            {
                Physics.gravity = new Vector3(0.0f, -gravity, 0.0f);
            }            
        }
    }


    

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Block")
        {
            grounded = false;
        }
    }


    void OnTriggerEnter(Collider coll)
    {        
        if (coll.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }        
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Block")
        {
            grounded = true;
        }
               
    }
}


