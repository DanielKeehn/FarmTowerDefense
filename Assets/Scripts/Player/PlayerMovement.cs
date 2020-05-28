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
    // This float controls how fast player moves left and right and up and down
    [SerializeField] private float speed = 12f;
	// The speed will change when the player is crouched
	[SerializeField] private float crouchSpeed = 4f;
	// This constant is used when calculating gravity
	[SerializeField] private float gravity = -9.81f;
	// This determines how high a player can jump
	[SerializeField] private float jumpHeight = 3f;
	// This refrences sphere which checks for ground
	public Transform groundCheck;
	/// This is the radius of sphere
	[SerializeField] private float groundDistance = 0.4f;
	// This is a reference to the pitchfork
	public Transform pitchfork;

	// This controls what objects ground check should check for
	private LayerMask groundMask;
	// This is a refrence to the character controller
	private CharacterController controller;
	// This vector stores player velocity which will be used to implement jumping/gravity
	private Vector3 velocity;
	// This vector stores player velocity for moving
	private Vector3 move;
	// This bool checks if the player is on the ground which will be used to implement jumping/gravity
	private bool isGrounded;
    // Determies is the player is crouched down or not
    private bool isCrouched = false;
	//This is a reference to the player's animator
	private Animator animator;
	// This is a reference to the gameManager
	private GameManager gameManager;

    void Start()
    {
		gameManager = FindObjectOfType<GameManager>();
		if (!gameManager)
		{
			Debug.LogWarning("No game manager found");
		}
		gameManager.attackModeEvent += setPitchForkActive;
		gameManager.spawnModeEvent += setPitchForkInActive;

		groundMask = LayerMask.GetMask("Environment");
		controller = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
		if (!animator)
		{
			Debug.LogWarning("No animator found");
		}
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
        move =  transform.right * x + transform.forward * z;
        
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
		UpdateAnimator();
    }

	private void UpdateAnimator()
	{
		animator.SetBool("Walking", (move.x > 0 || move.x < 0 || move.z > 0) ? true : false);
		animator.SetBool("inAttackState", (gameManager.getCurrentState() == 3) ? true : false);
		animator.SetBool("inSpawnState", (gameManager.getCurrentState() == 4) ? true : false);
	}

	public void setPitchForkActive() {
        if (pitchfork == null) {
            Debug.Log("Couldn't find the pitchfork, make sure there are no spelling errors");
        } else {
			pitchfork.gameObject.SetActive(true);
        }
    }

    public void setPitchForkInActive() {
        if (pitchfork == null) {
            Debug.Log("Couldn't find the pitchfork, make sure there are no spelling errors");
        } else {
			pitchfork.gameObject.SetActive(false);
        }
    }
}
