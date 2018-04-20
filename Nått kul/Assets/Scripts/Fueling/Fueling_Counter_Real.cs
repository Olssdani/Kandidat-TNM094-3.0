//Author: Daniel Olsson
//
//
//
//
//Code review by:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter_Real : MonoBehaviour
{
    /*****************************************************
    ********************Variable definitions**************
    * ****************************************************/
    //Controller object
    ControllerInput controller = new ControllerInput();

    //Script that keep track of all pipes
    public Arm_Communication check;
    
    //Variables for the fuel
    public int Start_amount;
	private int count;
	private int max_amount = 1000;
    public ParticleSystem fluid;
    public GameObject fuel;
    public Light warning;
    private float Fluidmin = 0;
    private float Fluidmax = 6.25f;

    /*****************************************************
    ****************Functions implementation**************
    * ****************************************************/
    
    //Initialation of variables
    void Start()
    {
        count = Start_amount;
        fluid.Stop();
		fuel.transform.localScale += new Vector3 (0, (Fluidmax - Fluidmin)*count / max_amount, 0);
    }
    //Looks for continous collision with the pipe and the arm.
    void OnTriggerStay(Collider other)
    {
        //Checks if the pipe has collid with the fueling arm.
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            //Get the root object of the robotarm.
            Arm_Controller playerScript = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            //Checks if both arms is in a pipe and that the fueling button is pressed.
            if (check.Ready() && controller.ButtonPressed("Button1") && playerScript.counter == 120 ) {
				if (count != max_amount)
                {
					fluid.Play ();
					count += 1;
					fuel.transform.localScale += new Vector3 (0, (Fluidmax - Fluidmin) / max_amount, 0);
				} 
			} else {
				fluid.Stop();
			}
        }
    }
    //Looks for the first collision between the arm and pipe
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            //Set the check variable for a type to false
            Arm_Controller Script = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            check.SetBool(Script.type, true);
        }
    }
    //Looks for the exit trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            //Set the check variable for a type to false
            Arm_Controller Script = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            check.SetBool(Script.type, false);
        }
    }
    //Update every frame
    private void Update()
    {
        //Check if fuel is full
		if (count == max_amount)
        {
            float start = Time.time;
            warning.intensity = 1;
        }
		check.update_fuel_counter (this.gameObject.name, count);
    }
}
