using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_MoveController : MonoBehaviour {
    public float speed;
    private ControllerInput controller = new ControllerInput();
    private Rigidbody rb;
    

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void Update () {
		float moveHorizontal = controller.GetAxis("Right", "Horizontal");
        float moveVertical = controller.GetAxis("Right","Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

		//transform.Translate (speed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0.0f, speed * Input.GetAxis ("Vertical") * Time.deltaTime);


    }
}
