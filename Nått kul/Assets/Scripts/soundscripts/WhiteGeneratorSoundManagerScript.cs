using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteGeneratorSoundManagerScript : MonoBehaviour {


    public static AudioClip empty, working;

    static AudioSource whitegensrc;

    // Use this for initialization
    void Start()
    {
        empty = Resources.Load<AudioClip>("sparksModify2");
        working = Resources.Load<AudioClip>("generatortest");
        
        whitegensrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sparksModify2":
                if (!whitegensrc.isPlaying)
                {
                    whitegensrc.PlayOneShot(empty);
                }
               
                break;
            case "generatorModify2":
                if (!whitegensrc.isPlaying)
                {
                    whitegensrc.PlayOneShot(working);
                }
                break;
        }

    }
 
}
