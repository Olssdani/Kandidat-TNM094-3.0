using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {
    ControllerInput controller = new ControllerInput();
    public bool nearby;

	//objects
    public GameObject door1;
    public GameObject door2;
    public GameObject cableWhite1;
    public GameObject cableGreen1;
    public GameObject cableWhite2;
    public GameObject cableGreen2;
    public GameObject numpadWhite;
    public GameObject numpadGreen;
	public GameObject loadFirstRed;
	public GameObject loadSecondRed;
	public GameObject loadThirdRed;
	public GameObject loadFirstGreen;
	public GameObject loadSecondGreen;
	public GameObject loadThirdGreen;

    private Vector3 startMarker1;
    private Vector3 endMarker1;
    private Vector3 startMarker2;
    private Vector3 endMarker2;
    public float distance = 10;
    public float speed = 1.0F;
    public bool UnlockWhite;
    public bool UnlockGreen;

	//materials
    public Material GlowRed;
    public Material GlowGreen;
    public Material Off;

	//lights
	public Light firstLightRed;
	public Light secondLightRed;
	public Light thirdLightRed;
	public Light firstLightGreen;
	public Light secondLightGreen;
	public Light thirdLightGreen;

    private float startTime;
    private float endTime;
    private float perc;
	private int counterRed = 0;
	private int counterGreen = 0;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = false;
        }
    }

    void Open()
    {
        if (startTime < endTime)
            startTime += 2*Time.deltaTime;

        perc = startTime / endTime;
        door1.transform.position = Vector3.Lerp(startMarker1, endMarker1, perc);
        door2.transform.position = Vector3.Lerp(startMarker2, endMarker2, perc);
    }

    void Start () {
        startTime = 0;
        endTime = 5;
        nearby = false;

        startMarker1 = door1.transform.position;
        endMarker1 = door1.transform.position + new Vector3(0, 0, -2) * distance;
        startMarker2 = door2.transform.position;
        endMarker2 = door2.transform.position + new Vector3(0, -2, 0) * distance;
    }
	
	void Update () {
		if (controller.ButtonPressed("Button2") && GameObject.Find("Inserted_Battery_Red").GetComponent<Battery_insert>().insertWhite)
        {
            cableWhite1.GetComponent<Renderer>().material = GlowRed;
            cableWhite2.GetComponent<Renderer>().material = GlowRed;


            /*if (controller.ButtonPressed("Button4") && nearby) {
				counterRed = 0;

				//materials
				loadFirstRed.GetComponent<Renderer> ().material = TurnOffRed;
				loadSecondRed.GetComponent<Renderer> ().material = TurnOffRed;
				loadThirdRed.GetComponent<Renderer> ().material = TurnOffRed;

				//lights
				firstLightRed.enabled = false;
				secondLightRed.enabled = false;
				thirdLightRed.enabled = false;
			} */

            if (controller.ButtonPressed("Button4") && nearby) {
				++counterRed;
				if (counterRed > 10 && counterRed <= 20) {
					loadFirstRed.GetComponent<Renderer> ().material = GlowRed;
					firstLightRed.enabled = true;

				}

				if (counterRed > 20 && counterRed <= 30) {
					loadSecondRed.GetComponent<Renderer> ().material = GlowRed;
					secondLightRed.enabled = true;
				}

				if (counterRed > 30) {
					loadThirdRed.GetComponent<Renderer> ().material = GlowRed;
					thirdLightRed.enabled = true;

				}
			}
				

			if (nearby && counterRed > 30)
            {
                UnlockWhite = true;
            }

        }
		else if (controller.ButtonPressed("Button1") && GameObject.Find("Inserted_Battery_Green").GetComponent<Battery_insert>().insertGreen)
        {
            cableGreen1.GetComponent<Renderer>().material = GlowGreen;
            cableGreen2.GetComponent<Renderer>().material = GlowGreen;

            /*if (controller.ButtonPressed("Button4") && nearby) {
				counterGreen = 0;

				//materials
				loadFirstGreen.GetComponent<Renderer> ().material = TurnOffGreen;
				loadSecondGreen.GetComponent<Renderer> ().material = TurnOffGreen;
				loadThirdGreen.GetComponent<Renderer> ().material = TurnOffGreen;

				//lights
				firstLightGreen.enabled = false;
				secondLightGreen.enabled = false;
				thirdLightGreen.enabled = false;
			} */

            if (controller.ButtonPressed("Button4") && nearby) {
				++counterGreen;
				if (counterGreen > 10 && counterGreen <= 20) {
					loadFirstGreen.GetComponent<Renderer> ().material = GlowGreen;
					firstLightGreen.enabled = true;
				}

				if (counterGreen > 20 && counterGreen <= 30) {
					loadSecondGreen.GetComponent<Renderer> ().material = GlowGreen;
					secondLightGreen.enabled = true;
				}

				if (counterGreen > 30) {
					loadThirdGreen.GetComponent<Renderer> ().material = GlowGreen;
					thirdLightGreen.enabled = true;

				}
			}

			if (nearby && counterGreen > 30)
            {
                UnlockGreen = true;
            }
        }
        else
        {
            cableWhite1.GetComponent<Renderer>().material = Off;
            cableWhite2.GetComponent<Renderer>().material = Off;
            cableGreen1.GetComponent<Renderer>().material = Off;
            cableGreen2.GetComponent<Renderer>().material = Off;
        }

        
        if (UnlockWhite && UnlockGreen)
        {
            Open();
        }      
    }
		
}
