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


	/*****************************************************
    ****************Functions implementation**************
    * ****************************************************/

	//Initialation of variables
	void Start () {
		anim = arm.GetComponent<Animator>();
		anim.Play("Grab");
		anim.SetFloat("Direction", 0.0f);
		counter = 0;
		//Start button light.
		controller.Change_Light(true, 1);
	}

	// Update is called once per frame. Checks for inputs.
	void FixedUpdate () {
		//Rotate and extend arm

		if (controller.GetAxis("Right", "Vertical") > 0)
		{
			anim.Play("Grab");
			if (counter < 65)
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
//		if (!(arm.transform.rotation.eulerAngles.y > 360 && controller.GetAxis("Right", "Horizontal") > 0) &&
//			!(arm.transform.rotation.eulerAngles.y < 0 && controller.GetAxis("Right", "Horizontal") < 0) && counter ==0)
//		{
//			counter = 0;
			arm.transform.Rotate(new Vector3(0, controller.GetAxis("Right", "Horizontal"), 0));
//		}

	}

	//Looks for colissions
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Hellooo");
		//Check if the collid is with the tube
		if (other.gameObject.CompareTag("Battery"))
		{
			//Makes the animation stop 

		}
	}
}
