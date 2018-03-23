using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DamageGenerator : MonoBehaviour {

	public GameObject[] poleList;
	public SceneData data;
	public GameObject damageSet;
	// Use this for initialization
	void Start () {
		//get damage equipment 
		string equipment = data.getDamageEquipment;
		int level = data.getDamageLevel;

		if(level == -1) //check if user input any level damage
		{
			//for each pole
			for(int i = 0; i< poleList.Length;i++){
				//generate a random number 
				int randomLevel = UnityEngine.Random.Range(1,4);// 3 level of damage 1/2/3/

				GameObject oldEquipment = getEquipmentToReplace(poleList[i], equipment);

				GameObject damagePrefab = getDamagePrefab(damageSet,equipment,randomLevel);

				replaceObject (oldEquipment, damagePrefab);
			}
		}
	}



	GameObject getDamagePrefab(GameObject damageSet, string equipment, int level){
	
	}

	GameObject getEquipmentToReplace(GameObject pole, string name ){
		//pole gameobject is a single pole

		//find all gameobject with same 


	}

	void replaceObject(GameObject oldObject, GameObject damagePrefab){
	
		GameObject newObject;
		newObject = (GameObject)PrefabUtility.InstantiatePrefab (damagePrefab);
		newObject.transform.parent = oldObject.transform.parent;
		newObject.transform.localRotation = oldObject.transform.localRotation;
		newObject.transform.localScale = oldObject.transform.localScale;

		DestroyImmediate (oldObject);



	}
}
