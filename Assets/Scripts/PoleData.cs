using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleData : MonoBehaviour {
    public string[] equipment;
    public int[] levelDamage;
    
	// Use this for initialization
	void Start () {
        //go to children objects and get data
        initizalizeData(gameObject);
	}

    void initizalizeData(GameObject pole)
    {
        //go through each children 
        foreach(transform i in pole.transform)
        {

        }
    }
}
