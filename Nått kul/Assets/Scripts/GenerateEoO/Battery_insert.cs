using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_insert : MonoBehaviour {
    public bool insert;
    GameObject other;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Battery")) 
        {
            insert = true;
            
        }

    }

        void Start () {

    }
	

	void Update () {
        //insert = PickUpObject;

        if (insert)
        {
            GetComponent<MeshRenderer>().enabled = true;

        }
	}
}
