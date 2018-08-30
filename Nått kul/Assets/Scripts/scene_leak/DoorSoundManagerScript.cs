using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundManagerScript : MonoBehaviour
{

    public static AudioClip doorOpen, doorClose;

    static AudioSource doorsrc;

    // Use this for initialization
    void Start()
    {
        doorOpen = Resources.Load<AudioClip>("door");
        doorClose = Resources.Load<AudioClip>("door2");

        doorsrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "door":
             doorsrc.PlayOneShot(doorOpen);             
            break;
            case "door2":
             doorsrc.PlayOneShot(doorClose);
            break;

        }
    }
}