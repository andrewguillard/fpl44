using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DamageGenerator : MonoBehaviour {

	public GameObject poleList;
	public SceneData data;
	public GameObject damageSet;
	// Use this for initialization
	void Start () {
		//get damage equipment 
		string equipment = data.getDamageEquipment();
		int level = data.getDamageLevel();
        GameObject[] poleArray= getChildObjects(poleList);

        //check if user select any equipment
        if (!equipment.Equals("any"))
        {
            //for each pole
            for (int i = 0; i < poleArray.Length; i++)
            {
                int tempLevel = level;
                
                //check if they want random level
                if(level == -1)
                    //generate a random number 
                    tempLevel = UnityEngine.Random.Range(1, 4);// 3 level of damage 1/2/3/
                
                GameObject oldEquipment = getEquipmentToReplace(poleArray[i], equipment);
                GameObject damagePrefab = getDamagePrefab(damageSet, oldEquipment.name, tempLevel);

                //record damage level and equipment to poledata
                Data oldData = oldEquipment.GetComponent<Data>();

                GameObject newObject=  replaceObject(oldEquipment, damagePrefab);

                newObject.AddComponent<Data>();
                Data newData = newObject.GetComponent<Data>();
                newData.setData(oldData);
                newData.level = tempLevel;
            }
        }
        else
        {
            //user want random equipment

            
        }


        //at the end , deactive damageset
        damageSet.SetActive(false);
    }

    GameObject[] getChildObjects(GameObject parent)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach( Transform child in parent.transform)
        {
            temp.Add(child.gameObject);
        }

        return temp.ToArray();
    }

	GameObject getDamagePrefab(GameObject damageSet, string equipment, int level){
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
        if (ret == null)
            print("can't get prefab from damage set");
        return ret;
	}

	GameObject getEquipmentToReplace(GameObject pole, string name ){
        //pole gameobject is a single pole

        //find all gameobject with same tag
        List<GameObject> equipmentList = new List<GameObject>();

        foreach (Transform child in pole.transform)
        {
            if (child.name.Contains(name))
            {
                equipmentList.Add(child.gameObject);
            }
        }

        int randomIndex = Random.Range(0, equipmentList.Count);

        GameObject ret = equipmentList.ToArray()[randomIndex];
        if (ret == null)
            print("Cant get equipment to replace");
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

        newObject.transform.parent = oldObject.transform.parent;
        newObject.transform.localPosition = oldObject.transform.localPosition;
        newObject.transform.localRotation = oldObject.transform.localRotation;
		newObject.transform.localScale = oldObject.transform.localScale;

        DestroyImmediate(oldObject);

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

