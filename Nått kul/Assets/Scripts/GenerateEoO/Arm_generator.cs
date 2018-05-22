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
	void Start ()
    {
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
<<<<<<< HEAD

=======
>>>>>>> 7872c3d46aaa4813b12daaba655e239fbdf5b3b8
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
<<<<<<< HEAD

                //Debug.Log("Arm");
                //Debug.Log("HEJ");
                if (counter < 65)
                {
                    anim.SetFloat("Direction", 1.0f);
                    counter += 1;

=======
                //Debug.Log("Arm");
                //Debug.Log("HEJ");
                if (counter < 65)
                {
                    anim.SetFloat("Direction", 1.0f);
                    counter += 1;

>>>>>>> 7872c3d46aaa4813b12daaba655e239fbdf5b3b8
                    //     RobotArmSoundManagerScript.PlaySound("robotarmModify3");


                }
                else
                {

                    anim.SetFloat("Direction", 0.0f);
                }
            }
<<<<<<< HEAD
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

=======
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
>>>>>>> 7872c3d46aaa4813b12daaba655e239fbdf5b3b8
                }
                arm.transform.Rotate(new Vector3(0, controller.GetAxis("Right", "Horizontal"), 0));

<<<<<<< HEAD
                else
                {
                    anim.SetFloat("Direction", 0.0f);
                }
            }
        }

        // play sound when rotating the robot arm. 
        if (controller.GetAxis("Right", "Horizontal") != 0)
        {
            RobotArmSoundManagerScript.PlaySound("armrotatortest1");
=======
>>>>>>> 7872c3d46aaa4813b12daaba655e239fbdf5b3b8

            }
        }
<<<<<<< HEAD
        arm.transform.Rotate(new Vector3(0, controller.GetAxis("Right", "Horizontal"), 0));

    }
	
=======
    }
>>>>>>> 7872c3d46aaa4813b12daaba655e239fbdf5b3b8

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
