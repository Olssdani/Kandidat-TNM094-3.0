﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPickUpBattery : MonoBehaviour {

	//Used for making player into parent so the object will follow it around.
	public Transform arm;

	public bool hasArm = false;
	bool beingCarried = false;
	ControllerInput controller = new ControllerInput();

	private Rigidbody rb;

	//time
	float start = 0f;
	float delta = 0f;

	void OnTriggerEnter(Collider other)
	{
		// If the player is at the object it can pick it up
		if(other.gameObject.CompareTag("Arm")) 
		{
            Debug.Log("Arm");
            hasArm = true;
		}

	}

	void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag("Arm"))
		{
			hasArm = false;
		}
	}

	void Start()
	{
		rb = GetComponent<Rigidbody>(); // isKinematic
	}

	void Update()
	{
		delta = Time.time - start;

		if (beingCarried)
		{
			//Press Z to release object
			if (controller.ButtonPressed("Button5") && hasArm && delta > 1.0f)
			{
				start = Time.time;
				rb.isKinematic = false;
				transform.parent = null;
				beingCarried = false;
			}
		}
		else
		{
			//Picks up the object
			if (controller.ButtonPressed("Button5") && hasArm && delta > 1.0f)
			{
				start = Time.time;
                Debug.Log("Hararm");
               
                // Sets the object to kinematic so it can move around without being affected by gravity or collide with other objects
				rb.isKinematic = true;
				transform.parent = arm; // Sets the player to parent so that the object will follow it around
				beingCarried = true; // Used for if statement above
			}
		}
	}
}
