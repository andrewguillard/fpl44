using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
    public static string framing;
	public static string damageEquipment = "Insulator";
	public static int damageLevel  = -1;

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

    public string getFraming() {
        return framing;
        
    }

	public void setDamageEquipment(string t){
		damageEquipment = t;
	}

	public void setDamageLevel(int i){
		damageLevel = i;
	}

	public string getDamageEquipment(){ return damageEquipment;}
	public int getDamageLevel(){ return damageLevel;}
}
