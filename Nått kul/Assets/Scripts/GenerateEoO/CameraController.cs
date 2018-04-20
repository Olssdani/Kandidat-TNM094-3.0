using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//decide distance between camera and player transform
		offset = transform.position - player.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//move camera to align with the player object
		transform.position = player.transform.position + offset;
		transform.LookAt (player.transform);

	}

//	// The target we are following
//	public Transform target;
//	// The distance in the x-z plane to the target
//	//So this would be your offset
//	public float distance = 10.0f;
//	// the height we want the camera to be above the target
//	public float height = 5.0f;
//	// How much we 
//	public float heightDamping = 2.0f;
//	public float rotationDamping = 3.0f;
//
//	void LateUpdate () {
//		// Early out if we don't have a target
//		if (!target) return;
//
//		// Calculate the current rotation angles
//		float wantedRotationAngle = target.eulerAngles.y;
//		float wantedHeight = target.position.y + height;
//
//		float currentRotationAngle = transform.eulerAngles.y;
//		float currentHeight = transform.position.y;
//
//		// Damp the rotation around the y-axis
//		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
//
//		// Damp the height
//		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
//
//		// Convert the angle into a rotation
//		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
//
//		// Set the position of the camera on the x-z plane to:
//		// distance meters behind the target
//		transform.position = target.position;
//		transform.position -= currentRotation * Vector3.forward * distance;
//
//		// Set the height of the camera
//		transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);
//
//		// Always look at the target
//		transform.LookAt(target);
//	}


//	public Transform target;
//	public float smoothSpeed = 0.125f;
//	public Vector3 offset;
//
//	void LateUpdate() {
//
//		Vector3 desiredPosition = target.position + offset;
//		Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//		transform.position = smoothPosition;
//
//		//transform.LookAt(target);
//	}

//	public GameObject player;
//	private Vector3 offset;
//
//	private float distance;
//	private Vector3 playerPrevPos;
//	private Vector3 playerMoveDir;
//
//	void Start() {
//		offset = transform.position - player.transform.position;
//
//		distance = offset.magnitude;
//		playerPrevPos = player.transform.position;
//
//	}
//
//	void LateUpdate() {
//		playerMoveDir = player.transform.position - playerPrevPos;
//
//		if (playerMoveDir != Vector3.zero) {
//
//			playerMoveDir = Vector3.Normalize (playerMoveDir);
//			transform.position = player.transform.position - playerMoveDir * distance;
//
//			transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
//			transform.LookAt(player.transform.position);
//			playerPrevPos = player.transform.position;
//		}
//	}
}
