using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/* ***************************************************
 * Author: Erik Asp
 * 
 * Used in the hub to get to the other scenes. When the player
 * goes through a door the new scene will fade in with 
 * the asset Fade.
 * 
 * **************************************************/

public class EnterSpaceship: MonoBehaviour
{
    //Takes name of scene written in Unity
    public string sceneName;

    //Function with collider that uses isTrigger
	private void OnTriggerEnter(Collider other)
	{
        //Uses tag on Player model K1
		if (other.CompareTag("Player"))
        {
            //Calls Fade function that uses the scene name, color to fade in and how long the fade is going to be
            Initiate.Fade(sceneName, Color.black, 2.0f);
        }
    }

}
