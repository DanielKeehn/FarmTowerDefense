using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
SUMMARY:
    This script controls the camera movement, which is controlled by the mouse

CODE OVERVIEW:
    If the mouse is moved on the x axis (side to side)
        Rotate player object around the y axis
    If the mouse is moved on the y axis (up and down)
        Rotate camera object around the x axis
        Limit the rotation of the camera to 180 degress (this is known as clamping)
*/

public class MouseLook : MonoBehaviour
{

    // This value changes the speed of the camera
    public float mouseSensitivity = 100f;

    // This is the transform of the Player Object
    public Transform playerBody;

    // This value deals with how much the camera is rotated when mouse is moved on y axis
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // This hides and locks cursor to center of screen when game is run
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // These are preprogrammed axises in Unity that change based on the mouse movement
        // Multiply by mouseSensitivity to adjust speed of camera and by Time.deltaTime to run indpendent of framerate
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;    

        // xRotation is decreased based on player input
        xRotation -= mouseY; 
        // Using Mathf.Clamp limits how much player can rotate camera up and down     
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  
        // This actually changes the rotation variable of camera transform
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Calling the Rotate function is what actually changes the Y Rotation of the Player Object
        // Vector3.up essentially is the Y axis and mouseX is how much the player is rotated around the Y axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
