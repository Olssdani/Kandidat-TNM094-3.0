using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmSoundManagerScript : MonoBehaviour
{

    public static AudioClip robotArmRotate, robotArmUp, robotArmDown, quitSound, grab;

    static AudioSource robotArmSrc;

    // Use this for initialization
    void Start()
    {

        robotArmUp = Resources.Load<AudioClip>("robotarmModify3");
        robotArmDown = Resources.Load<AudioClip>("robotarmModify3reverse");
        robotArmRotate = Resources.Load<AudioClip>("armrotatortest1");
        grab = Resources.Load<AudioClip>("robotarmgrab");

        robotArmSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "robotarmModify3":
                if (!robotArmSrc.isPlaying)
                {
                    robotArmSrc.PlayOneShot(robotArmUp);
                }
                break;
            case "robotarmModify3reverse":
                if (!robotArmSrc.isPlaying)
                {
                    robotArmSrc.PlayOneShot(robotArmDown);
                }
                break;
            case "armrotatortest1":
                if (!robotArmSrc.isPlaying)
                {
                    robotArmSrc.PlayOneShot(robotArmRotate);
                }
                break;
            case "grab":
                if (!robotArmSrc.isPlaying)
                {
                    robotArmSrc.PlayOneShot(grab);
                }
                break;
            case " ":
                break; 


        }
    }
}

