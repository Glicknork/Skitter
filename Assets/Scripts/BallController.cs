using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float gravity = 20f;

    public float smallJump = 20f;

    public float bigJump = 30f;

    bool grounded;

    Rigidbody body;

    Collider contactDetector;

    // Use this for initialization
    void Start()
    {

        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics.gravity.y < 0f)
            {
                body.velocity = new Vector3(0f, smallJump, body.velocity.z);
            }
            if (Physics.gravity.y > 0f)
            {
                body.velocity = new Vector3(0f, -smallJump, body.velocity.z);
            }
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.gravity.y < 0f)
            {
                body.velocity = new Vector3(0f, bigJump, body.velocity.z);
            }
            if (Physics.gravity.y > 0f)
            {
                body.velocity = new Vector3(0f, -bigJump, body.velocity.z);
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

        if (coll.gameObject.tag == "GravZoneTop")
        {
            Physics.gravity = new Vector3 (0.0f, gravity, 0.0f);
        }
        if (coll.gameObject.tag == "GravZoneBottom")
        {
            Physics.gravity = new Vector3(0.0f, -gravity, 0.0f);
        }        
    }
}


