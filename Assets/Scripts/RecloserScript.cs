using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecloserScript : MonoBehaviour {
    [SerializeField] private GameObject stirup;
    [SerializeField] private GameObject[] toSourceWire;
    [SerializeField] private GameObject[] toLoadWire;
    private PoleData pole;
    private GameObject[] jumpers;
    


    // Use this for initialization
    void Start() {
        //recloser only spawn in concrete or crossarm or triangular 
        if(transform.parent.name != "EquipmentSet")
        {
            pole = transform.parent.GetComponent<PoleData>();
            jumpers = new GameObject[3];
            fillWire();
        }
    }

    //will be call when equipment and damage is generated
    public void fillWire()
    {
        for(int i=0; i< 3; i++)
        {
            //recloser to source point
            string newName = "M_" + pole.wireOutPoints[i];
            GameObject newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[i], newName, pole.wireDirection, -1.2f);
            UtilityFunctions.AdjustineConnect(pole.wireInPoints[i], pole.wireOutPoints[i], newPoint);


            //recloser to load point
            string newName2 = "M2_" + pole.wireOutPoints[i];
            GameObject newPoint2 = UtilityFunctions.extendPoint(pole.wireOutPoints[i], newName, pole.wireDirection, -3f);
            UtilityFunctions.AdjustineConnect(newPoint, pole.wireOutPoints[i], newPoint2);


            Vector3 rotation = stirup.transform.eulerAngles;
            if (pole.wireDirection.ToLower().Equals("x"))
                rotation.y += 90;
            jumpers[i] = Instantiate(stirup, pole.wireOutPoints[i].transform.position, Quaternion.Euler(rotation));
            jumpers[i].transform.parent = transform;
            jumpers[i].name = "Jumper" + i;

            UtilityFunctions.lineConnect(toSourceWire[i],newPoint2, 0.02f, 5, -0.3f);
            UtilityFunctions.lineConnect(toLoadWire[i], jumpers[i].GetComponent<JumperScript>().externalWireIn, 0.02f, 5, -0.3f);
        }
    }
}
