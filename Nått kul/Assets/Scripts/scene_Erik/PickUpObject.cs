﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ***************************************************
 * Author: Erik Asp
 * 
 * Used for picking up objects, attach this script to the object
 * to make it able to pick up by the player. 
 * 
 * **************************************************/

public class PickUpObject : MonoBehaviour {

    //Used for making player into parent so the object will follow it around.
    public Transform player;

    public float throwForce = 30;
    public bool hasPlayer = false;
    bool beingCarried = false;
    public bool inserted = false;
	ControllerInput controller = new ControllerInput();

    private Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {

		// If the player is at the object it can pick it up
        if(other.gameObject.CompareTag("Player")) //will only work if the Player has it's tag set to Player in Unity!!!!!!
        {
           
			Debug.Log ("har en player");
            hasPlayer = true;
        }

		if (other.gameObject.CompareTag("ZoneYellow") && this.gameObject.CompareTag("BatteryYellow"))// Not mine
        {
            inserted = true;
            Destroy(gameObject);
        }

		if (other.gameObject.CompareTag("ZoneWhite") && this.gameObject.CompareTag("BatteryWhite"))// Not mine
		{
			inserted = true;
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("ZoneGreen") && this.gameObject.CompareTag("BatteryGreen"))// Not mine
		{
			inserted = true;
			Destroy(gameObject);
		}

    }

    void OnTriggerExit(Collider other)
    {
		
        if (other.gameObject.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // isKinematic
    }

    void Update()
    {
        if (beingCarried)
        {
            //Press Z to release object
            if (controller.ButtonPressed("Button4") && hasPlayer)
            {
                rb.isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                WhiteBatterySoundManagerScript.PlaySound("drop");
            }
        }
        else
        {
            //Picks up the object
			if (controller.ButtonPressed("Button4") && hasPlayer)
            {
                // Sets the object to kinematic so it can move around without being affected by gravity or collide with other objects
                rb.isKinematic = true;
                
                transform.parent = player; // Sets the player to parent so that the object will follow it around
                beingCarried = true; // Used for if statement above

                WhiteBatterySoundManagerScript.PlaySound("pick");
    
            }
        }
    }
}