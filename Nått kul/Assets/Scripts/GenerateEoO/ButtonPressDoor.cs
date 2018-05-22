using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressDoor : MonoBehaviour {
    ControllerInput controller = new ControllerInput();
    public bool nearbyWhite = false;
    public bool nearbyGreen = false;
    public bool unlockWhite = false;
    public bool unlockGreen = false;
    public bool unlocked = false;

    public GameObject cableWhite1;
    public GameObject cableGreen1;
    public GameObject cableWhite2;
    public GameObject cableGreen2;
    public GameObject buttonWhite;
    public GameObject buttonGreen;
    public GameObject loadFirstWhite;
    public GameObject loadSecondWhite;
    public GameObject loadThirdWhite;
    public GameObject loadFirstGreen;
    public GameObject loadSecondGreen;
    public GameObject loadThirdGreen;

    //materials
    public Material GlowWhite;
    public Material GlowGreen;
    public Material GlowRed;
    public Material OffRed;
    public Material Off;

    //lights
    public Light firstLightWhite;
    public Light secondLightWhite;
    public Light thirdLightWhite;
    public Light firstLightGreen;
    public Light secondLightGreen;
    public Light thirdLightGreen;
    public Light redPulse1;
    public Light redPulse2;

    private int maxDist = 30;
    private int speed = 40;

    private int counterWhite = 0;
    private int counterGreen = 0;
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && this.gameObject.CompareTag("buttonWhite"))
        {
            nearbyWhite = true;
        }

        if (col.gameObject.CompareTag("Player") && this.gameObject.CompareTag("buttonGreen"))
        {
            nearbyGreen = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && this.gameObject.CompareTag("buttonWhite"))
        {
            nearbyWhite = false;
        }
        if (col.gameObject.CompareTag("Player") && this.gameObject.CompareTag("buttonGreen"))
        {
            nearbyGreen = false;
        }

    }
	
	void Update ()
    {
        if (controller.ButtonPressed("Button2") && GameObject.Find("Inserted_Battery_Red").GetComponent<Battery_insert>().insertWhite)
        {
            cableWhite1.GetComponent<Renderer>().material = GlowWhite;
            cableWhite2.GetComponent<Renderer>().material = GlowWhite;
            
            if(!unlocked)
            {
                redPulse1.enabled = true;
                redPulse1.range = Mathf.PingPong(Time.time * speed, maxDist);
                if(redPulse1.range > 10)
                    buttonWhite.GetComponent<Renderer>().material = GlowRed;
                else
                    buttonWhite.GetComponent<Renderer>().material = OffRed;
            }



            if (controller.ButtonPressed("Button4") && nearbyWhite)
            {
                
                ++counterWhite;
                if (counterWhite > 10 && counterWhite <= 20)
                {
                    loadFirstWhite.GetComponent<Renderer>().material = GlowWhite;
                    firstLightWhite.enabled = true;
                    ButtonSoundManagerScript.PlaySound("button1Modify");
                }

                if (counterWhite > 30 && counterWhite <= 40)
                {
                    loadSecondWhite.GetComponent<Renderer>().material = GlowWhite;
                    secondLightWhite.enabled = true;
                    ButtonSoundManagerScript.PlaySound("button1Modify");
                }

                if (counterWhite > 50 && counterWhite <= 60)
                {
                    loadThirdWhite.GetComponent<Renderer>().material = GlowWhite;
                    thirdLightWhite.enabled = true;
                    ButtonSoundManagerScript.PlaySound("button1Modify");

                }
                if (counterWhite > 70)
                {
                    ButtonSoundManagerScript.PlaySound(" ");
                }
            }


            if (nearbyWhite && counterWhite > 30)
            {
                unlockWhite = true;
            }

        }
        else
        {
            cableWhite1.GetComponent<Renderer>().material = Off;
            cableWhite2.GetComponent<Renderer>().material = Off;
            buttonWhite.GetComponent<Renderer>().material = OffRed;
            redPulse1.enabled = false;
        }

        if (controller.ButtonPressed("Button1") && GameObject.Find("Inserted_Battery_Green").GetComponent<Battery_insert>().insertGreen)
        {
            cableGreen1.GetComponent<Renderer>().material = GlowGreen;
            cableGreen2.GetComponent<Renderer>().material = GlowGreen;

            if(!unlocked)
            {
                redPulse2.enabled = true;
                redPulse2.range = Mathf.PingPong(Time.time * speed, maxDist);
                if (redPulse2.range > 10)
                    buttonGreen.GetComponent<Renderer>().material = GlowRed;
                else
                    buttonGreen.GetComponent<Renderer>().material = OffRed;
            }

            if (controller.ButtonPressed("Button4") && nearbyGreen)
            {
                ++counterGreen;
                if (counterGreen > 10 && counterGreen <= 20)
                {
                    loadFirstGreen.GetComponent<Renderer>().material = GlowGreen;
                    firstLightGreen.enabled = true;
                }

                if (counterGreen > 20 && counterGreen <= 30)
                {
                    loadSecondGreen.GetComponent<Renderer>().material = GlowGreen;
                    secondLightGreen.enabled = true;
                }

                if (counterGreen > 30)
                {
                    loadThirdGreen.GetComponent<Renderer>().material = GlowGreen;
                    thirdLightGreen.enabled = true;

                }
            }

            if (nearbyGreen && counterGreen > 30)
            {
                unlockGreen = true;
            }
        }
        else
        {         
            cableGreen1.GetComponent<Renderer>().material = Off;
            cableGreen2.GetComponent<Renderer>().material = Off;    
            buttonGreen.GetComponent<Renderer>().material = OffRed;
            redPulse2.enabled = false;
        }

        if (unlockGreen && unlockWhite)
            unlocked = true;
    }
}

