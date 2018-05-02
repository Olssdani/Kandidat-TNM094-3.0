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

    // Use this for initialization
    void Start () {
        //Set rendering to false
        this.GetComponent<Renderer>().enabled = false;
        IsCarried = false;
        first_time = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (mission_controller.show(nr)&& first_time)
        {
            first_time = false;
            GetComponent<Rigidbody>().AddForce(-5.0f, 0, 0, ForceMode.Impulse);

        }
        //Only check against object that is shown
        if (mission_controller.show(nr))
        {
            //Render object and get delta time 
            delta = Time.time - start;
            this.GetComponent<Renderer>().enabled = true;

            //Drop object
            if (controller.ButtonPressed("Button4")  && IsCarried && delta>1.0f)
            {
                start = Time.time;
                IsCarried = false;
                this.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            }
            // Pick up object
            else  if (controller.ButtonPressed("Button4") && !IsCarried && able_for_pickup && delta > 1.0f)
            {
                start = Time.time;
                this.gameObject.transform.position = new Vector3(player.transform.GetChild(11).position.x, player.transform.GetChild(11).position.y, player.transform.GetChild(11).position.z);
                IsCarried = true;
                this.gameObject.GetComponent<Rigidbody>().detectCollisions= false;
            }
            else if (IsCarried)
            {
                this.gameObject.transform.position = new Vector3(player.transform.GetChild(11).position.x, player.transform.GetChild(11).position.y, player.transform.GetChild(11).position.z);
            }
        }
        else
        {
            //Don't render object
            this.GetComponent<Renderer>().enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (mission_controller.show(nr))
        {
            
            // Make object able for pickup
            if (other.gameObject.CompareTag("Player"))
              
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
            if (other.gameObject.CompareTag("Player"))
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
