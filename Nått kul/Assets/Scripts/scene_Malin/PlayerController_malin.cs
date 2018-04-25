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

public class PlayerController_malin : MonoBehaviour
{

	public float testar;

    private float speed;
    private Rigidbody rb;
	private float g;

	private float x;
	private float y;
	private float z;


    void Start()
	{
		speed = 10f;
        rb = GetComponent<Rigidbody>();

		testar = 18f;
    }

    void Update()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");



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


		if (Input.GetKey ("space")) 
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

		Debug.Log ("curr.y = " + currRot.y);

		// If the right arrow is pressed get the character to face the right
		if (Input.GetKey (KeyCode.RightArrow) && currRot.y != 90) 
		{
			gameObject.transform.Rotate (0, 90, 0);
		}

		// If the left arrow is pressed get the character to face the left
		if (Input.GetKey (KeyCode.LeftArrow) && currRot.y != 270) 
		{
			gameObject.transform.Rotate (0, 270, 0);

		}



	}
}