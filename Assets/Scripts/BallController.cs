using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float gravity = 20f;
    public float jumpFirst = 10f;
    public float jumpSecond = 10f;

    public int Jumps_Left = 0;
    private int Max_Jumps_Left = 2;
    private bool Cant_Switch_Gravity = true;
    private bool Gravity_Is_Up = false;

    private Rigidbody body;
    //------------------------------------------------------------------------
    void Start()
    {
        body = GetComponent<Rigidbody>();
        UpdateGravity();
        //xPos = body.position.x;
        //zPos = body.position.z;
    }
    //------------------------------------------------------------------------
    // conditions that allow us to jump
    bool AllowedToJump()
    {
        Debug.Log("Jumps Left: " + Jumps_Left);
        return Jumps_Left > 0;
    }
    //------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Cant_Switch_Gravity) return; // Can only switch once, until reset by hitting something
            Gravity_Is_Up = !Gravity_Is_Up;
            Cant_Switch_Gravity = true;
            Jumps_Left = 0;
            UpdateGravity();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (AllowedToJump())
            {
                float jumpFactor = body.velocity.y * 0.25f;
                switch (Jumps_Left)
                {
                    case 1: body.velocity = new Vector3(0f, Gravity_Is_Up ? jumpFactor + (-jumpSecond) : jumpFactor + jumpSecond, 0f); break;
                    case 2: body.velocity = new Vector3(0f, Gravity_Is_Up ? jumpFactor + (-jumpFirst) : jumpFactor + jumpFirst, 0f); break;
                }
                Jumps_Left--;
            }
    }
    //------------------------------------------------------------------------
    void UpdateGravity()
    {
        Physics.gravity = new Vector3(0.0f, Gravity_Is_Up ? gravity : -gravity, 0.0f);
    }
    //------------------------------------------------------------------------
    void FixedUpdate()
    {

    }
    //------------------------------------------------------------------------
    void OnCollisionEnter(Collision col)
    {
        //Only hitting the floor allows us to switch gravity
        if (col.gameObject.tag == "Floor")
        {
            Cant_Switch_Gravity = false;
        }

        // Hitting anything  resets how many jumps we have
        Jumps_Left = Max_Jumps_Left;


        BaseBlock GOBB = col.gameObject.GetComponent<BaseBlock>() as BaseBlock;
        if (GOBB != null)
        {
            GOBB.Contact();
            if (GOBB.Destroy_On_Contact)
            {
                GOBB.Die(); // Do stuff like add bonuses, remove health etc
                Destroy(col.gameObject);
            }
        }
    }
    //------------------------------------------------------------------------
    /*
    void OnTriggerEnter(Collider coll)
    {
        
    }
    */
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


