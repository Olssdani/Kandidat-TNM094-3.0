﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_insert : MonoBehaviour {
    public bool insertYellow;
	public bool insertWhite;
	public bool insertGreen;
    private ControllerInput controller = new ControllerInput();
    GameObject other;
    private Animator anim;

    public Light insertedLight;
    public Light GeneratorLightWhite;
    public Light GeneratorLightGreen;
    public Light GeneratorLightYellow;

	public ParticleSystem sprakWhite;
	public ParticleSystem sprakGreen;
	public ParticleSystem sprakYellow;

    public GameObject White;
    public GameObject Green;
    public GameObject Yellow;
    public GameObject cableWhite1;
    public GameObject cableWhite2;
    public GameObject cableWhite3;
    public GameObject cableWhite4;
    public GameObject cableGreen1;
    public GameObject cableGreen2;
    public GameObject cableGreen3;
    public GameObject cableGreen4;
    public GameObject cableYellow1;
    public GameObject cableYellow2;
    public GameObject cableYellow3;
    public GameObject cableYellow4;

    public GameObject GenWhite1;
    public GameObject GenWhite2;
    public GameObject GenGreen1;
    public GameObject GenGreen2;
    public GameObject GenYellow1;
    public GameObject GenYellow2;

    public GameObject MotorWhite;
    public GameObject MotorGreen;
    public GameObject MotorYellow;

    public Material GlowWhite;
    public Material GlowGreen;
    public Material GlowYellow;
    public Material Off;

    void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.CompareTag ("BatteryYellow") && this.gameObject.CompareTag("ZoneYellow")) {
			
			insertYellow = true;
			Debug.Log ("gul");
		}
		if (col.gameObject.CompareTag ("BatteryWhite") && this.gameObject.CompareTag("ZoneWhite")) {
			insertWhite = true;
			Debug.Log ("white");
		}
		if (col.gameObject.CompareTag ("BatteryGreen") && this.gameObject.CompareTag("ZoneGreen")) {
			insertGreen = true;
			Debug.Log ("green");
		}
    }

    void Start () {
		
    }
	
	void Update () {
    
		if (insertYellow && this.gameObject.CompareTag("ZoneYellow"))
        {
            Yellow.GetComponent<MeshRenderer>().enabled = true;
			insertedLight.enabled = true;
        }

		if (insertWhite && this.gameObject.CompareTag("ZoneWhite"))
		{
			White.GetComponent<MeshRenderer>().enabled = true;
			insertedLight.enabled = true;
		}

		if (insertGreen && this.gameObject.CompareTag("ZoneGreen"))
		{
			Green.GetComponent<MeshRenderer>().enabled = true;
			insertedLight.enabled = true;
		}

        if (controller.ButtonPressed("Button2"))
        {
            if (!White.GetComponent<MeshRenderer>().enabled)
            {
                WhiteGeneratorSoundManagerScript.PlaySound("sparksModify2");
                sprakWhite.Emit(10);
                cableWhite1.GetComponent<Renderer>().material = GlowWhite;
                cableWhite2.GetComponent<Renderer>().material = GlowWhite;
            }
            else
            {
                WhiteGeneratorSoundManagerScript.PlaySound("generatorModify2");
                cableWhite1.GetComponent<Renderer>().material = GlowWhite;
                cableWhite2.GetComponent<Renderer>().material = GlowWhite;
                cableWhite3.GetComponent<Renderer>().material = GlowWhite;
                cableWhite4.GetComponent<Renderer>().material = GlowWhite;
                GenWhite1.GetComponent<Renderer>().material = GlowWhite;
                GenWhite2.GetComponent<Renderer>().material = GlowWhite;
                MotorWhite.transform.Rotate(new Vector3(0, 0, 2) *70* Time.deltaTime);
                GeneratorLightWhite.enabled = true;
            }
        }
        else
        {
            cableWhite1.GetComponent<Renderer>().material = Off;
            cableWhite2.GetComponent<Renderer>().material = Off;
            cableWhite3.GetComponent<Renderer>().material = Off;
            cableWhite4.GetComponent<Renderer>().material = Off;
            GenWhite1.GetComponent<Renderer>().material = Off;
            GenWhite2.GetComponent<Renderer>().material = Off;
            GeneratorLightWhite.enabled = false;
        } 


        if (controller.ButtonPressed ("Button1")) {

            if (!Green.GetComponent<MeshRenderer>().enabled)
            {
                GreenGeneratorSoundManagerScript.PlaySound("sparksModify2");
                sprakGreen.Emit(10);
                cableGreen1.GetComponent<Renderer>().material = GlowGreen;
                cableGreen2.GetComponent<Renderer>().material = GlowGreen;
            }
            else
            {
                GreenGeneratorSoundManagerScript.PlaySound("generatorModify2");
                cableGreen1.GetComponent<Renderer>().material = GlowGreen;
                cableGreen2.GetComponent<Renderer>().material = GlowGreen;
                cableGreen3.GetComponent<Renderer>().material = GlowGreen;
                cableGreen4.GetComponent<Renderer>().material = GlowGreen;
                GenGreen1.GetComponent<Renderer>().material = GlowGreen;
                GenGreen2.GetComponent<Renderer>().material = GlowGreen;
                MotorGreen.transform.Rotate(new Vector3(0, 0, 2) * 70 * Time.deltaTime);
                GeneratorLightGreen.enabled = true;
            }
        }
        else
        {
            cableGreen1.GetComponent<Renderer>().material = Off;
            cableGreen2.GetComponent<Renderer>().material = Off;
            cableGreen3.GetComponent<Renderer>().material = Off;
            cableGreen4.GetComponent<Renderer>().material = Off;
            GenGreen1.GetComponent<Renderer>().material = Off;
            GenGreen2.GetComponent<Renderer>().material = Off;
            GeneratorLightGreen.enabled = false;
        }

        if (!(insertYellow) && controller.ButtonPressed ("Button3")) {

            if (!Yellow.GetComponent<MeshRenderer>().enabled)
            {
                YellowGeneratorSoundManagerScript.PlaySound("sparksModify2");
                sprakYellow.Emit(10);
                cableYellow1.GetComponent<Renderer>().material = GlowYellow;
                cableYellow2.GetComponent<Renderer>().material = GlowYellow;
                
            }
            else
            {
                YellowGeneratorSoundManagerScript.PlaySound("generatorModify2");
                cableYellow1.GetComponent<Renderer>().material = GlowYellow;
                cableYellow2.GetComponent<Renderer>().material = GlowYellow;
                cableYellow3.GetComponent<Renderer>().material = GlowYellow;
                cableYellow4.GetComponent<Renderer>().material = GlowYellow;
                GenYellow1.GetComponent<Renderer>().material = GlowYellow;
                GenYellow2.GetComponent<Renderer>().material = GlowYellow;
                MotorYellow.transform.Rotate(new Vector3(0, 0, 2) * 70 * Time.deltaTime);
                GeneratorLightYellow.enabled = true;
            }
        }
        else
        {
            cableYellow1.GetComponent<Renderer>().material = Off;
            cableYellow2.GetComponent<Renderer>().material = Off;
            cableYellow3.GetComponent<Renderer>().material = Off;
            cableYellow4.GetComponent<Renderer>().material = Off;
            GenYellow1.GetComponent<Renderer>().material = Off;
            GenYellow2.GetComponent<Renderer>().material = Off;
            GeneratorLightYellow.enabled = false;
        }
    }
}
