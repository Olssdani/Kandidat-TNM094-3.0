using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_insert : MonoBehaviour {
    public bool insert;
    GameObject other;
	public Light insertedLight;

	private ControllerInput controller = new ControllerInput();
	private Animator anim;
	public ParticleSystem sprakWhite;
	public ParticleSystem sprakGreen;
	public ParticleSystem sprakYellow;


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Battery")) 
        {
            insert = true;
            
        }

    }

    void Start () {
		
    }
	

	void Update () {
        //insert = PickUpObject;

        if (insert)
        {
            GetComponent<MeshRenderer>().enabled = true;
			insertedLight.enabled = true;

        }

		if (!(insert) && controller.ButtonPressed ("Button2")) {
			//anim.Play ("Particle-System-Thobias");
			sprakWhite.Emit(10);
		}

		if (!(insert) && controller.ButtonPressed ("Button1")) {
			//anim.Play ("Particle-System-Thobias");
			sprakGreen.Emit(10);
		}

		if (!(insert) && controller.ButtonPressed ("Button3")) {
			//anim.Play ("Particle-System-Thobias");
			sprakYellow.Emit(10);
		}
	}
}
