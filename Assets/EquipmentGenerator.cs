using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour {
    public GameObject EquipmentSet;

    public void generateEquipment()
    {

    }

    public void generateEquipment(SceneData data)
    {
        string[] equips = data.getDamageEquipmentArray();
        GameObject[] poleList = data.getPoles();

        foreach (string equip in equips)
        {
            foreach(GameObject pole in poleList)
            {
                if (getEquip(equip) != null)
                {
                   if (pole.GetComponent<PoleData>().poleIndex != poleList.Length / 2)
                    {
                        GameObject newEquip = Instantiate(getEquip(equip), pole.transform);
                        newEquip.name = equip;
                    }
                }
                else
                {
                    print("Can't find gameobject , so nothing is added");
                }

            }
        }
    }

    void disableEquipmentSet()
    {
        if(EquipmentSet != null)
        {
            EquipmentSet.SetActive(false);
        }
    }

    GameObject getEquip(string name)
    {
        if(EquipmentSet == null)
        {
            print("Equipment set is empty");
        }
        else
        {
            return EquipmentSet.transform.Find(name).gameObject;
        }

        return null;
    }
}
