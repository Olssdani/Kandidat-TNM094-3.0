/* **************************************************
 * Author: Malin & Daniel
 * 
 * Set the speed and controller of the player. Controlls the animation 
 * 
 * Code review: 
 * 
 * *************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_controller_leak : MonoBehaviour
{

	ControllerInput controller = new ControllerInput();
    // Player speed vairables
    public float Verticalspeed;
	public float Horizontalspeed;
	public float MaxSpeed;
    public int PlayerNr;

    // Forces 
    public float moveHorizontal = 0;
    public float moveVertical = 0;
    Vector3 movement;
    private Rigidbody rb;

    //Animations
    private Animator ani;
    public bool has_object;
    float Idle_time; 


    void Start()
	{
		rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        //If object carries another object
        has_object = false;
        Idle_time = 0;
	}

	void FixedUpdate()
	{
        //Getting the movement from the controller depending on which player.
        if (PlayerNr == 1)
        {
            moveHorizontal = controller.GetAxis("Left", "Horizontal");
            moveVertical = controller.GetAxis("Left", "Vertical");
        }else if(PlayerNr == 2)
        {
            moveHorizontal = controller.GetAxis("Right", "Horizontal");
            moveVertical = controller.GetAxis("Right", "Vertical");
        }

        if(moveHorizontal !=0.0f || moveVertical != 0.0f)
        {
            Idle_time = Time.time;
        }
        if(Time.time- Idle_time > 5.0f)
        {
            Idle_time = Time.time;
            ani.SetBool("Idle", true);
            Invoke("SetIdleFalse", 2.5f);
        }
        //Reset the speed if it is larger than the max speed
        CapSpeed();

		//Move player facing
		if(moveHorizontal < 0 && Mathf.Abs(this.gameObject.transform.rotation.eulerAngles.y - 270) > 0.01)
		{

            this.gameObject.transform.Rotate(0,180,0);
		}else if (moveHorizontal > 0 && Mathf.Abs(this.gameObject.transform.rotation.eulerAngles.y- 90)>0.01)
		{
			this.gameObject.transform.Rotate(0, 180, 0);
		}

		
        //Add the force to the player
        rb.AddForce(movement);
	}


    void Update()
    {
        //Will show animation if it doesn't carries a object.
        if(PlayerNr ==1 &&controller.ButtonPressed("Button4") && !has_object)
        {
            ani.SetBool("play_ani", true);
            Invoke("SetAnimateFalse", 1f);
        }
        else if(PlayerNr == 2 && controller.ButtonPressed("Button5") && !has_object)
        {
            ani.SetBool("play_ani", true);
            Invoke("SetAnimateFalse", 1f);
        }
    }
    //Sets the speed dependning on the maxspeed
    void CapSpeed()
    {
        //if the speed is larger than maxspeed set the forces to zero
        if (Mathf.Abs(rb.velocity[0]) > MaxSpeed && Mathf.Abs(rb.velocity[1]) > MaxSpeed)
        {
            movement = new Vector3(0.0f, 0.0f, 0.0f);
        }
        //Cap the horizontal speed
        else if (Mathf.Abs(rb.velocity[0]) > MaxSpeed)
        {
            movement = new Vector3(0.0f, moveVertical * Verticalspeed, 0.0f);
        }
        //Cap the verticalspeed
        else if (Mathf.Abs(rb.velocity[1]) > MaxSpeed)
        {
            movement = new Vector3(moveHorizontal * Horizontalspeed, 0.0f, 0.0f);
        }
        //Set the force depending on the controller
        else
        {
            movement = new Vector3(moveHorizontal * Horizontalspeed, moveVertical * Verticalspeed, 0.0f);
        }

    }
    //Stops the animation
    void SetAnimateFalse()
    {
        ani.SetBool("play_ani", false);
      
    }

    void SetIdleFalse()
    {
        ani.SetBool("Idle", false);

    }

}