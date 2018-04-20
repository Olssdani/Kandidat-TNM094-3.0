using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {

	private ps2joystick temp = new ps2joystick();
    private Rigidbody rb;
    private Vector3 move = new Vector3(0, 0, 0);
    public  int speed = 10;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		Debug.Log (temp.GetAxis ("Vertical"));
        Debug.Log(temp.GetAxis("Horizontal"));
        move.x = temp.GetAxis("Vertical");
        move.y = 0;
        move.z = temp.GetAxis("Horizontal");

        rb.AddForce(move * speed);
    }
    
}
