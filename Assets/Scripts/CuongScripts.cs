using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CuongScripts : MonoBehaviour {
    public GameObject poleSet;
    //public bool placeDataScript= false;
    //private static bool isSet = false;
	// Use this for initialization

	void Start() {

        if (poleSet == null)
            poleSet = gameObject;

        print("****\nAdded data script into component");

        //go through all object of 
        for(int i=0;i< poleSet.transform.childCount; i++)
        {
            //go to framing 
            GameObject temp = poleSet.transform.GetChild(i).gameObject;
            for (int j = 0;j < temp.transform.childCount; j++)
            {
                //type wood or concrete
                GameObject temp2 = temp.transform.GetChild(j).gameObject;
                print(temp2.name);
                for(int k = 0; k< temp2.transform.childCount; k++)
                {
                    //each equipment
                    GameObject equip = temp2.transform.GetChild(k).gameObject;
                    if (isEquipName(equip.name)) {
                        print("\t"+equip.name);
                        Data equipData = equip.GetComponent<Data>();
                        if (equipData == null)
                        {
                            //if equipment doesn't have data script
                            equip.AddComponent<Data>();
                            equipData = equip.GetComponent<Data>();
                            print("add data script into it " + (equip.GetComponent<Data>() == null));

                        }

                        equipData.equipmentName = getEquipName(equip.name);
                        equipData.level = 0;
                        if(equipData.phase != 'N' && equipData.phase != 'A' &&
                            equipData.phase != 'B' && equipData.phase != 'C')
                            equipData.phase = 'N';

                    }
                }

            }



        }
	}
	
    bool isEquipName(string name)
    {
        name = name.ToLower();
        string[] nameList =
        {
            "insulator", "pole"
        };
        foreach(string i in nameList)
        {
            if (name.Contains(i))
                return true;

        }

        return false;
    }

    string getEquipName(string name)
    {
        string[] nameList =
{
            "Insulator", "Pole"
        };

        foreach (string i in nameList)
        {
            if (name.ToLower().Contains(i.ToLower()))
                return i;

        }

        return "Equipment";

    }
}
