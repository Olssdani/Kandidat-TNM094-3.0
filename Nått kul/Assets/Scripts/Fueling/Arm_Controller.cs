using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Controller : MonoBehaviour {
    /*****************************************************
    ********************Variable definitions**************
    ******************************************************/
    //Controller class
    private ControllerInput controller = new ControllerInput();
    //If the arm is a hydrogen or oxygen arm.
    public string type;
    //Robotarm and animation
    public GameObject arm;
    private Animator anim;
    public int counter;
   
    
    /*****************************************************
    ****************Functions implementation**************
    * ****************************************************/

    //Initialation of variables
    void Start () {
        anim = arm.GetComponent<Animator>();
        anim.Play("Robot Arm");
        anim.SetFloat("Direction", 0.0f);
        counter = 0;
        //Start button light.
        controller.Change_Light(true, 1);
    }
	
	// Update is called once per frame. Checks for inputs.
	void FixedUpdate () {
        //Rotate and extend arm
        if (type == "Hydrogen")
        {
            Movement("Left", 355, 185);
        }
        else if(type == "Oxygen")
        {
            Movement("Right", 175, 5);
        }
        //If escape is pressed then the startscene appears
        if (Input.GetKey("escape"))
        {
            Initiate.Fade("start_scene", Color.black, 2.0f);
        }
            
    }
    //Extend and rotates the arm.
    void Movement(string name, int max, int min)
    {
        //Extend arm 
        if (controller.GetAxis(name, "Vertical") > 0)
        {
            anim.Play("Robot Arm");
            if (counter < 120)
            {
                anim.SetFloat("Direction", 1.0f);
                counter += 1;
            }
            else
            {
                anim.SetFloat("Direction", 0.0f);
            }
        }
        else
        {
            if (counter > 0)
            {
                anim.SetFloat("Direction", -1.0f);
                counter -= 1;
            }
            else
            {
                anim.SetFloat("Direction", 0.0f);
            }
        }

        //Rotate arm
        if (!(arm.transform.rotation.eulerAngles.y > max && controller.GetAxis(name, "Horizontal") > 0) &&
            !(arm.transform.rotation.eulerAngles.y < min && controller.GetAxis(name, "Horizontal") < 0) && counter ==0)
        {
            counter = 0;
            arm.transform.Rotate(new Vector3(0, controller.GetAxis(name, "Horizontal"), 0));
        }
    }
    
    //Looks for colissions
    void OnTriggerStay(Collider other)
    {
        //Check if the collid is with the tube
        if (other.gameObject.CompareTag("Tube"))
       {
            //Makes the animation stop 
            if (controller.GetAxis("Left", "Vertical") > 0)
            {
                anim.SetFloat("Direction", 0);
                counter -= 1;
            } 
        }
    }
}
