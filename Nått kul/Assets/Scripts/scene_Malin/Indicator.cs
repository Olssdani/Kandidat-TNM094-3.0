using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {

    public int nr;
    public Mission_Controller mission_controller;
	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (mission_controller.show(nr))
        {
            this.GetComponent<Renderer>().enabled = true;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        // If a mission and a pick-up is colliding
        if (other.gameObject.CompareTag("Pick-up"))
        {
            if (mission_controller.show(nr))
            {
                mission_controller.cleared(nr);
                this.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
