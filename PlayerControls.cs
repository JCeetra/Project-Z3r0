using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    /// <summary>
    ///Public Vars
    /// </summary>
    public float speed = 4;//movement speed of the character
    public float jumpPower = 100;


    /// <summary>
    /// private var
    /// </summary>
    Rigidbody rgBody;
    bool canJump; //flag to prevent double jump


    // Function to run at the start of the game
    void Start () {
        rgBody = GetComponent<Rigidbody>(); //get the rigibody component of the parent (character)
        canJump = true;
	}
	
	// function that run at every frames, the more frames = the more time it get called
	void Update () {
        var moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")); //make a undeclared var called moving and setting it to a new vector3 (since it's 3d) of the horizontal and vertical input
        transform.Translate(moving * Time.deltaTime * speed); //passsing the moving var into the translate function to move the character
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rgBody.AddForceAtPosition(new Vector3(0, jumpPower, 0), transform.position); //the jump action
            canJump = false; //prevent further jump
        }
          
	}

    void OnCollisionEnter(Collision collision) //built in collision function
    {
        
        if (collision.transform.CompareTag("Ground")) //if player is on the ground, enable the play jump
        {
            canJump = true;
        }
    
    }
}
