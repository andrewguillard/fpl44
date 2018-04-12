using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHeadScript : MonoBehaviour {
    private GameObject DCSwitch;
    private GameObject potHead;
	// Use this for initialization
	void Start () {
        if(DCSwitch == null)
        {
            DCSwitch = transform.Find("DCSwitch").gameObject;
        }
        if(potHead == null)
        {
            potHead = transform.Find("PotHead").gameObject;
        }
        fillWire();
	}
	
    //call this function when equipment is ready
    public void fillWire()
    {
        //connect pothead to DC-Switch
        GameObject[] potHeadPoints = new GameObject[3];
        GameObject[] switchPoint = new GameObject[3];
        for(int i = 0;i< 3; i++)
        {
            string name = "P" + (i+1);
            potHeadPoints[i] = UtilityFunctions.findInChild(potHead.transform, name).gameObject;
            switchPoint[i] = UtilityFunctions.findInChild(DCSwitch.transform, name).gameObject;

            UtilityFunctions.lineConnect(potHeadPoints[i], switchPoint[i] , 0.075f, 5, 0.25f );
        }

        //connect DC to wire


    }



}
