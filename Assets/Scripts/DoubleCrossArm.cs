using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCrossArm : MonoBehaviour {
    [SerializeField] GameObject[] sPoint;
    [SerializeField] GameObject[] ePoint;

    // Use this for initialization
    void Start () {
        for(int i = 0; i< sPoint.Length; i++)
        {
            UtilityFunctions.lineConnect(sPoint[i], ePoint[i], 0.07f, 5, 0.01f);

        }
    }
	
}
