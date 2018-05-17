using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricitytry2 : MonoBehaviour {

	public LineRenderer lRend;
	private float offsetMax = 0.8f;
	private float offsetMin = 0.2f;
	int count = 0;

	// Use this for initialization
	void Start () {
		lRend.startWidth = 0.5f;
		lRend.endWidth = 0.5f;
		lRend.positionCount = 12;
		Vector3[] hej = new Vector3[lRend.positionCount];
		float z = 1f;
		float y = 1f;
		for (int i = 0; i < hej.Length; ++i) {
			z += 1f;
			if ((i+1) % 2 == 0)
				y += 1f;
			else
				y -= 1f;


			hej [i] = new Vector3 (0, y, z);
		}
		lRend.SetPositions(hej);
		Debug.Log (hej[1]);
	}
	
	// Update is called once per frame
	void Update () {
		++count;
		if (count % 3 == 0) {
			
			lRend.endWidth = Random.Range (offsetMin, offsetMax);
			lRend.startWidth = Random.Range (offsetMin, offsetMax);
		}
		if (count % 10 == 0) {
			
		}
	}
}
