using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // What is the maximum speed we want the player to walk at
    public float maxSpeed = 5f;
    //public Vector2 jumpSpeed;

    // Start facinf left (like the sprite-sheet)
    private bool facingLeft = true;

    // This will be a reference to the RigidBody2D 
    // component in the Player object
    private Rigidbody2D rb;

    // This is a reference to the Animator component
    private Animator anim;

    private Transform ts;

    // We initialize our two references in the Start method
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ts = GetComponent<Transform>();
    }
    /*void GetInput()
    {
        /*float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(jumpSpeed * 2);
            Debug.Log(rb.velocity);
        }
    }*/
    // We use FixedUpdate to do all the animation work
    void FixedUpdate()
    {

        // Get the extent to which the player is currently pressing left or right
        float h = Input.GetAxis("Horizontal");
        // Move the RigidBody2D (which holds the player sprite)
        // on the x axis based on the stae of input and the maxSpeed variable
        rb.velocity = new Vector2(h * maxSpeed, rb.velocity.y);
        
        // Pass in the current velocity of the RigidBody2D
        // The speed parameter of the Animator now knows
        // how fast the player is moving and responds accordingly
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("jump", Mathf.Abs(rb.velocity.y));

        // Check which way the player is facing 
        // and call reverseImage if neccessary
        if (h < 0 && !facingLeft)
            reverseImage();
        else if (h > 0 && facingLeft)
            reverseImage();
        //GetInput();

    }

    void reverseImage()
    {
        // Switch the value of the Boolean
        facingLeft = !facingLeft;

        // Get and store the local scale of the RigidBody2D
        Vector2 theScale = rb.transform.localScale;

        // Flip it around the other way
        theScale.x *= -1;
        rb.transform.localScale = theScale;
    }

}

