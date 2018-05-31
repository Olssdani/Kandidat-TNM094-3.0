using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGeneratorManagerScript : MonoBehaviour {

    public static AudioClip working;

    static AudioSource maingensrc;


    // Use this for initialization
    void Start() {

        working = Resources.Load<AudioClip>("maingenerator");

        maingensrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "maingenerator":
                if (!maingensrc.isPlaying)
                {
                    maingensrc.PlayOneShot(working);
                }
                break; 
        }
    }

}
