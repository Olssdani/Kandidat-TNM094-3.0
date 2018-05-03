using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainGenerator : MonoBehaviour {

    ControllerInput controller = new ControllerInput();
    public GameObject light_red;
    public GameObject light_green;
    public GameObject light_blue;
    public GameObject coreMotor1;
    public GameObject coreMotor2;
    public GameObject coreLight1;
    public GameObject coreLight2;

	//materials
    public Material GlowRed;
    public Material GlowGreen;
    public Material GlowBlue;
    public Material GlowYellow;
    public Material noGlow;

	//lights
	public Light redLight;
	public Light greenLight;
	public Light blueLight;
	public Light yellowFirstLight;
	public Light yellowSecondLight;
	public Light yellowThirdLight;
	public Light generatorLight;

    public int speed;
    private bool input1;
    private bool input2;
    private bool input3;
	private bool started;




    void Start () {
        input1 = input2 = input3 = started = false;
	}


    void Update()
    {
        if (controller.ButtonPressed("Button4") && GameObject.Find("Inserted_Battery_Blue").GetComponent<Battery_insert>().insertYellow)
        {
			if (!input1) {
				light_red.GetComponent<Renderer>().material = GlowRed;
				redLight.enabled = true;
			}
         
			if (!input2) {
				light_green.GetComponent<Renderer> ().material = GlowGreen;
				greenLight.enabled = true;
			}

			if (!input2) {
				light_blue.GetComponent<Renderer> ().material = GlowBlue;
				blueLight.enabled = true;
			}

            if (controller.ButtonPressed("Button1")) {
                input1 = true;
				redLight.enabled = false;
				yellowFirstLight.enabled = true;
                light_red.GetComponent<Renderer>().material = GlowYellow;
            }

            if(controller.ButtonPressed("Button2") && input1)
            {
                input2 = true;
				greenLight.enabled = false;
				yellowSecondLight.enabled = true;
                light_green.GetComponent<Renderer>().material = GlowYellow;
            }
            else if ((controller.ButtonPressed("Button3")) && input1 && !input2)
            {
				yellowFirstLight.enabled = false;
				redLight.enabled = true;
                input1 = false;
            } 

            if (controller.ButtonPressed("Button3") && input1)
            {
                input3 = true;
				started = true;
				blueLight.enabled = false;
				yellowThirdLight.enabled = true;
                light_blue.GetComponent<Renderer>().material = GlowYellow;
            }   
        }
		else if(!started)
        {
            light_red.GetComponent<Renderer>().material = noGlow;
            light_green.GetComponent<Renderer>().material = noGlow;
            light_blue.GetComponent<Renderer>().material = noGlow;
			redLight.enabled = false;
			blueLight.enabled = false;
			greenLight.enabled = false;
			yellowFirstLight.enabled = false;
			yellowSecondLight.enabled = false;
			yellowThirdLight.enabled = false;
            input1 = input2 = false;
        }
        else
        {
            coreLight1.GetComponent<Renderer>().material = GlowYellow;
            coreLight2.GetComponent<Renderer>().material = GlowYellow;
			generatorLight.enabled = true;
            coreMotor1.transform.Rotate(new Vector3(0, 0, 2) * speed * Time.deltaTime);
            coreMotor2.transform.Rotate(new Vector3(0, 0, -2) * speed * Time.deltaTime);
        }
    }
    
}
