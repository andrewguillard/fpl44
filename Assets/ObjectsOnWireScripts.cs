using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsOnWireScripts : MonoBehaviour {
    [SerializeField] private GameObject[] objects;
    [SerializeField] private PoleGeneration poleGenerator;
    //[SerializeField] private GameObject[] centerPoints;
    private PoleData pole;


	// Use this for initialization
	void Start () {
	    if(transform.parent.name != "EquipmentSet")
        {
            pole = transform.parent.GetComponent<PoleData>();

            //random chooser wire and object
            int objectRan = Random.Range(0, objects.Length);
            GameObject obj = Instantiate(objects[objectRan], transform);

            int rNum = Random.Range(0, 3);
            Vector3 pos = pole.wireOutPoints[rNum].transform.position;
            GameObject centerPoint = obj.transform.Find("CenterPoint").gameObject;
            //set location of object on wire
            if (pole.wireDirection.ToLower().Equals("x"))
            {
                pos.x -= 10f;
                pos.y -= 0.2f;
            }
            else
            {
                pos.z -= 10f;
                pos.y -= 0.2f;
            }
            obj.transform.position = pos;

            //connect wire
            GameObject endPoint = poleGenerator.getPoleList()[pole.poleIndex + 1].GetComponent<PoleData>().wireInPoints[rNum];
            UtilityFunctions.AdjustineConnect(pole.wireOutPoints[rNum], endPoint, centerPoint);

        }	
	}

}
