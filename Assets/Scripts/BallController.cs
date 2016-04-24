using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float gravity = 20f;
    public float jumpFirst = 30f;
    public float jumpSecond = 20f;

    public int Jumps_Left = 0;
    private bool Cant_Switch_Gravity = false;
    private bool Gravity_Is_Up = false;

    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        UpdateGravity();
        //xPos = body.position.x;
        //zPos = body.position.z;
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Cant_Switch_Gravity) return; // Can only switch once, until reset by hitting something
            Gravity_Is_Up = !Gravity_Is_Up;
            Cant_Switch_Gravity = true;
            UpdateGravity();
        }
    }

    void UpdateGravity()
    {
        Physics.gravity = new Vector3(0.0f, Gravity_Is_Up ? gravity : -gravity, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // body.position = new Vector3(xPos, body.position.y, zPos);

        if (Jumps_Left >= 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                
                switch (Jumps_Left)
                {
                    case 1: body.velocity = new Vector3(0f, jumpSecond, 0f); break;
                    case 2: body.velocity = new Vector3(0f, jumpFirst, 0f); break;
                }

                Jumps_Left--;
            }
        }
    }

    //------------------------------------------------------------------------
    void OnCollisionEnter(Collision col)
    {
        /*Cant_Switch_Gravity = false;
        BaseBlock BaseBlock = col.gameObject.GetComponent<BaseBlock>() as BaseBlock;
        if (BaseBlock != null) BaseBlock.Die();
        Destroy(col.gameObject);*/
    }
    //------------------------------------------------------------------------


    void OnTriggerEnter(Collider coll)
    {
        Cant_Switch_Gravity = false;
        if (coll.gameObject.tag == "Floor")
        {
            Jumps_Left = 2;            
        }
    }

    /*
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

    }*/
}


