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
public class Indicator : MonoBehaviour {
    ControllerInput controller = new ControllerInput();

    public ParticleSystem leak;
    //Leak number
    public int nr;
    //Script that controll all the pick ups and leaks
    public Mission_Controller mission_controller;
	// Use this for initialization
	void Start () {
        //Make the object don't render
        this.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        //If mission is active, render the object
        if (mission_controller.show(nr))
        {
            leak.Play();
            //hide oject
            //this.GetComponent<Renderer>().enabled = true;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pick-up"))
        {
            //If the leak has collid with the pick up and the pick isn't carried we disable the rendering
            //if (mission_controller.show(nr) && !other.gameObject.GetComponent<Pick_up>().Carried())
            if (mission_controller.show(nr) && other.gameObject.GetComponent<Pick_up>().Carried() && controller.ButtonPressed("Button3"))
            {
                Debug.Log("Cleared " + nr);
                mission_controller.cleared(nr);
                leak.Stop();
                //this.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
