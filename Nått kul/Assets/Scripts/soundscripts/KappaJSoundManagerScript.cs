using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KappaJSoundManagerScript : MonoBehaviour
{

    public static AudioClip move, grab, quitSound, walk1, walk2, walk3, pickup;

    static AudioSource kappaSrc;

    

    // Use this for initialization
    void Start()
    {

        grab = Resources.Load<AudioClip>("magneticpickup");
        quitSound = Resources.Load<AudioClip>("nosound");
        pickup = Resources.Load<AudioClip>("winner");
        walk1 = Resources.Load<AudioClip>("kappaJwalk1");
        walk2 = Resources.Load<AudioClip>("kappaJwalk2");
        walk3 = Resources.Load<AudioClip>("kappaJwalk3");
        kappaSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
            { 
               case "pick":
                    if (!kappaSrc.isPlaying)
                    {
                        // audioSrc.Play();
                        kappaSrc.PlayOneShot(grab);
                    }
                break; 

              case "kappaJwalk1":
                   var number = Random.Range(1, 4);
                   if (!kappaSrc.isPlaying)    
                   {
                       Debug.Log(number);
                       switch(number)
                       {
                           case 1:
                               kappaSrc.PlayOneShot(walk1);

                               break;
                           case 2:
                               kappaSrc.PlayOneShot(walk2);
                               break;
                           case 3:
                               kappaSrc.PlayOneShot(walk3);
                               break;
                       }

                   }
                   break;
     
            case " ":
              
                    break;
        }
        
      }
      /*
    public static void Pickup(string clip)
    {
        switch (clip)
        {
            case "ready":
                if (!kappaSrc.isPlaying)
                {
                    // audioSrc.Play();
                    kappaSrc.PlayOneShot(grab);
                }
                break;
        }
    }
    public static void Moving(string clip)
    {
        switch (clip)
        {
            case "kappaJwalk1":
                var number = Random.Range(1, 4);
                if (!kappaSrc.isPlaying)
                {
                    Debug.Log(number);
                    switch (number)
                    {
                        case 1:
                            kappaSrc.PlayOneShot(walk1);

                            break;
                        case 2:
                            kappaSrc.PlayOneShot(walk2);
                            break;
                        case 3:
                            kappaSrc.PlayOneShot(walk3);
                            break;
                    }

                }
                break;
        }
    }
    */

}

