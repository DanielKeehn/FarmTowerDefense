using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
SUMMARY:
    This script controls player movement and gravity, which is controlled by WASD and the spacebar
CODE OVERVIEW:
    if WASD is pressed
        update the player position
    if the player is grounded and presses the spacebar
        the player jumps
*/

public class PlayerMovement : MonoBehaviour
{

    // This is a refrence to the character controller
    public CharacterController controller;

    // This float controls how fast player moves left and right and up and down
    public float speed = 12f;

    // The speed will change when the player is crouched
    public float crouchSpeed = 4f;

    // This constant is used when calculating gravity
    public float gravity = -9.81f;
    // This determines how high a player can jump
    public float jumpHeight = 3f;
    // This refrences sphere which checks for ground
    public Transform groundCheck;
    /// This is the radius of sphere
    public float groundDistance = 0.4f;
    // This controls what objects ground check should check for
    public LayerMask groundMask;

    // This vector stores player velocity which will be used to implement jumping/gravity
    Vector3 velocity;
    // This bool checks if the player is on the ground which will be used to implement jumping/gravity
    bool isGrounded;

    // Determies is the player is crouched down or not
    bool isCrouched = false;

    void Start()
    {
        FindObjectOfType<GameManager>().attackModeEvent += setPitchForkActive;
        FindObjectOfType<GameManager>().spawnModeEvent += setPitchForkInActive;
    }

    // Update is called once per frame
    void Update()
    {

        // This checks if the player is on the ground and returns true or false
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // This resets velocity to zero when player is grounded
        if (isGrounded && velocity.y < 0) {
            // Since this might register before player is on the ground, we are setting velocity to -2f instead of 0
            velocity.y = -2f;
        }

        // These two lines of code check if WASD has been pressed and returns as float based on this
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // This creates the new position of the player based on x and z movement
        Vector3 move =  transform.right * x + transform.forward * z;
        
        // This actually moves the player by refrencing the player controller
        // speed determines how far and player moves and Time.delatTime allows this to run independent of framerate
        if (isCrouched) {
            controller.Move(move * crouchSpeed * Time.deltaTime);
        } else {
            controller.Move(move * speed * Time.deltaTime);
        }
      
        if (Input.GetButtonDown("Jump") && isGrounded) {
            // This is using the formula v = SquareRoot(h x -2 x g)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        // This acutally moves the player when jumping and falling by refrencing the player controller
        // We mutliple by Time.deltaTime once more because this formula: deltaY = 1/2g * t^2
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Crouch")) {
            // This runs if a player is not yet crouched
            if (!(isCrouched)) {
                controller.height = 2.0f;
                // This line of code makes crouching look more realistic rather than a height change 
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                isCrouched = true;
            // This runs if a player is already crouched
            } else {
                // The transform in not changed but only the height because adjusting the tranform 
                // here makes it look like the player is jumping
                controller.height = 3.8f;
                isCrouched = false;
            }
        }
    }

    public void setPitchForkActive() {
        Transform pitchFork = transform.FindChild("Pitchfork");
        if (pitchFork == null) {
            Debug.Log("Couldn't find the pitchfork, make sure there are no spelling errors");
        } else {
            pitchFork.gameObject.SetActive(true);
        }
    }

    public void setPitchForkInActive() {
        Transform pitchFork = transform.FindChild("Pitchfork");
        if (pitchFork == null) {
            Debug.Log("Couldn't find the pitchfork, make sure there are no spelling errors");
        } else {
            pitchFork.gameObject.SetActive(false);
        }
    }
}
