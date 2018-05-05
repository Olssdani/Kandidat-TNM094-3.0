using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ***************************************************
 * Author: Erik Asp, Malin Niska
 * 
 * Used for opening the doors in the leak-room. 
 * 
 * **************************************************/

public class open_door_leak : MonoBehaviour 
{

	public float reachDistance;
	// Takes game objects from Unity
	public GameObject Player; // Player
	public GameObject Target; // Left side of the door
	public GameObject Target2; // Right side of the door

	// Togglers for the different doors
	private bool openWhite = false;
	private bool openGreen = false;
	private bool openYellow = false;

	// Animators for the left and right side of the door respectively
	private Animator anim;
	private Animator anim2;

	// Controller to access the buttons 
	private ControllerInput con;

	// Variables to make the animation smooth
	private float delta;
	private float start;


	void Start () 
	{
		// Gets the targets animators to be used later
		anim = Target.GetComponent<Animator>();
		anim2 = Target2.GetComponent<Animator>();

		con = new ControllerInput ();

		delta = 0;
		start = Time.time;
	}


	void Update () 
	{
		// delta is the time from start to now
		delta = Time.time - start;

		if (delta > 1) 
		{
			// Toggel White button
			if (con.ButtonPressed ("Button1") && !openWhite && gameObject.CompareTag("WhiteDoor")) 
			{

				// Plays the animations to open the door
				openWhite = true;
				open ();
			} 
			else if (con.ButtonPressed ("Button1") && openWhite && gameObject.CompareTag("WhiteDoor")) 
			{
				// Plays the animations to close the door
				openWhite = false;
				close ();
			}

			// Toggel Yellow button
			if (con.ButtonPressed ("Button2") && !openYellow && gameObject.CompareTag("YellowDoor")) 
			{

				// Plays the animations to open the door
				openYellow = true;
				open ();
			} 
			else if (con.ButtonPressed ("Button2") && openYellow && gameObject.CompareTag("YellowDoor")) 
			{
				// Plays the animations to close the door
				openYellow = false;
				close ();
			}


			// Toggel Green button
			if (con.ButtonPressed ("Button3") && !openGreen && gameObject.CompareTag("GreenDoor")) 
			{

				// Plays the animations to open the door
				openGreen = true;
				open ();
			} 
			else if (con.ButtonPressed ("Button3") && openGreen && gameObject.CompareTag("GreenDoor")) 
			{
				// Plays the animations to close the door
				openGreen = false;
				close ();
			}
		}
	}

	// Plays the animations to open the door
	void open()
	{
		anim.Play ("Open");
		anim2.Play ("Open_right");

		start = Time.time;
	}

	// Plays the animations to close the door
	void close()
	{
		anim.Play("Close");
		anim2.Play("Close_right");

		start = Time.time;
	}


}