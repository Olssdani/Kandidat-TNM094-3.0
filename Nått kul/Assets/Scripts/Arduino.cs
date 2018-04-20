//Author: Daniel Olsson
//This class handles the SerialPort stream to the arduino. Because of the nature of the communication
//between a arduino and a computer this class can only have one instance of itself. This class is called by
//the ControllerInput class and shall never be called anywhere else. 
//
//How to Use:
//To be able to use the ControllerInput class with the Ardunio a few couple of steps need to be done.
//1. Set the correct braud rate and communication port in the Arduino and the SerialPort class ín the variable def.
//Code review by: Emma Nilsson, Oliver Johansson 20/4
using UnityEngine;
using System.Collections;
using System.IO;        // for communication with arduino 
using System.IO.Ports;  // for communication with arduino 
using System;
using System.Linq;
using System.Collections.Generic;
public class Arduino : MonoBehaviour {
    /*****************************************************
    ********************Variable definitions**************
    * ****************************************************/
    //Initate a instance of Ardunio
    public static Arduino instance = null;
    //A serialport to the ardunio
    private SerialPort SerialPort_Nano = new SerialPort("COM3", 9600); //(9600)  Opens a connection between Unity and a Serialport. 
    private SerialPort SerialPort_Duo = new SerialPort("COM6", 9600); //(9600)  Opens a connection between Unity and a Serialport. 
    //Buttons and joysticks
    bool [] buttons = new bool[5] { false, false, false, false, false };
    bool [] buttons_light = new bool[5] { false, false, false, false, false };
    private int[] Joystick = new int[4] { 0, 0, 0, 0 };
    private int[] controllers = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //skriv som temporär istället

    /*****************************************************
    ****************Functions implementation**************
    * ****************************************************/
    // Runs when one instance of this class is created. If more than one instance of this class
    // is created then it destroy the newest created instance.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            open();
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
   
    // Open a stream to the ardunio and set a timeout time.
    private void open()
    {
        SerialPort_Nano.Open();
        SerialPort_Nano.ReadTimeout = 1;

        SerialPort_Duo.Open();
        SerialPort_Duo.ReadTimeout = 1;
    }
    //Checks if a connection is available and then read all information from the arduino.
    private void get_data()
    {
        if (SerialPort_Nano.IsOpen &&SerialPort_Duo.IsOpen)
        {
            try
            {
                ArduinoDecrypter();
            }
            catch (System.TimeoutException)
            {
                Debug.Log("Timeout");
            }
        }
        else
        {
            open();
        }
    }
    //Reads information from the ardunio and then decrypts the information and puts the correct information into the right variables.
    public void ArduinoDecrypter()
    {
       
        string Nano_read = SerialPort_Nano.ReadLine();
        string Duo_read = SerialPort_Duo.ReadLine();
        Debug.Log(Duo_read);
        // Only reads the string if it is 11 characters long. It is because of the information lost in transmission (vad för info förloras?)
        if (Nano_read.Length == 11)
        {
            for (int i = 0; i < Nano_read.Length - 1; i++)
            {
                //Makes chars into ints.
                controllers[i] = (int)(Nano_read[i] - '0');
            }
            //Add the state into the buttons.
            for (int i = 0; i < 10; i = i + 2)
            {
                //If button is pressed
                if (controllers[i] == 1)
                {
                    buttons[i / 2] = true;
                }
                else
                {
                    buttons[i / 2] = false;
                }
                //If the light is on
                if (controllers[i + 1] == 1)
                {
                    buttons_light[i / 2] = true;
                }
                else
                {
                    buttons_light[i / 2] = false;
                }
            }
        }
        if (Duo_read.Length == 3)
        {
            for (int i = 0; i < Duo_read.Length; i++)
            {
                //Makes chars into ints.
                controllers[i] = (int)(Duo_read[i] - '0');
            }

            //Adds the joystick state into the joystick variable
            //lägg till horisontal och vertikal
            for (int i = 0; i < Duo_read.Length ; i++)
            {
                if (controllers[i] == 0)
                {
                    Joystick[i*2] = 0;
                    Joystick[i * 2+1] = 0;
                }
                else if(controllers[i] == 1)
                {
                    Joystick[i * 2] = 0;
                    Joystick[i * 2 + 1] = 1;
                }
                else if (controllers[i] == 2)
                {
                    Joystick[i * 2] = 1;
                    Joystick[i * 2 + 1] = 1;
                }
                else if (controllers[i] == 3)
                {
                    Joystick[i * 2] = 1;
                    Joystick[i * 2 + 1] = 0;
                }
                else if (controllers[i] == 4)
                {
                    Joystick[i * 2] = 1;
                    Joystick[i * 2 + 1] = -1;
                }
                else if (controllers[i] == 5)
                {
                    Joystick[i * 2] = 0;
                    Joystick[i * 2 + 1] = -1;
                }
                else if (controllers[i] == 6)
                {
                    Joystick[i * 2] = -1;
                    Joystick[i * 2 + 1] = -1;
                }
                else if (controllers[i] == 7)
                {
                    Joystick[i * 2] = -1;
                    Joystick[i * 2 + 1] = 0;
                }
                else if (controllers[i] == 8)
                {
                    Joystick[i * 2] = -1;
                    Joystick[i * 2 + 1] = 1;
                }
            }
        }
    }
    
    // Update is called once per frame and reupdate the data.
    void Update () {        
        get_data();
    }
    //When object is destroyed we close the stream to the arduino
    void OnDestroy()
    {
        SerialPort_Nano.Close();
        SerialPort_Duo.Close();
    }
    //Return if the button is pressed or not.
    public bool ButtonPressed(int nr)
    {
        return buttons[nr - 1];
    }
    //turn on or off the light of a button.
    public void LightButton(bool light,int nr)
    {
        if (light)
        {
            SerialPort_Nano.Write("1");
        }
        else
        {
            SerialPort_Nano.Write("0");
        }
    }
    //Returns the value of each axis.
    public int GetAxis(string axis)
    {
        if(axis == "Left_Horizontal")
        {
            return Joystick[0];
        }else if(axis == "Left_Vertical")
        {
            return Joystick[1];
        }
        else if(axis == "Right_Horizontal")
        {
            return Joystick[2];
        }else if(axis == "Right_Vertical")
        {
            return Joystick[3];
        }
        return 0;
    }
}
