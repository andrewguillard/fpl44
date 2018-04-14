using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text.RegularExpressions;

public class CapacitorBank2 : MonoBehaviour {
    [SerializeField] private FuseSwitchScript[] FuseSwitchs;
    [SerializeField] private GameObject[] fromCAPToFSPoints;
    private PoleData pole;

    void Start()
    {
        if(transform.parent.name != "EquipmentSet")
        {
            pole = transform.parent.GetComponent<PoleData>();
            fillwire();
        }
    }

    public void fillwire()
    {
        float[] distanceList = { 0.5f, -0.8f,0.5f};
        for(int i=0;i< FuseSwitchs.Length; i++)
        {
            //Capacitor to jumper
            UtilityFunctions.lineConnect(fromCAPToFSPoints[i], FuseSwitchs[i].bottom, 0.03f,5,0.07f);

            GameObject newPoint;
            //extend wire point
            if (i != 2)
            {
                string newInName = "M_" + pole.wireInPoints[i].name;
                newPoint = UtilityFunctions.extendPoint(pole.wireInPoints[i], newInName, pole.wireDirection, distanceList[i]);


                //jumper to wires
                UtilityFunctions.lineConnect(FuseSwitchs[i].top, pole.wireInPoints[i], 0.02f, 5, 0.03f);
            }
            else
            {
                string newOutName = "M_" + pole.wireOutPoints[i].name;
                newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[i], newOutName, pole.wireDirection, distanceList[i]);

                UtilityFunctions.lineConnect(FuseSwitchs[i].top, pole.wireOutPoints[i], 0.02f, 5, 0.03f);

            }
            UtilityFunctions.AdjustineConnect(pole.wireInPoints[i], pole.wireOutPoints[i], newPoint);
        }
    }

}
