using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class DamageGenerator : MonoBehaviour {

	public GameObject poleListObj;
	public SceneData data;
	public GameObject damageSet;

	// Use this for initialization
	public void generateDamage () {
		//get damage equipment 
		string[] equipments = data.getDamageEquipmentArray();
		int level = data.getDamageLevel();
        GameObject[] poleArray= getChildObjects(poleListObj);

        //debug
        print("------");
        foreach(string t in equipments)
        {
            print("\t\t" + t);
        }

        //for each pole
        foreach (GameObject pole in poleArray)
        {
            print("Pole = "+pole);
            //choose maximum 3 equipment that exist in pole to replace
            string[] damageList = chooseDamageForPole(equipments, pole);
            foreach(string equipment in damageList)
            {
                print(equipment);
                //put damage to each equipment in damageList
                int tempLevel = level;

                //check if they want random level
                if (level == -1)
                    //generate a random number 
                    tempLevel = UnityEngine.Random.Range(1, 4);// 3 level of damage 1/2/3/

                GameObject oldEquipment = getEquipmentToReplace(pole, equipment);
                print("old equipment = " + oldEquipment.transform.parent+"/"+ oldEquipment);
                GameObject damagePrefab = getDamagePrefab(damageSet, oldEquipment.name, tempLevel);
                print("new equip = " +damagePrefab.transform.parent+"/"+ damagePrefab);


                //record damage level and equipment to poledata
                Data oldData = oldEquipment.GetComponent<Data>();

                GameObject newObject = replaceObject(oldEquipment, damagePrefab);
                if (newObject.GetComponent <Data>() == null)
                    newObject.AddComponent<Data>();

                Data newData = newObject.GetComponent<Data>();

                newData.setData(oldData);
                newData.level = tempLevel;

                ////call appriate function for different type of equipment
                //if (equipment == "CapacitorBank")
                //{
                //    newObject.GetComponent<CapacitorBank2>().fillwire();
                //}
            }

        }
        //at the end , deactive damageset
        damageSet.SetActive(false);
    }

    string[] chooseDamageForPole(string[] damageList, GameObject pole)
    {
        //get list object name in pole
        HashSet<string> temp = new HashSet<string>();
        foreach(Transform child in pole.transform)
        {
            print("child --- " + child);
            temp.Add(child.name);
            foreach (Transform child2 in child)
            {
                temp.Add(child2.name);

            }

        }

        List<string> ret = new List<string>();
        foreach (string t in temp)
        {
            print("temp --- " + t);
            if (damageList.Contains(t))
            {
                ret.Add(t);
                continue;
            }
        }
        ret.ShuffleList<string>();

        int max = 3;
        if (ret.Count < 3)
            max = ret.Count;

        

        return ret.GetRange(0,max).ToArray();
    }

    //find all children object in a gameobject
    GameObject[] getChildObjects(GameObject parent)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach( Transform child in parent.transform)
        {
            temp.Add(child.gameObject);
        }

        return temp.ToArray();
    }

    //get prefab of damage equipment for an available set
	GameObject getDamagePrefab(GameObject damageSet, string equipment, int level){
        if (damageSet.transform.Find(equipment) == null)
        {
            print("Damage set doesn't have "+equipment);
            return null;
        }
        
        //if damage level is any
        GameObject ret;
        if (level == -1)
        {
            //replace level with a random level
            level = Random.Range(1, 4);

        }
        
        //if damage is a specific number
        string name = equipment+"/"+equipment + level;
        ret = GameObject.Find(name);
        return ret;
	}

    GameObject getEquipmentToReplace(GameObject pole, string name) {
        //all gameobject is a single pole
        List<GameObject> equipmentList = new List<GameObject>();

        foreach (Transform child in pole.transform)
        {
            if (child.name.Contains(name))
            {
                equipmentList.Add(child.gameObject);
            }

            if(name == "FuseSwitch")
            foreach(Transform child2 in child)
            {
                if (child2.name.Contains(name))
                {
                    equipmentList.Add(child2.gameObject);
                }
            }
        }
        if (equipmentList.Count == 0) {return null; }


        int randomIndex = Random.Range(0, equipmentList.Count);

        GameObject ret = equipmentList.ToArray()[randomIndex];

        return ret;
    }

    GameObject replaceObject(GameObject oldObject, GameObject damagePrefab){
        GameObject newObject;
        
		newObject = (GameObject)PrefabUtility.InstantiatePrefab(damagePrefab);
        if(PrefabUtility.GetPrefabType(damagePrefab) == PrefabType.Prefab)
        {
            newObject = (GameObject)PrefabUtility.InstantiatePrefab(damagePrefab);
        }
        else
        {
            newObject = Instantiate(damagePrefab);
            newObject.name = oldObject.name;
        }

        if (newObject == null)
        {
            Debug.LogError("Error instantiating prefab");
        }
        print("oldObject parent" + oldObject.transform.parent); 
        newObject.transform.parent = oldObject.transform.parent;
        newObject.transform.localPosition = oldObject.transform.localPosition;
        newObject.transform.localRotation = oldObject.transform.localRotation;
		newObject.transform.localScale = oldObject.transform.localScale;

        DestroyImmediate(oldObject);

        print(newObject.transform.parent+" replace with " +newObject.name+"-"+ newObject.transform.GetComponent<Data>().level);

        return newObject;
    }


    //function check all insulator in a pole and return an insulator
    GameObject getRandomInsulator(GameObject pole)
    {

        List<GameObject> insulatorList = new List<GameObject>();
        for(int i=0; i<pole.transform.childCount; i++)
        {
            GameObject temp = pole.transform.GetChild(i).gameObject;
            if (temp.name.Contains("Insulator")){
                insulatorList.Add(temp);
            }
        }

        int index = Random.Range(0, insulatorList.Count);


        return insulatorList.ToArray()[index];

    }
}

