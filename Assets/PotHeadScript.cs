using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHeadScript : MonoBehaviour {
    private GameObject DCSwitch;
    private GameObject potHead;
    private GameObject pole;
    private string wireDirection;
    readonly string[] pot_DCPoints = { "P1", "P2", "P3" };
    readonly string[] DC_wirePoints = { "P11", "P22", "P33" };
    // Use this for initialization
    void Start() {
        if (DCSwitch == null)
        {
            DCSwitch = transform.Find("DCSwitch").gameObject;
        }
        if (potHead == null)
        {
            potHead = transform.Find("PotHead").gameObject;
        }

        pole = transform.parent.gameObject;

        if (pole.name != "EquipmentSet")
        {
            wireDirection = pole.GetComponent<PoleData>().wireDirection;
            fillWire();

        }
    }

    //call this function when equipment is ready
    public void fillWire()
    {
        //connect pothead to DC-Switch
        GameObject[] potHeadPoints = new GameObject[3];
        GameObject[] switchPoint = new GameObject[3];

        GameObject[] outPoints = getWireOutPoint();
        GameObject[] inPoints = getWireInPoint();

        for (int i = 0; i < 3; i++)
        {
            string name = pot_DCPoints[i];
            potHeadPoints[i] = UtilityFunctions.findInChild(potHead.transform, name).gameObject;
            switchPoint[i] = UtilityFunctions.findInChild(DCSwitch.transform, name).gameObject;

            UtilityFunctions.lineConnect(potHeadPoints[i], switchPoint[i], 0.075f, 5, -0.25f);

            //from DC to wire
            GameObject temp = UtilityFunctions.findInChild(DCSwitch.transform, DC_wirePoints[i]).gameObject;
            UtilityFunctions.lineConnect(temp, outPoints[i], 0.03f, 5, -0.25f);

            UtilityFunctions.lineConnect(inPoints[i], outPoints[i], 0.07f, 5, 0f);


        }



    }

    //connect DC to wire
    GameObject[] getWireOutPoint()
    {
        GameObject[] ret = new GameObject[3];
        //order of array is , phase C->phase B -> phase A
        string[] onWireName = { "2", "1", "3" };
        string[] sNames = { "B1", "A1", "C1" };
        float[] lengths = { -1.0f, 1.0f, 1.0f };
        string[] names = { "B2", "A2", "C2" };

        for (int i = 0; i < 3; i++)
        {
            Transform temp = UtilityFunctions.findInChild(pole.transform, onWireName[i]);

            if (temp != null)
            {
                Transform sPoint = UtilityFunctions.extendPoint(temp.gameObject, names[i], wireDirection, lengths[i]).transform;
                sPoint.name = sNames[i];
                temp.name = names[i];
                ret[i] = temp.gameObject;
                continue;
            }
            else
            {
                temp = UtilityFunctions.findInChild(pole.transform, names[i]);
            }

            //debug
            if (temp == null)
            {
                Debug.LogError("Not found wire out " + pole.name);

            }

            ret[i] = temp.gameObject;
        }
        return ret;
    }

    GameObject[] getWireInPoint()
    {
        GameObject[] ret = new GameObject[3];
        //order of array is , phase C->phase B -> phase A
        string[] sNames = { "B1", "A1", "C1" };
        int i = 0;
        foreach (string s in sNames)
        {
            ret[i++] = UtilityFunctions.findInChild(pole.transform, s).gameObject;
        }

        return ret;
    }


}
