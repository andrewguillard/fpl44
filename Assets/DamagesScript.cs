using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesScript : MonoBehaviour {
    public GameObject[] Damages;
    public GameObject[] equipLocation;
    public string[] nameObjectToReplace;
    public void setDamage(int level)
    {
        if(transform.GetComponent<Data>() == null)
        {
            Debug.Log("No Data for old " + transform.parent.name+"/"+transform.name + " to swap to damage");
        }

        Data oldData = transform.GetComponent<Data>();
        oldData.level = level;
        //if no damage set
        if(Damages.Length == 0)
        {
            Debug.LogError(transform.parent + "/" + transform + " doesn't have damages set");
            return;
        }

        GameObject newObj = null;
        Data equipData;

        //replace current gameobject
        if (equipLocation.Length ==0 && nameObjectToReplace.Length == 0)
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
                    print("replacing " + equipLocation[i].name);

                }

            }
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
                    oldObj = transform.Find(tempName).gameObject;

                //
                if (oldObj == null)
                {
                    print("Can't find " + tempName + " in " + ((transform.parent == null) ? null : transform.parent.name) + "/" + transform.name);
                    continue;
                }
                else
                {
                    //found it 
                    print("replacing " + oldObj.name);
                    newObj = UtilityFunctions.replaceObject(oldObj, Damages[level - 1]);
                }
            }



        }

        //copy data
        if(newObj.GetComponent<Data>() != null)
        {
            Data newData = newObj.GetComponent<Data>();
            if (newData.equipmentName != oldData.equipmentName)
                newData.equipmentName = oldData.equipmentName;

            if (newData.equipmentName == "Insulator")
                newData.phase = oldData.phase;
            else
                newData.phase = 'N';
            newData.subName = oldData.subName;
        }

    }
}
