using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_generator : MonoBehaviour {

	/*****************************************************
    ********************Variable definitions**************
    ******************************************************/
	//Controller class
	private ControllerInput controller = new ControllerInput();
	//Robotarm and animation
	public GameObject arm;
	public GameObject battery;
	private Animator anim;
	public int counter;
    private bool playSound = true;
    private bool reverseSound = true; 

	/*****************************************************
    ****************Functions implementation**************
    * ****************************************************/

	//Initialation of variables
	void Start () {
		anim = arm.GetComponent<Animator>();
		anim.Play("MoveArm");
		anim.SetFloat("Direction", 0.0f);
		counter = 0;
		//Start button light.
		controller.Change_Light(true, 1);

      
	}

    // Update is called once per frame. Checks for inputs.
    void FixedUpdate()
    {
        //Rotate and extend arm
        if (controller.GetAxis("Right", "Vertical") > 0)
        {
            reverseSound = true;
            anim.Play("Grab");
            if (playSound == true)
            {
                RobotArmSoundManagerScript.PlaySound("robotarmModify3");
                playSound = false;
            }

            if (counter < 65)
            {
                anim.SetFloat("Direction", 1.0f);
                //Debug.Log("Arm");
                //Debug.Log("HEJ");
                if (counter < 65)
                {
                    anim.SetFloat("Direction", 1.0f);
                    counter += 1;

                    //     RobotArmSoundManagerScript.PlaySound("robotarmModify3");


                }
                else
                {

                    anim.SetFloat("Direction", 0.0f);
                }
            }
            else
            {
                playSound = true;

                if (counter > 0)
                {
                    if (counter > 1)
                    {

                        anim.SetFloat("Direction", -1.0f);
                        counter -= 1;
                        if (reverseSound == true)
                        {
                            RobotArmSoundManagerScript.PlaySound("robotarmModify3reverse");
                            reverseSound = false;
                        }

                    }

                    else
                    {
                        anim.SetFloat("Direction", 0.0f);
                    }
                }
                // play sound when rotating the robot arm. 
                if (controller.GetAxis("Right", "Horizontal") != 0)
                {
                    RobotArmSoundManagerScript.PlaySound("armrotatortest1");

                    if (controller.GetAxis("Right", "Horizontal") == 0)
                    {
                        RobotArmSoundManagerScript.PlaySound(" ");
                    }
                }
                arm.transform.Rotate(new Vector3(0, controller.GetAxis("Right", "Horizontal"), 0));


            }
        }
    }

	//Looks for colissions
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Hellooo");
		//Check if the collid is with the tube
		if (other.gameObject.CompareTag("BatteryYellow"))
		{
			//Makes the animation stop 

		}
	}
}
