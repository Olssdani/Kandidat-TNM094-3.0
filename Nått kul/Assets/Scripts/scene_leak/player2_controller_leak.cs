/* **************************************************
 * Author: Malin 
 * 
 * Set the speed and controller of the player.
 * 
 * Code review: Thobias
 * 
 * *************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2_controller_leak : MonoBehaviour
{
	ControllerInput controller = new ControllerInput();

	public float Verticalspeed;
	public float Horizontalspeed;
	public float MaxSpeed;

	private Rigidbody rb;
	private float g;

	private float x;
	private float y;
	private float z;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Verticalspeed = 10;
		Horizontalspeed = 10;
		MaxSpeed = 10;
	}

	void FixedUpdate()
	{
		//Get movement from right joystick (arrows)
		float moveHorizontal = controller.GetAxis("Right", "Horizontal");
		float moveVertical = controller.GetAxis("Right", "Vertical");

		//Move player facing
		if(moveHorizontal < 0 && Mathf.Abs(this.gameObject.transform.rotation.eulerAngles.y - 270) > 0.01)
		{
			this.gameObject.transform.Rotate(0,180,0);
		}else if (moveHorizontal > 0 && Mathf.Abs(this.gameObject.transform.rotation.eulerAngles.y- 90)>0.01)
		{
			this.gameObject.transform.Rotate(0, 180, 0);
		}

		//Set up movement to 0 because the thrusters must be pressed
		/*if (moveVertical > 0f)
        {
             moveVertical = 0f;
        }*/
		//Gives a value to the vertical movement if the thruster button is pressed
		/* if (controller.ButtonPressed("Button4") )
        {
            moveVertical = 1.0f;
        }*/

		Vector3 movement;

		//Caps the maximum velocity
		if(Mathf.Abs(rb.velocity[0]) > MaxSpeed && Mathf.Abs(rb.velocity[1]) > MaxSpeed)
		{
			movement = new Vector3(0.0f, 0.0f, 0.0f);
		}
		else if (Mathf.Abs(rb.velocity[0]) > MaxSpeed)
		{
			movement = new Vector3(0.0f, moveVertical * Verticalspeed, 0.0f);
		}
		else if(Mathf.Abs(rb.velocity[1]) > MaxSpeed)
		{
			movement = new Vector3(moveHorizontal * Horizontalspeed, 0.0f, 0.0f);
		}
		else
		{
			movement = new Vector3(moveHorizontal * Horizontalspeed, moveVertical * Verticalspeed, 0.0f);
		}

		//Add the force to the player
		rb.AddForce(movement);




		/*//Get movement in horizontal and vertical
        float moveHorizontal = controller.GetAxis("Left", "Horizontal");
        float moveVertical = controller.GetAxis("Left", "Vertical");

		z = transform.eulerAngles.z;
		x = transform.eulerAngles.x;
		y = transform.eulerAngles.y;

		// you press the up-key nothing should happen
		// if moveVertical is less than zero and space is pressed then nothing should happen
		if (moveVertical > 0f || (moveVertical < 0f && Input.GetKey ("space"))) 
		{
			moveVertical = 0f;
		} 


		//Debug.Log ("moveVertical = " + moveVertical);

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);




		rb.AddForce (movement * speed);

		// Makes the player stay still in the air. 
		if (moveVertical == 0f) 
		{
			Vector3 v = rb.velocity;
			v.y = 0f;
			//v.x = v.x * testar;
			rb.velocity = v;
		}


		//transform.LookAt(correctTarget);

		Vector3 desiredRot = new Vector3(x, y, z );
//		if (desiredRot.y > 30)
//		{
//			desiredRot = new Vector3(x, 30, z);
//		}
//		else if (desiredRot.y < -30)
//		{
//			desiredRot = new Vector3(x, -30, z);
//		}

		transform.rotation = Quaternion.Euler(desiredRot);


        if (controller.ButtonPressed("Button1") )
		{
			g = 9.82f * testar;
		} 
		else 
		{
			g = 0f;
		}

		//Debug.Log ("g = " + g);


		// Both space (pull up) and the down key (pull down) nothing should happen
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey ("space")) 
		{
			g = 0f;
		}
			
		Physics.gravity = new Vector3 (0, g, 0);

		Vector3 currRot = gameObject.transform.rotation.eulerAngles;

		//Debug.Log ("curr.y = " + currRot.y);

		// If the right arrow is pressed get the character to face the right
		if (Input.GetKey (KeyCode.RightArrow) && currRot.y != 90) 
		{
			gameObject.transform.Rotate (0, 90, 0);
		}

		// If the left arrow is pressed get the character to face the left
		if (Input.GetKey (KeyCode.LeftArrow) && currRot.y != 270) 
		{
			gameObject.transform.Rotate (0, 270, 0);

		}*/
	}
}