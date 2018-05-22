using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    private ControllerInput controller = new ControllerInput();
    public GameObject claw;
    private Animator anim;
    public GameObject arm;

    void Start () {
        anim = claw.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position = new Vector3(arm.transform.GetChild(0).position.x, arm.transform.GetChild(0).position.y, arm.transform.GetChild(0).position.z);

        if (controller.ButtonPressed("Button5"))
        {
            Debug.Log("trigger");
            anim.SetTrigger("Grab");
            RobotArmSoundManagerScript.PlaySound("grab");
        }
	}
}
