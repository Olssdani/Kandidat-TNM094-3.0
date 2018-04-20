using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Communication : MonoBehaviour {

    bool Oxygen;
    bool Hydrogen;
    int OT, OM, OB, HT, HM, HB;

    void Start () {
        Oxygen = false;
        Hydrogen = false;
        OT = OM = OB = HT = HM = HB = 0;
    }
	
    public void SetBool(string Type, bool Value)
    {
        if(Type == "Oxygen")
        {
            Oxygen = Value;
        }else if(Type == "Hydrogen")
        {
            Hydrogen = Value;
        }
    }

    public bool Ready()
    {
        if(Oxygen && Hydrogen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
	// Update is called once per frame
	void Update ()
    {	
		int sum = OT + OM + OB + HT + HM + HB;
		if (sum == 6000) {
            Initiate.Fade("start_scene", Color.black, 2.0f);
        }
	}

	public void update_fuel_counter(string name, int amount){
		if(name == "Pipe_OT"){
			OT = amount;
		}else if(name == "Pipe_OM"){
			OM = amount;
		}else if(name == "Pipe_OB"){
			OB = amount;
		}else if(name == "Pipe_HT"){
			HT = amount;
		}else if(name == "Pipe_HM"){
			HM = amount;
		}else if(name == "Pipe_HB"){
			HB = amount;
		}
	}
}
