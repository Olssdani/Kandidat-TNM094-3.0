using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_helper1 : MonoBehaviour {

	public int help1;

	// Use this for initialization
	void Start () {
		help1 = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter()
	{
		help1 = 1;
	}
}
