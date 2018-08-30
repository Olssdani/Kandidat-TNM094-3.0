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
    float time;
    float delta;

    bool soundEffect = true;

	// Use this for initialization
	void Start () {
        //Make the object don't render

    }
	
	// Update is called once per frame
	void Update () {
        mission_controller.print();
        //If mission is active, render the object
        if (mission_controller.show(nr))
        {
            leak.Play();
            //a sound effect will be played when the metal plate releases from the wall. 
            
            if(soundEffect == true)
            {
                leakSoundManagerScript.PlaySound("leak-start");
         
                // soundEffect is set to false to prevent the eound from being played more then once. 
                soundEffect = false; 

            }
           
        }
        else
        {
            leak.Stop();
            //soundEffect is set to true so that the sound can be played when the next metal plate is active. 
            soundEffect = true; 
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pick-up1"))
        {
            //If the leak has collid with the pick up and the pick isn't carried we disable the rendering
            if (mission_controller.show(nr) && controller.ButtonPressed("Button4"))
            {
                leak.Stop();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.position = other.gameObject.GetComponent<Pick_up>().origin;
                mission_controller.cleared(nr);

                // play a sound effect when the metal plate is connected to the wall.
                leakSoundManagerScript.PlaySound("leak-end");
              
            }
        }
        if (other.gameObject.CompareTag("Pick-up2"))
        {
            //If the leak has collid with the pick up and the pick isn't carried we disable the rendering
            if (mission_controller.show(nr) && controller.ButtonPressed("Button5"))
            {
                leak.Stop();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.position = other.gameObject.GetComponent<Pick_up>().origin;
                mission_controller.cleared(nr);

                // play a sound effect when the metal plate is connected to the wall.
                leakSoundManagerScript.PlaySound("leak-end");
            }
        }
    }
}
