using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AFK : MonoBehaviour {

    ControllerInput controller = new ControllerInput();
    float time, stopTime;

	void Start () {
        stopTime = 0.0f;
	}
	
	void Update () {
        time = Time.realtimeSinceStartup - stopTime;

        if(controller.GetAxis("Left", "Horizontal") != 0.0f || controller.GetAxis("Left","Vertical") != 0.0f)
        {
            stopTime = Time.realtimeSinceStartup;
        }

        if(time >= 60.0f)
        {
            stopTime = 0.0f;
            Initiate.Fade("start_scene", Color.black, 2.0f);
        }
	}
}