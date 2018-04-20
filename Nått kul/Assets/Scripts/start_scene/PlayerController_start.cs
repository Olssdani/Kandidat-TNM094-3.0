using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ***************************************************
 * Author: Erik Asp
 * 
 * Makes the character move and turn with a joystick/keyboard. 
 * Set camera as child to the player and it will turn and move with the
 * character. Use in levels with third or first person perspective.
 * 
 * **************************************************/

public class PlayerController_start : MonoBehaviour {

    // Gets the speed of which the player moves and rotates
    public float speed;
    public float rotateSpeed;
    // Character controller needed for function SimpleMove
    private CharacterController cc;

	void Update () {
        // Gets the component from Unity
        cc = GetComponent<CharacterController>();
        // Gets the input from the keyboard/joystick and uses it to rotate around the y-axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        // Gets a vector that transforms in the players local coordinates instead of the global coordinates via TransformDirection
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        // Gets input from keyboard/joystick to get a float if the player moves forward or backward
        float curSpeed = speed * Input.GetAxis("Vertical");
        // Uses the function SimpleMove to move the player using the direction times the float
        cc.SimpleMove(forward * curSpeed);

    }
}
