/* ***************************************************
 * Author: Malin
 * 
 * Makes the missions rotate around themselfs. 
 * Script is placed on the missions. 
 * 
 * Code review: Thobias
 * **************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator_movement_malin : MonoBehaviour {

	void Update () {
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
