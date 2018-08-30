using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {
    ControllerInput controller = new ControllerInput();

    public Material[] material;
    Renderer rend;

    //Leak number
    public int nr;
    //script that controll all the pick ups and leaks 
    public Mission_Controller mission_controller;
    float time;
    float delta;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update () {
        mission_controller.print(); 

        if(mission_controller.show(nr))
        {
            rend.sharedMaterial = material[1];
             
        }
        else
        {
            rend.sharedMaterial = material[0];
           
        }
		
	}

   
}
