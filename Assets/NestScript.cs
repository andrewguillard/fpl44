using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestScript : MonoBehaviour {
    [SerializeField] private GameObject nestPreFab;
    private PoleData pole;
	// Use this for initialization
	void Start () {
		if(transform.parent.name != "EquipmentSet" && transform.parent.name != "DamageSet")
        {
            print("calling nest ");
            pole = transform.parent.GetComponent<PoleData>();

            GameObject nestLoc =  pole.transform.Find("NestLoc").gameObject;
            GameObject nest = Instantiate(nestPreFab, nestLoc.transform.position, nestPreFab.transform.rotation);
            nest.transform.parent = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
