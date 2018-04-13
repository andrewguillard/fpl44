using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OHFuseALSScript : MonoBehaviour {
    [SerializeField] private ALSScript[] ALSs;
    private PoleData pole;

    void Start()
    {
        if(transform.parent.name!= "EquipmentSet")
        {
            pole = transform.parent.GetComponent<PoleData>();

            Vector3 rotation = transform.eulerAngles;
            rotation.y -= 90;
            transform.eulerAngles = rotation;

            fillWire();
        }
    }

    void fillWire()
    {   
        //index for array , 1- phaseA, 2-phase B, 3-phase C

        //get wireInPoint and wireOutPoint
        GameObject[] wireInPoints= pole.wireInPoints;
        GameObject[] wireOutPoints = pole.wireOutPoints;

        //extend each point 1.5 meter
        for(int i=0; i< 3; i++)
        {
            string nameOldIn = "M_" + wireInPoints[i].name;
            GameObject oldIn = UtilityFunctions.extendPoint(wireInPoints[i], nameOldIn, pole.GetComponent<PoleData>().wireDirection,1.5f);

            string nameOldOut = "M_" + wireOutPoints[i].name;
            GameObject oldOut = UtilityFunctions.extendPoint(wireOutPoints[i], nameOldIn, pole.GetComponent<PoleData>().wireDirection, -1.5f);

            //connect oldIn and oldOut

            //connect ALS to newIn and NewOut
            UtilityFunctions.lineConnect(ALSs[i].bottom, wireInPoints[i], 0.03f, 5, 0.5f);
            UtilityFunctions.lineConnect(ALSs[i].top, wireOutPoints[i], 0.03f, 5, 0.5f);


        }

    }


    GameObject[] getwireInPoints()
    {
        return null;
    }

    GameObject[] getwireOutPoints()
    {
        return null;
    }

}
