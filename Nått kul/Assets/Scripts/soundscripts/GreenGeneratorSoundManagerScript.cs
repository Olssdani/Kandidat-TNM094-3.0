using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGeneratorSoundManagerScript : MonoBehaviour {

    public static AudioClip empty, working;

    static AudioSource greengensrc; 

	// Use this for initialization
	void Start ()
    {
        empty = Resources.Load<AudioClip>("sparksModify2");
        working = Resources.Load<AudioClip>("generatortest");

        greengensrc = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "sparksModify2":
                if (!greengensrc.isPlaying)
                {
                    greengensrc.PlayOneShot(empty);
                }
                break;
            case "generatorModify2":
                if (!greengensrc.isPlaying)
                {
                    greengensrc.PlayOneShot(working);
                }
                break;
        }
       
    }
		
	
}
