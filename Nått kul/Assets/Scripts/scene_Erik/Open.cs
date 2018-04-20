using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    private Rigidbody rb;

    void Start()
    {
       // startPosition = GameObject.Find("Hinder").transform.position;
        rb = GetComponent<Rigidbody>();

    }


    void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0.0f, 100.0f, 0.0f));
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0.0f, -200.0f, 0.0f));
        }
	}
}
