﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCrossArm : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string[] phases = { "A", "B", "C" };

        for(int i = 0; i< phases.Length; i++)
        {
            string sName = phases[i] + "1";
            string eName = phases[i] + "2";

            GameObject sPoint = transform.Find(sName).gameObject;
            GameObject ePoint = transform.Find(eName).gameObject;

            UtilityFunctions.lineConnect(sPoint, ePoint, 0.07f, 5, 0.01f);

        }
    }
	
}