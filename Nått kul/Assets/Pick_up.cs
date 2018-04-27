using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_up : MonoBehaviour {
    public int nr;
    public Mission_Controller mission_controller;
    ControllerInput controller = new ControllerInput();
    private bool carried;
    private bool able_for_pickup = false;

    // Use this for initialization
    void Start () {
        this.GetComponent<Renderer>().enabled = false;
        carried = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (mission_controller.show(nr))
        {
            this.GetComponent<Renderer>().enabled = true;

            if (controller.ButtonPressed("Button2")  && carried)
            {
                this.gameObject.transform.parent = null;
                carried = false;
            }
            else 
            {
                if (controller.ButtonPressed("Button2"))
                {
                    //this.gameObject.transform.parent;
                    carried = true;
                }
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mission_controller.show(nr))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                able_for_pickup = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mission_controller.show(nr))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                able_for_pickup = false;
            }
        }
    }
}
