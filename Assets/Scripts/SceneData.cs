using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
    public static string framing;
	public static string damageEquipment;
	public static int damageLevel;

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
		setDamageLevel = i;
	}

	public string getDamageEquipment(){ return damageEquipment;}
	public string getDamageLevel(){ return damageLevel;}
}
