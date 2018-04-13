using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHeadScript : MonoBehaviour {
    [SerializeField] private DCScript[] DCSwitchs;
    [SerializeField] private GameObject[] PotheadPoints;
    private PoleData pole;

    // Use this for initialization
    void Start() {

        if (transform.parent.name != "EquipmentSet")
        {
            pole = transform.parent.GetComponent<PoleData>();
            fillWire();
        }
    }

    //call this function when equipment is ready
    public void fillWire()
    {
        //pothead to DC
        for(int i = 0; i < 3; i++)
        {
            UtilityFunctions.lineConnect(PotheadPoints[i], DCSwitchs[i].bottom, 0.075f, 5, -0.25f);

            //extend about a meter
            GameObject newPoint;
            if(i!= 1)
                newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[i], ("M_" + i),pole.wireDirection, 0.5f);
            else
                newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[i], ("M_" + i), pole.wireDirection, -0.5f);

            UtilityFunctions.AdjustineConnect(pole.wireInPoints[i], pole.wireOutPoints[i], newPoint);

            //connect dc to wire
            UtilityFunctions.lineConnect(DCSwitchs[i].top, pole.wireOutPoints[i], 0.03f, 5, -0.25f);
        }
    }
}
