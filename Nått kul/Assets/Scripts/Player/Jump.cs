using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    private Rigidbody rb;

    public bool isGrounded;

    void Start () {
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.M) && isGrounded)
        {
            rb.AddForce(new Vector3(0.0f, 300.0f, 0.0f));
            isGrounded = false;
        }

    }
}
