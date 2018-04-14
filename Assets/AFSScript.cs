using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFSScript : MonoBehaviour {
    [SerializeField] private GameObject[] leftArresters;
    [SerializeField] private GameObject[] rightArresters;
    [SerializeField] private GameObject[] leftA_Ins;
    [SerializeField] private GameObject[] rightA_Ins;
    [SerializeField] private GameObject[] leftWires;
    [SerializeField] private GameObject[] rightWires;
    [SerializeField] private PoleGeneration poleGenerator;
    private PoleData pole;

    // Use this for initialization
    void Start () {
	    if(transform.parent.name != "EquipmentSet" && transform.parent.name != "DamageSet")
        {
            pole = transform.parent.GetComponent<PoleData>();
            //connect arrester to connector
            for(int i=0; i< 3; i++)
            {
                UtilityFunctions.lineConnect(leftArresters[i], leftA_Ins[i], 0.01f, 5, 0.3f);
                UtilityFunctions.lineConnect(rightArresters[i], rightA_Ins[i], 0.01f, 5, 0.3f);

                //extend 
                GameObject temp = UtilityFunctions.extendPoint(pole.wireInPoints[i], ("L" + i), pole.wireDirection, 3);
                UtilityFunctions.AdjustineConnect(pole.wireInPoints[i], pole.wireOutPoints[i], temp);


                GameObject temp2 = UtilityFunctions.extendPoint(pole.wireOutPoints[i], ("L" + i), pole.wireDirection, -3);
                UtilityFunctions.AdjustineConnect(temp, pole.wireOutPoints[i], temp2);

                UtilityFunctions.lineConnect(leftWires[i], pole.wireInPoints[i], 0.07f, 5, 0.3f);
                UtilityFunctions.lineConnect(rightWires[i], pole.wireOutPoints[i], 0.07f, 5, 0.3f);

            }
        }
	}

}
