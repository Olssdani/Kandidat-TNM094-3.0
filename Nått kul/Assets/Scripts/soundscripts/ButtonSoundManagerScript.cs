using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManagerScript : MonoBehaviour {

    public static AudioClip pressed;

    static AudioSource buttonsrc;

    // Use this for initialization
    void Start()
    {
        pressed = Resources.Load<AudioClip>("button1Modify");


        buttonsrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "button1Modify":
                if (!buttonsrc.isPlaying)
                {
                    buttonsrc.PlayOneShot(pressed);
                }

                break;
            case " ":
                break;
        }
    }
}
