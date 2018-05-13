/* **************************************************
 * Author: Malin 
 * 
 * Set the speed and controller of the player.
 * 
 * Code review: Thobias
 * 
 * *************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_controller_leak : MonoBehaviour
{
	ControllerInput controller = new ControllerInput();
	public float Verticalspeed;
	public float Horizontalspeed;
	public float MaxSpeed;
    public int PlayerNr;

    private Rigidbody rb;
    public float moveHorizontal = 0;
    public float moveVertical = 0;
    public Vector3 velocity;
    void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
        //Get movement from left joystick (AWDS)
        if (PlayerNr == 1)
        {
            moveHorizontal = controller.GetAxis("Left", "Horizontal");
            moveVertical = controller.GetAxis("Left", "Vertical");
        }else if(PlayerNr == 2)
        {
            moveHorizontal = controller.GetAxis("Right", "Horizontal");
            moveVertical = controller.GetAxis("Right", "Vertical");
        }


		//Move player facing
		if(moveHorizontal < 0 && Mathf.Abs(this.gameObject.transform.rotation.eulerAngles.y - 270) > 0.01)
		{
			this.gameObject.transform.Rotate(0,180,0);
		}else if (moveHorizontal > 0 && Mathf.Abs(this.gameObject.transform.rotation.eulerAngles.y- 90)>0.01)
		{
			this.gameObject.transform.Rotate(0, 180, 0);
		}

		Vector3 movement;

		//Caps the maximum velocity
		if(Mathf.Abs(rb.velocity[0]) > MaxSpeed && Mathf.Abs(rb.velocity[1]) > MaxSpeed)
		{
			movement = new Vector3(0.0f, 0.0f, 0.0f);
		}
		else if (Mathf.Abs(rb.velocity[0]) > MaxSpeed)
		{
			movement = new Vector3(0.0f, moveVertical * Verticalspeed, 0.0f);
		}
		else if(Mathf.Abs(rb.velocity[1]) > MaxSpeed)
		{
			movement = new Vector3(moveHorizontal * Horizontalspeed, 0.0f, 0.0f);
		}
		else
		{
			movement = new Vector3(moveHorizontal * Horizontalspeed, moveVertical * Verticalspeed, 0.0f);
		}
        //Add the force to the player
        rb.AddForce(movement);
	}
}