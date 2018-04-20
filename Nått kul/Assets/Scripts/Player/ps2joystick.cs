using UnityEngine;
using UnityEngine;
using System.Collections;
using System.IO;        // for communication with arduino 
using System.IO.Ports;  // for communication with arduino 
// don't know if all are used under this line.. 
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ps2joystick
{

	private string NewLine; // String that contains the x- and z-value  
	private int[] coordinate = new int[2]; // contains  x- and z- valuesr from joystick (ps2)
	//private int value;
	//private string type;
	private Vector3 movement  = new Vector3 (0, 0, 0);
    private bool first = true;
    SerialPort sp = new SerialPort("COM9", 115200); //(9600)  Opens a connection between Unity and a Serialport. 

  
  public ps2joystick() // constructor 
    {
     
    }
 
	void get_data()
	{
		if (sp.IsOpen) 
		{
			try
			{
				sp.ReadByte(); // nothing works without it 

				coordinate = ArduinoValueToUntiyValue(NewLine); // takes the string with info from arduino and creates an array with w ints that can be used in unity.

                MoveObject(ref movement, ref coordinate);
			}
			catch (System.Exception)
			{

			}
		}
	}

    private void open()
    {
        sp.Open();
        sp.ReadTimeout = 1; // freeze if higher
        first = false;
    }
                                                 
	public float GetAxis(string type)
	{
        if (first)
        {
            open();
        }
        
        get_data ();


		if (type == "Vertical")
		{
            return movement.x;
        }
        else if ( type == "Horizontal")
		{
            return movement.z;
        }
        else
        {
            Debug.Log("Error: Wrong arguments in  ps2Joystick");
        }
        return 0.0f;
       

	}

	public int[] ArduinoValueToUntiyValue(string String)
	{
		//This function takes one string with values from the Arduino as argument and convert it to an array with int-values for x and z. 
		/* Example: 
     * private string Namn;
     * 
     * ArduinoValueToUnityValue(Namn);
     * 
     * print(xy_Value) ( prints: "[x,y]") 
     * 
    */
		NewLine = sp.ReadLine(); // All data from the Arduino are putted in the string NewLine: [x' 'y].

		string[] array = NewLine.Split(' '); // The string is divided at the  ' ' and transforms to an array with 2 slots. 
		string xValue = array[0]; // x value (string value)
		string yValue = array[1]; // y value (string value) 

		int x_Value = Convert.ToInt32(xValue); // convert array value to int
		int y_Value = Convert.ToInt32(yValue); // 


		int[] xy_Value = new int[2]; //create an  int-array with x,y value ([x,y])
		xy_Value[0] = x_Value;
		xy_Value[1] = y_Value;

		return xy_Value;  // returns an array
	}

	public void MoveObject(ref Vector3 movement, ref int[] coord)
	{
		/* This function change the vector "movement" that holds the direction that the object 
     * will move in, by looking where the x- and z-value are in the interval -1 to 1. 
     * It gives the information if the object is moving left/right/up/down or if it stands
     * still. 
     *
     * Example: 
     *  vector vec = new vector3(0,0,0);
     * 	int[] array = new int[2];
     *  array[0] = 1; // x-value
     * 	array[1] = 0; // z-value; 
     * 
     * 	MoveObject(vec,array); 
     * 	print(vec) // will print "(1,0,0)" -> the object will go right.
     * 
    */
		if (coord[0] < 1 && coord[0] > 0)
		{  //right 
			movement.x = coord[0];
		}

		else
		{ // left / stand still (if == 0)
			movement.x = -coord[0];
		}

		if (coord[1] < 1 && coord[1] > 0)
		{ // down
			movement.z = -coord[1];
		}
		else
		{ // up / stand still (if == 0) 
			movement.z = coord[1];
		}

	}
}


