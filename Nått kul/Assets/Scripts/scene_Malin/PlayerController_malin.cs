/* **************************************************
 * Author: Malin (or Unity)
 * 
 * Set the speed and controller of the player.
 * 
 * Code review: 
 * 
 * *************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_malin : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;

    void Start()
	{
		speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		rb.AddForce (movement * speed);

	}

}