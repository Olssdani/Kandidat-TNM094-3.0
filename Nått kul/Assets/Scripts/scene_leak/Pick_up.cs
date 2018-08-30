using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* **************************************************
 * Author: Daniel 
 * 
 * Controlls the Pick ups. It controlls if the object should be rendered
 * and changes its position if it is carried
 * 
 * Code review: 
 * 
 * *************************************************/
public class Pick_up : MonoBehaviour {
    ControllerInput controller = new ControllerInput();

    //Which pick it is
    public int nr;
    
    //Script that controll all the pick ups and leaks
    public Mission_Controller mission_controller;
    
    //True if the object is carried
    private bool IsCarried;
    private bool able_for_pickup = false;
    
    //See if it is the first time 
    private bool first_time;
    
    //The object that the pickup collid with
    GameObject player;
    
    //Time variabels
    float delta = 0;
    float start = 0;

    //String
    string button = "";

    //Orgin position
    public Vector3 origin;



    // Use this for initialization
    void Start () {
        // Get the start position
        origin = transform.position;
        //Disable the rigidbody
        GetComponent<Rigidbody>().isKinematic = true;

        IsCarried = false;
        first_time = true;
    }

	void FixedUpdate () 
	{
        //For the first frame when the pick up should show
        if (mission_controller.show(nr)&& first_time)
        {
            first_time = false;
            //Activate the rigidbody and then add a force to it
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(-15.0f, 0, 0, ForceMode.Impulse);
        }
        if(gameObject.tag == "Pick-up1"){
            button = "Button4";
        }else if(gameObject.tag == "Pick-up2")
        {
            button = "Button5";
        }
        //Only check against object that is shown
        if (mission_controller.show(nr))
        {
        //Get delta time for the wait time between pick up and dropping object
            delta = Time.time - start;
          
            //Drop object
            if (controller.ButtonPressed(button) && IsCarried && delta > 1.0f)
            {
                start = Time.time;
                IsCarried = false;
                //Bool for the player to know if it has an object
                player.GetComponent<player1_controller_leak>().has_object = false;
            }
            // Pick up object
            else if (controller.ButtonPressed(button) && !IsCarried && able_for_pickup && delta > 1.0f)
            {
                start = Time.time;
                //Makes the object follow the pre selected position
                this.gameObject.transform.position = new Vector3(player.transform.GetChild(11).position.x, player.transform.GetChild(11).position.y, player.transform.GetChild(11).position.z);
                IsCarried = true;
                player.GetComponent<player1_controller_leak>().has_object = true;
            }
            else if (IsCarried)
            {
                //Makes the object follow the player
                this.gameObject.transform.position = new Vector3(player.transform.GetChild(11).position.x, player.transform.GetChild(11).position.y, player.transform.GetChild(11).position.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks with mission that is active
        if (mission_controller.show(nr))
        {
            // Make object able for pickup
            if (other.gameObject.CompareTag("player"))
            {
             
                player = other.gameObject;
                able_for_pickup = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mission_controller.show(nr))
        {

         
            // Disable object for pick up
            if (other.gameObject.CompareTag("player"))
            {
              
                able_for_pickup = false;
            }
        }
    }
    //Gives back if the object is carried
    public bool Carried()
    {
        return IsCarried;
    }
}
