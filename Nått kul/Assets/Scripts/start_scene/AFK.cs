using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AFK : MonoBehaviour {

    float time, stopTime;

	void Start () {
        stopTime = 0;
	}
	
	void Update () {
        time = Time.realtimeSinceStartup - stopTime;

        if(Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            stopTime = Time.realtimeSinceStartup;
        }

        if(time >= 60.0f)
        {
            Initiate.Fade("start_scene", Color.black, 2.0f);
        }

	}
}