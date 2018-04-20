/* ****************************************************
 * Author: Malin
 * 
 * NOT DONE! Ser förjävligt ut.
 * 
 * 
 * ***************************************************/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_malin : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	private Vector2 posX;
	private Vector2 posY;

	private Vector3 startPos;

	private float cameraX;
	private float cameraY;


	void Start () {

		offset = transform.position - player.transform.position;

		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {

		transform.position = player.transform.position + offset;

		cameraX = Mathf.Clamp (transform.position.x, startPos.x, 13.4f);
		cameraY = Mathf.Clamp (transform.position.y, startPos.y, 40.6f);

		transform.position = new Vector3(cameraX, cameraY, transform.position.z);



	}
}

