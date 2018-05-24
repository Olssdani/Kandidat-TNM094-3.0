using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGeneratorSoundManagerScript : MonoBehaviour {

    public static AudioClip empty, working;

    static AudioSource yellowgensrc;

    // Use this for initialization
    void Start()
    {
        empty = Resources.Load<AudioClip>("sparksModify2");
        working = Resources.Load<AudioClip>("generatortest");

        yellowgensrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sparksModify2":
                if (!yellowgensrc.isPlaying)
                {
                    yellowgensrc.PlayOneShot(empty);
                }
                break;
            case "generatorModify2":
                if (!yellowgensrc.isPlaying)
                {
                    yellowgensrc.PlayOneShot(working);
                }
                break;
        }

    }
}
