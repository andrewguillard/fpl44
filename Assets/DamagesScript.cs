using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesScript : MonoBehaviour {
    public GameObject[] Damages;
    public GameObject[] equipLocation;
    public string[] nameObjectToReplace;
    public void setDamage(int level)
    {
        //print(transform + " is level" + level);
        char equipPhase = transform.GetComponent<Data>().phase;

        //if no damage set
        if(Damages.Length == 0)
        {
            Debug.LogError(transform.parent + "/" + transform + " doesn't have damages set");
            return;
        }

        GameObject newObj = null;
        Data equipData;

        //replace current gameobject
        if (equipLocation.Length ==0 || nameObjectToReplace.Length == 0)
        {
            print(transform.parent.name + " Replace " + gameObject + " with " + Damages[level - 1]);

            newObj = UtilityFunctions.replaceObject(gameObject, Damages[level - 1]);
            equipData = newObj.GetComponent<Data>();

            if (equipData == null)
            {
                //Debug.LogError(newObj.transform.parent + "/" + newObj.name + " should have Datascript");
                equipData = newObj.AddComponent<Data>();
            }
            else
            {
                if (Damages[level - 1].GetComponent<Data>() != null)
                {
                    equipData.level = Damages[level - 1].GetComponent<Data>().level;
                }
                else
                    equipData.level = level;
            }
            equipData.phase = equipPhase;
        }
        else
        {
            //replace something else
            int numberOfDamages = Random.Range(1, equipLocation.Length);
            equipData = transform.GetComponent<Data>();

            if (nameObjectToReplace.Length !=0 )
                for (int i=0; i< numberOfDamages; i++)
                {
                    if(equipLocation[i] == null)
                    {
                        print("IN " + transform.parent);
                        string name = nameObjectToReplace[numberOfDamages];
                        print("need to find this name -" + name + "- gameobject is " + gameObject.name + " equips is " + Damages[numberOfDamages].name);
                        print(UtilityFunctions.findInChild(transform, name));
                        foreach(Transform t in transform)
                        {
                            print("--------t= "+ t);
                        }
                        equipLocation[i] = UtilityFunctions.findInChild(transform,name).gameObject;
                    }
                    print("replace " + equipLocation[i] + "------" + Damages[level - 1]);
                    newObj=  UtilityFunctions.replaceObject(equipLocation[i], Damages[level - 1]);
                }

            if (equipData == null)
            {
                Debug.LogError(transform.parent + "/" + transform.name + " should have Datascript");
                equipData = gameObject.AddComponent<Data>();
            }
            else
            {
                if(Damages[level-1].GetComponent<Data>()!= null)
                {
                    equipData.level = Damages[level - 1].GetComponent<Data>().level;
                }
                else
                    equipData.level = level;

            }
            equipData.phase = equipPhase;

        }
        print(newObj.transform.localScale);
    }
}
