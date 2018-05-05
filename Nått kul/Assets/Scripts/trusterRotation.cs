using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trusterRotation : MonoBehaviour {

    ControllerInput dit = new ControllerInput();
    ParticleSystem.EmissionModule emissionModule;

    public GameObject thruster;
    private Animator anim;
    public int counter;

    // Use this for initialization
    void Start () {

         ParticleSystem particle = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
         anim = thruster.GetComponent<Animator>();

         particle.enableEmission = false;
         emissionModule = particle.emission;
      
        anim.Play("rotateThruster");
        anim.SetFloat("direction", 1.0f);
    }
  
    // Update is called once per frame
    void FixedUpdate () {


        ParticleSystem particle = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
       
       
        particle.enableEmission = true; // "turn on" particle system
        
        if (dit.GetAxis("Left", "Vertical") > 0)
        {
            // "increase the power of the thruseter" 
            emissionModule.rate = 999; // increase number of particles 
            particle.startSpeed = 4; // increase the velocity of the particles 

            // counter used for ending the animation
            if (counter < 15)
            {
                anim.SetFloat("direction", 1.0f);
                counter += 1;
            }
            else
            {
                anim.SetFloat("direction", 0.0f);
            }
        }
        else
        {
            emissionModule.rate = 100;
            particle.startSpeed = 3;

            if (counter > 0)
            {
                anim.SetFloat("direction", -1.0f);
                counter -= 1;
            }
            else
            {
                anim.SetFloat("direction", 0.0f);
            }
        }
    }
}
