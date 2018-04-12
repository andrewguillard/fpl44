using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecloserScript : MonoBehaviour {
    public GameObject stirup;
    private GameObject pole;
    private string wireDirection;
    private List<GameObject> wirePoint;
    // Use this for initialization
    void Start() {
        //recloser only spawn in concrete or crossarm or triangular 
        pole = transform.parent.gameObject;
        if(pole.name != "EquipmentSet")
        {
            wirePoint = new List<GameObject>();
            wireDirection = pole.GetComponent<PoleData>().wireDirection;
            fillWire();
        }
    }

    //will be call when equipment and damage is generated
    public void fillWire()
    {
        //get wire going out point
        GameObject[] wireOutPoints = getWireOutPoint();

        //getWirein
        GameObject[] wireInPoints = getWireInPoint();
        stirup.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            //extend 1st time
            string newName = wireOutPoints[i].name + ".0" +i;
            GameObject temp = UtilityFunctions.extendPoint(wireOutPoints[i], newName, wireDirection, -1.2f);

            //extend 2nd time
            newName = wireOutPoints[i].name + ".0" + (i+1);
            GameObject temp2= UtilityFunctions.extendPoint(wireOutPoints[i], newName,wireDirection, -3f);

            //connect all points
            if (wireInPoints[i].GetComponent<CableScript>() != null)
            {
                //change end point to temp
                wireInPoints[i].GetComponent<CableScript>().setEndPoint(temp);
            }
            else
            {
                UtilityFunctions.lineConnect(wireInPoints[i], temp, 0.07f, 2, 0.0f);
            }
            UtilityFunctions.lineConnect(temp, temp2, 0.07f, 2, 0.0f);
            UtilityFunctions.lineConnect(temp2,wireOutPoints[i], 0.07f, 2, 0.0f);


            //connect from recloser to line
            string reclosePointName = "Point" + (i + 1);
            GameObject recloserPoint = UtilityFunctions.findInChild(transform, reclosePointName).gameObject;
            UtilityFunctions.lineConnect(recloserPoint, temp2, 0.02f,5 ,-0.3f);

            name = "Point" + (i + 4);
            recloserPoint = UtilityFunctions.findInChild(transform, name).gameObject;

            Vector3 rotation = stirup.transform.rotation.eulerAngles;
            rotation.y += 90;
            GameObject jumper = Instantiate(stirup, wireOutPoints[i].transform.position, Quaternion.Euler(rotation));
            jumper.transform.parent = transform;
            UtilityFunctions.lineConnect(recloserPoint,jumper.transform.Find("ExWireIn").gameObject, 0.02f, 5, -0.3f);


        }
        stirup.SetActive(false);
    }

    GameObject[] getWireOutPoint()
    {
        GameObject[] ret = new GameObject[3];
        //order of array is , phase C->phase B -> phase A
        string[] sNames = { "A1", "B1", "C1" };
        string[] names = { "A2", "B2", "C2" };

        for (int i = 3; i >=1; i--) {
            Transform temp = UtilityFunctions.findInChild(pole.transform, i.ToString());

            if (temp != null)
            {
                Transform sPoint = UtilityFunctions.extendPoint(temp.gameObject, names[i - 1], wireDirection, -0.1f).transform;
                sPoint.name = sNames[i - 1];
                temp.name = names[i - 1];
                ret[3 - i] = temp.gameObject;
                continue;
            }
            else
            {
                temp = UtilityFunctions.findInChild(pole.transform, names[i - 1]);
            }

            //debug
            if (temp == null)
            {
                Debug.LogError("Not found wire out " + pole.name);

            }

            ret[3 - i] = temp.gameObject;
        }
        return ret;
    }

    GameObject[] getWireInPoint()
    {
        GameObject[] ret = new GameObject[3];
        //order of array is , phase C->phase B -> phase A
        string[] sNames = { "C1", "B1", "A1" };
        int i = 0;
        foreach(string s in sNames)
        {
            ret[i++] = UtilityFunctions.findInChild(pole.transform, s).gameObject;
        }

        return ret;
    }
}
