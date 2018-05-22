using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* **************************************************
 * Author: Daniel 
 * 
 * Controlls the missions and check if the level is completed
 * 
 * Code review:
 * 
 * *************************************************/
public class Mission_Controller : MonoBehaviour {
    bool[] objectiv = new bool[4] { false, false, false, false };
    bool[] mission_completed = new bool[4] { false, false, false, false };
    public Canvas win;
    float time =0;
    float delta = 0;
     // Use this for initialization
    void Start () {
        objectiv[0] = true;
        win.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(mission_completed[0] && mission_completed[1]&& mission_completed[2] && mission_completed[3])
        {
            win.enabled = true;
            if(time == 0)
            {
                time = Time.time;
            }
            delta = Time.time - time;
            if(delta > 5.0)
            {
                Initiate.Fade("start_scene", Color.black, 2.0f);
            }

        }
	}

    //Gives back if the object should be showing
    public bool show(int nr)
    {
        return objectiv[nr];
    }

    //Changes objectiv and set new objectib
    public void cleared(int nr)
    {
        //Set mission as completed
        mission_completed[nr] = true;
        objectiv[nr] = false;

        if (nr+1 < objectiv.Length)
        {
            objectiv[nr + 1] = true;
        }
    }

    public void print()
    {
      
    }
}
