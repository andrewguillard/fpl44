using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
    public static string framing;
	public static List<string> damageEquipment;
	public static int damageLevel  = -1;
    GameObject[] poles;


    //get functions
    public string getFraming(){return framing;}
	public string[] getDamageEquipmentArray(){
        if(damageEquipment == null)
        {
            //this only for development 
            damageEquipment = new List<string>();
            damageEquipment.Add("CapacitorBank");
            //damageEquipment.Add("FuseSwitch");


        }

        return damageEquipment.ToArray();
    }
	public int getDamageLevel(){ return damageLevel;}
    public GameObject[] getPoles() { return poles; }
    
    //setfunctions
    public void setFraming(string f) {
        if (f == "any")
        {
            framing = null;
        }
        else
        {
            print("set framing" + f);
            framing = f;
        }
    }

    public void setPoles(GameObject[] p) {
        poles = p;
    }

	public void addDamageEquipment(string t){
        if(damageEquipment == null)
        {
            damageEquipment = new List<string>();
        }

        damageEquipment.Add(t);
	}

    public void removeDamageEquipment(string t)
    {
        damageEquipment.Remove(t);
    }

    public void clearEquip()
    {
        damageEquipment.Clear();
    }

	public void setDamageLevel(int i){
        damageLevel = i;
	}

}
