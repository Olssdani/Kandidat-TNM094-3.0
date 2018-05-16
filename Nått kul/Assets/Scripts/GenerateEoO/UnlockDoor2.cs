using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor2 : MonoBehaviour {
    public GameObject door1;
    public GameObject door2;

    private Vector3 startMarker1;
    private Vector3 endMarker1;
    private Vector3 startMarker2;
    private Vector3 endMarker2;
    public float distance = 10;
    public float speed = 1.0F;

    private float startTime;
    private float endTime;
    private float perc;

    void Open()
    {
        if (startTime < endTime)
            startTime += 2 * Time.deltaTime;

        perc = startTime / endTime;
        door1.transform.position = Vector3.Lerp(startMarker1, endMarker1, perc);
        door2.transform.position = Vector3.Lerp(startMarker2, endMarker2, perc);
    }

    // Use this for initialization
    void Start () {
        startTime = 0;
        endTime = 5;

        startMarker1 = door1.transform.position;
        endMarker1 = door1.transform.position + new Vector3(0, 0, -2) * distance;
        startMarker2 = door2.transform.position;
        endMarker2 = door2.transform.position + new Vector3(0, -2, 0) * distance;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("ButtonWhite").GetComponent<ButtonPressDoor>().unlockWhite && GameObject.Find("ButtonGreen").GetComponent<ButtonPressDoor>().unlockGreen)
        {
            Open();
        }
    }
}
