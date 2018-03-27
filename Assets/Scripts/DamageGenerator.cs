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

		if(level == -1) //check if user input any level damage
		{
			//for each pole
			for(int i = 0; i< poleArray.Length;i++){
				//generate a random number 
				int randomLevel = UnityEngine.Random.Range(1,4);// 3 level of damage 1/2/3/
                print(poleArray[i]);
				GameObject oldEquipment = getEquipmentToReplace(poleArray[i], equipment);
                print("old" + oldEquipment);
                print("old parent" + oldEquipment.transform.parent);

                GameObject damagePrefab = getDamagePrefab(damageSet,equipment,randomLevel);
                print("new" + damagePrefab);
				replaceObject (oldEquipment, damagePrefab);
			}
		}
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
        ret = damageSet.transform.Find(name).gameObject;

        return ret;
	}

	GameObject getEquipmentToReplace(GameObject pole, string name ){
        //pole gameobject is a single pole

        //find all gameobject with same tag
        List<GameObject> equipmentList = new List<GameObject>();
        foreach (Transform child in pole.transform)
        {
            if (child.gameObject.CompareTag(name))
            {
                equipmentList.Add(child.gameObject);
            }
        }

        int randomIndex = Random.Range(0, equipmentList.Count);

        return equipmentList[randomIndex];
    }

    void replaceObject(GameObject oldObject, GameObject damagePrefab){
	
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
    }
}
