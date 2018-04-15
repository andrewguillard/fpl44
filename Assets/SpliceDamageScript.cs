using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpliceDamageScript : MonoBehaviour {
    [SerializeField] private GameObject[] connectionLeft;
    [SerializeField] private GameObject[] connectionRight;


    // Use this for initialization
    void Start () {
        //align them 
        for(int i = 0; i < connectionLeft.Length; i++)
        {
            UtilityFunctions.lineConnect(connectionLeft[i], connectionRight[i], 0.07f, 5, 0.0f);
        }
	}
	
}
