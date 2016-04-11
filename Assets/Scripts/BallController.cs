using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float jumpVelocity = 10f;

    Rigidbody body;

    // Use this for initialization
    void Start()
    {

        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.velocity = new Vector3(0f, jumpVelocity, body.velocity.z);
        }
    }



    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }
}


