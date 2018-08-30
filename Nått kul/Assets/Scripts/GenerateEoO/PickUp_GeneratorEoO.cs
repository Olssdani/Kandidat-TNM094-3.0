using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ***************************************************
 * Author: Oliver Johansson (Daniel Olsson)
 * 
 * Used for picking up objects, attach this script to the object
 * to make it able to pick up by the player. 
 * 
 * **************************************************/

public class PickUp_GeneratorEoO : MonoBehaviour {

    ControllerInput controller = new ControllerInput();
    public Transform player;
    private Rigidbody rb;

    public bool hasPlayer = false;
    bool IsCarried = false;
    public bool inserted = false;

    private Vector3 playerPos;
    private Vector3 playerDirection;
    private Vector3 carryPos;

	//time
	float start = 0f;
	float delta = 0f;

    void OnTriggerEnter(Collider other)
    {

        // If the player is at the object it can pick it up
        if (other.gameObject.CompareTag("Player")) //will only work if the Player has it's tag set to Player in Unity!!!!!!
        {
            Debug.Log("Nearby");
            hasPlayer = true;
        }

        if (other.gameObject.CompareTag("ZoneYellow") && this.gameObject.CompareTag("BatteryYellow"))// Not mine
        {
            inserted = true;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("ZoneWhite") && this.gameObject.CompareTag("BatteryWhite"))// Not mine
        {
            inserted = true;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("ZoneGreen") && this.gameObject.CompareTag("BatteryGreen"))// Not mine
        {
            inserted = true;
            Destroy(gameObject);
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        IsCarried = false;
        playerPos = player.transform.position;
        playerDirection = player.transform.forward;
    }
	
	
	void Update ()
    {
		delta = Time.time - start;

        //Drop object
		if (controller.ButtonPressed("Button4") && IsCarried && delta > 1.0f)
        {
			start = Time.time;
            IsCarried = false;
            transform.parent = null;
            rb.isKinematic = true;
        }
        // Pick up object
		else if (controller.ButtonPressed("Button4") && !IsCarried && hasPlayer && delta > 1.0f)
        {
            WhiteBatterySoundManagerScript.PlaySound("pick");
            Debug.Log("Carried");
			start = Time.time;
            //use setParent
            this.gameObject.transform.SetParent(player);
            this.gameObject.transform.position = new Vector3(5,5,5);
            IsCarried = true;

        }
        else if (IsCarried)
        {
            this.gameObject.transform.position = new Vector3(player.transform.GetChild(11).position.x, player.transform.GetChild(11).position.y, player.transform.GetChild(11).position.z);
        }
    }
}
