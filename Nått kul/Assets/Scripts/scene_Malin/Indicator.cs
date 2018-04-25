using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        // If a mission and a pick-up is colliding
        if (other.gameObject.CompareTag("Pick-up"))
        {
            col_mis_pick = true;
        }
    }
}
