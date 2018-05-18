using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainGenerator : MonoBehaviour {

    ControllerInput controller = new ControllerInput();
    public GameObject light_white;
    public GameObject light_green1;
    public GameObject light_green2;
    public GameObject coreMotor1;
    public GameObject coreMotor2;
    public GameObject coreLight1;
    public GameObject coreLight2;

	//materials
    public Material GlowWhite;
    public Material GlowGreen;
    public Material GlowYellow;
    public Material noGlow;

	//lights
	public Light green1Light;
	public Light whiteLight;
	public Light green2Light;
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

        if (controller.ButtonPressed("Button3") && GameObject.Find("Inserted_Battery_Blue").GetComponent<Battery_insert>().insertYellow)

        {
			if (!input1) {
				light_green1.GetComponent<Renderer>().material = GlowGreen;
				green1Light.enabled = true;
			}
         
			if (!input2) {
				light_white.GetComponent<Renderer> ().material = GlowWhite;
				whiteLight.enabled = true;
			}

			if (!input2) {
				light_green2.GetComponent<Renderer> ().material = GlowGreen;
				green2Light.enabled = true;
			}

            if (controller.ButtonPressed("Button1")) {
                input1 = true;
				green1Light.enabled = false;
				yellowFirstLight.enabled = true;
                light_green1.GetComponent<Renderer>().material = GlowYellow;
            }

            if(controller.ButtonPressed("Button2") && input1)
            {
                input2 = true;
				whiteLight.enabled = false;
				yellowSecondLight.enabled = true;
                light_white.GetComponent<Renderer>().material = GlowYellow;
            }

            if (controller.ButtonPressed("Button1") && input2)
            {
                input3 = true;
				started = true;
				green2Light.enabled = false;
				yellowThirdLight.enabled = true;
                light_green2.GetComponent<Renderer>().material = GlowYellow;
            }

            if (started)
            {
                coreLight1.GetComponent<Renderer>().material = GlowYellow;
                coreLight2.GetComponent<Renderer>().material = GlowYellow;
                generatorLight.enabled = true;
                coreMotor1.transform.Rotate(new Vector3(0, 0, 2) * speed * Time.deltaTime);
                coreMotor2.transform.Rotate(new Vector3(0, 0, -2) * speed * Time.deltaTime);
            }
        }
		else if(!started)
        {
            light_green1.GetComponent<Renderer>().material = noGlow;
            light_green2.GetComponent<Renderer>().material = noGlow;
            light_white.GetComponent<Renderer>().material = noGlow;
			green1Light.enabled = false;
			whiteLight.enabled = false;
			green2Light.enabled = false;
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
