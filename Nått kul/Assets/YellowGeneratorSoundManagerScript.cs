using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGeneratorSoundManagerScript : MonoBehaviour {


    public static AudioClip empty, working;

    static AudioSource yellowgensrc;

    // Use this for initialization
    void Start()
    {
        empty = Resources.Load<AudioClip>("game_over");


        yellowgensrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "game_over":
                if (!yellowgensrc.isPlaying)
                {
                    yellowgensrc.PlayOneShot(empty);
                }
                break;
        }

    }
}
