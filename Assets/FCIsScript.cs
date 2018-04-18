using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCIsScript : MonoBehaviour {
    [SerializeField] private GameObject FCI;
    public GameObject[] FCIList;
	// Use this for initialization
	void Awake () {
        if (transform.parent.name == "EquipmentSet" || transform.parent.name == "DamageSet")
            return;

        FCIList = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            FCIList[i] = Instantiate(FCI,transform);
            FCIList[i].transform.name = "FCI" + i;
            FCIList[i].transform.parent = transform;
            FCIList[i].GetComponent<FCIScript>().setFCI(transform.parent.GetComponent<PoleData>(), i);
        }
	}

}
