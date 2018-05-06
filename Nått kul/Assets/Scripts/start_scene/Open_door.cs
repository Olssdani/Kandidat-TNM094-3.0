using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ***************************************************
 * Author: Erik Asp
 * 
 * Used for opening the doors in the hub where the player chooses
 * level. When the character is close enough to the door, 
 * an animation will play that opens the door.
 * 
 * **************************************************/

public class Open_door : MonoBehaviour {

    public float reachDistance;
    public string button;
    // Takes game objects from Unity
    public GameObject Player; // Player
    public GameObject Target; // Left side of the door
    public GameObject Target2; // Right side of the door
    public bool open = false;

    // Animators for the left and right side of the door respectively
    private Animator anim;
    private Animator anim2;

    private ControllerInput con;

    // Use this for initialization
    void Start () {
        // Gets the targets animators to be used later
        anim = Target.GetComponent<Animator>();
        anim2 = Target2.GetComponent<Animator>();

        con = new ControllerInput();
    }
	
	// Update is called once per frame
	void Update () {
        // Calculates the distance between the player and the door
        reachDistance = Vector3.Distance(Player.transform.position, Target.transform.position);

        bool btn = con.ButtonPressed(button);

        // Activates if the player is close enough
        if(open == false && btn)
        {
            // Plays the animations to open the door
            anim.Play("Open");
            anim2.Play("Open_right");
            open = true;
        }

        // Activates if the door is open and the player moves away from the door
        else if(open && btn == false)
        {
            // Plays the animations to close the door
            anim.Play("Close");
            anim2.Play("Close_right");
            open = false;
        }
        
		
	}
}
