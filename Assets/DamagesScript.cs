using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesScript : MonoBehaviour {
    public GameObject[] Damages;
    public GameObject[] equipLocation;
    public string[] nameObjectToReplace;
    public void setDamage(int level)
    {
        char equipPhase = transform.GetComponent<Data>().phase;
        string equipname = transform.GetComponent<Data>().name;

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
        }
        else if(equipLocation.Length > 0 && nameObjectToReplace.Length ==0)
        {
            //decide how many equip ex: LA is damage
            int numberOfDamages = Random.Range(1, equipLocation.Length);
            //get data to save the name phase 
            equipData = transform.GetComponent<Data>();
            
            for(int i=0; i< numberOfDamages; i++)
            {
                if (equipLocation[i] == null)
                {
                    Debug.Log("Location of damage equip is null :" + ((transform.parent == null) ? null : transform.parent.name) + "/" + transform);
                    continue;
                }
                else
                {
                    //go to each location and swap 
                    newObj = UtilityFunctions.replaceObject(equipLocation[i], Damages[level - 1]);
                }

            }

           // //replace something else
           //int numberOfDamages = Random.Range(1, equipLocation.Length);
           //equipData = transform.GetComponent<Data>();

           // if (nameObjectToReplace.Length !=0 )
           //     for (int i=0; i< numberOfDamages; i++)
           //     {
           //         if(equipLocation[i] == null)
           //         {
           //             print("IN " + transform.parent);
           //             string name = nameObjectToReplace[numberOfDamages];
           //             print("need to find this name -" + name + "- gameobject in " + gameObject.name);
           //             print(UtilityFunctions.findInChild(transform, name));

           //             equipLocation[i] = UtilityFunctions.findInChild(transform,name).gameObject;
           //         }
           //         print("replace " + equipLocation[i] + "------" + Damages[level - 1]);
           //         newObj=  UtilityFunctions.replaceObject(equipLocation[i], Damages[level - 1]);
           //     }

        }
        else
        {
            //if list of name listed
            for(int i=0;i<nameObjectToReplace.Length; i++)
            {
                string tempName = nameObjectToReplace[i];
                GameObject oldObj;
                //find object
                //GameObject oldObj = UtilityFunctions.findInChild(transform, tempName).gameObject;
                if (transform.name == "AFS")
                    oldObj = transform.GetComponent<AFSScript>().equipment;
                else
                    oldObj = transform.parent.Find(tempName).gameObject;

                //
                if (oldObj == null)
                {
                    print("Can't find " + tempName + " in " + ((transform.parent == null) ? null : transform.parent.name) + "/" + transform.name);
                    continue;
                }
                else
                {
                    //found it 
                    newObj = UtilityFunctions.replaceObject(oldObj, Damages[level - 1]);

                }
            }



        }

        //copy data
        if(newObj.GetComponent<Data>() == null)
        {
            Data newData = newObj.gameObject.AddComponent<Data>();
            newData.level = level;
            newData.name = equipname;
            newData.phase = equipPhase;
        }
    }
}
