using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBatterySoundManagerScript : MonoBehaviour
{

    public static AudioClip picked, dropped;

    static AudioSource batterysrc;

    // Use this for initialization
    void Start()
    {
        picked = Resources.Load<AudioClip>("magneticpickup");
        dropped = Resources.Load<AudioClip>("magneticdrop");


        batterysrc = GetComponent<AudioSource>();
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
                if (!batterysrc.isPlaying)
                {
                    batterysrc.PlayOneShot(picked);
                }
                break;
            case "drop":
                if (!batterysrc.isPlaying)
                {
                    batterysrc.PlayOneShot(dropped);
                }
                break;
            case " ":
                break;
        }
    }
}