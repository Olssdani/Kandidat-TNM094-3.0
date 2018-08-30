using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leakSoundManagerScript : MonoBehaviour {

    public static AudioClip leak, nosound,start,end;

    static AudioSource leaksrc;

    // Use this for initialization
    void Start () {

        leak = Resources.Load<AudioClip>("thruster");
        nosound = Resources.Load<AudioClip>("nosound");
        start = Resources.Load<AudioClip>("leak-start");
        end = Resources.Load<AudioClip>("leak-end");

        leaksrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "leak":
                if (!leaksrc.isPlaying)
                {
                    leaksrc.PlayOneShot(leak);
          
                }
                break;
            case " ":
               
                    leaksrc.PlayOneShot(nosound);
               
                break;
            case "leak-start":
                leaksrc.PlayOneShot(start);
                break;
            case "leak-end":
                leaksrc.PlayOneShot(end);
                break; 
        }
    }
}
