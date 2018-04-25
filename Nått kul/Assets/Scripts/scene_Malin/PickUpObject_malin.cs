/* ************************************************************
 * Author: Malin
 * 
 * This script will pick up an object and release it when 
 * colliding with it and pressing the 'Z' key. 
 * 
 * The script should be placed on the object that you would 
 * like to pick up. 
 * 
 * Code review by: Thobias
 * ***********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject_malin : MonoBehaviour {

	public Transform player;
	private float throwForce = 10;
	private bool hasPlayer = false;
	public bool beingCarried = false;
	private bool inserted = false;


	private Rigidbody rb;

	void OnTriggerEnter(Collider other)
	{
		// If you collide a pick-up with the player
		// Will only work if the Player has it's tag set to Player in Unity!!!!!!
		if(other.gameObject.CompareTag("Player")) 
		{
			hasPlayer = true;
		}


	}

	void OnTriggerExit(Collider other)	// när man inte längre krockar en pick-up med ett mission
	{

		if (other.gameObject.CompareTag("Player"))
		{
			hasPlayer = false;
		}
	}


	void Start()
	{
		rb = GetComponent<Rigidbody>();

	}

	void Update()
	{
		// if any object is being carried. 
		if (beingCarried)
		{ 
			if (Input.GetKeyDown (KeyCode.Z)) // här släpper man ett objekt genom att klicka på Z
			{	
				rb.isKinematic = false;
				transform.parent = null;
				beingCarried = false;
			}
		}
		else // if no object is being carried
		{
			// if you press the 'Z' key and hasPlayer is true (colliding pick-up with player)
			if (Input.GetKeyDown(KeyCode.Z) && hasPlayer)
			{
				// Makes the object a child to the player and the pick-up
				// will follow the player. 
				rb.isKinematic = true;
				transform.parent = player;
				beingCarried = true;
			}
		}
	}
}
