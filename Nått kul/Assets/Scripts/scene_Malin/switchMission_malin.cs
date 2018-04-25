/* **************************************************
 * Author: Malin 
 * 
 * This script switch the mission that is showing. 
 * You switch mission by picking up a pick-up and 
 * releasing the pick-up one the mission and then 
 * pressing the 'D' key. 
 * 
 * 
 * Code Review: Thobias
 * 
 * 
 * 
 * P.S. Jag fattar inte varför toggle-grejen inte funkar.
 * För den switchar lite olika mission och jag fattar inte varför. 
 * Kanske för att den ligger på flera objekt samtidigt. 
 * *************************************************/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchMission_malin : MonoBehaviour {

	public GameObject mission1;
	public GameObject mission2;
	public GameObject mission3;
	public GameObject mission4;

	public GameObject pickup1;
	public GameObject pickup2;
	public GameObject pickup3;
	public GameObject pickup4;

	public Text winner;

	private Vector3 firstpos1;
	private Vector3 firstpos2;
	private Vector3 firstpos3;
	private Vector3 firstpos4;

	private int toggler;

	private bool col_mis_pick;

	private bool carried;


	void Start () 
	{
		// Get the initial posistions of the pick-ups
		// in order to be able to reset their position
		firstpos1 = pickup1.transform.position; 
		firstpos2 = pickup2.transform.position;
		firstpos3 = pickup3.transform.position;
		firstpos4 = pickup4.transform.position;

		// Start with showing the first mission
		mission1.SetActive (true);
		mission2.SetActive (false);
		mission3.SetActive (false);
		mission4.SetActive (false);

		// Start with showing the first pick-up
		pickup1.SetActive (true);
		pickup2.SetActive (false);
		pickup3.SetActive (false);
		pickup4.SetActive (false);

		// get the variable beingCarried from the script PickUpObject_malin
		carried = GameObject.Find ("pick-up1").GetComponent<PickUpObject_malin> ().beingCarried;

		// Start by setting the toggler to 1. This shows that the first mission is showing.
		toggler = 1;

		// Make the completed mission text empty. 
		winner.text = "";

		// toggel if the mission and the pick-up is colliding.
		col_mis_pick = false;

	}



	void Update () 
	{

		// Mission and pick-up is colliding, the D-key is pressed and 
		// the pick-up is not being carried -> switch mission.
		if (col_mis_pick && Input.GetKeyDown(KeyCode.D) && !carried) 
		{

			// toggle which pick-up is visible using layers. 
			if (toggler == 1) {

				// show the 2nd mission
				mission1.SetActive (false);
				mission2.SetActive (true);
				mission3.SetActive (false);
				mission4.SetActive (false);

                // reset the position of the pick-up
                resetPos();

                // Show the 2nd pick-up
                pickup1.SetActive (false);
				pickup2.SetActive (true);
				pickup3.SetActive (false);
				pickup4.SetActive (false);

				carried = GameObject.Find ("pick-up2").GetComponent<PickUpObject_malin> ().beingCarried;

				// toggle to know the 2nd mission is active.
				toggler = 2;
			} else if (toggler == 2) {

				// show the 3rd mission
				mission1.SetActive (false);
				mission2.SetActive (false);
				mission3.SetActive (true);
				mission4.SetActive (false);

                // reset the position of the pick-up
                resetPos();

                // show the 3rd pick-up
                pickup1.SetActive (false);
				pickup2.SetActive (false);
				pickup3.SetActive (true);
				pickup4.SetActive (false);

				carried = GameObject.Find ("pick-up3").GetComponent<PickUpObject_malin> ().beingCarried;

				toggler = 3;
			} else if (toggler == 3) {

				// show the 4th mission
				mission1.SetActive (false);
				mission2.SetActive (false);
				mission3.SetActive (false);
				mission4.SetActive (true);

				// show the 4th pick-up
				pickup1.SetActive (false);
				pickup2.SetActive (false);
				pickup3.SetActive (false);
				pickup4.SetActive (true);

                // reset the position of the pick-up
                resetPos();


                carried = GameObject.Find ("pick-up4").GetComponent<PickUpObject_malin> ().beingCarried;

				toggler = 0;
			} else {
				// disable all the missions and pick-ups
				mission1.SetActive (false);
				mission2.SetActive (false);
				mission3.SetActive (false);
				mission4.SetActive (false);

				pickup1.SetActive (false);
				pickup2.SetActive (false);
				pickup3.SetActive (false);
				pickup4.SetActive (false);

				// Display mission completed
				winner.text = "Banan avklarad!";

				// Here should the user get sent back to the start scene.  
			} 
		}
	}


	void OnTriggerEnter(Collider other) 
	{
		// If a mission and a pick-up is colliding
		if(other.gameObject.CompareTag("Pick-up") ) 
		{
			col_mis_pick = true;
		}
	}



	void OnTriggerExit(Collider other)
	{
		// If a mission and a pick-ip is no longer colliding
		if (other.gameObject.CompareTag("Pick-up"))
		{
			col_mis_pick = false;
		}
	}

    // reset the position and rotation of the pick-up
    void resetPos()
    {
        pickup1.transform.position = firstpos1;
        pickup1.transform.rotation = Quaternion.identity;

        pickup2.transform.position = firstpos2;
        pickup2.transform.rotation = Quaternion.identity;

        pickup3.transform.position = firstpos3;
        pickup3.transform.rotation = Quaternion.identity;

        pickup4.transform.position = firstpos4;
        pickup4.transform.rotation = Quaternion.identity;
    }

}