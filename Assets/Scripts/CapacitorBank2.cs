using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text.RegularExpressions;

public class CapacitorBank2 : MonoBehaviour {

    void Start()
    {
        Transform parent = transform.parent;
        if (parent.GetComponent<PoleData>() !=null)
        {
            List<GameObject> fuseSwitch = new List<GameObject>();
            //initiate pole , bring fuse switch out
            foreach (Transform child in transform)
            {

                if (child.name == "FuseSwitch")
                {
                    fuseSwitch.Add(child.gameObject);
                }
            }
            changeParent(fuseSwitch, parent.gameObject);

        }
    }

    //Use this for initialization
    public void fillwire()
    {
        int poleIndex = 0;
        //get wireDirection from name
        string[] numbers = Regex.Split(transform.parent.name, @"\D+");
        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                poleIndex = int.Parse(value);
            }
        }

        if (poleIndex < 10)  //need to figure out how to get this number 10
            fillwire("x");
        else
            fillwire("z");
    }

	//overloaded -  Use this for initialization
	public void fillwire (string wireDirection) {
        print("at " + transform.parent +" | " + transform);
        //make points for jumper
        connectToJumper(transform.parent.gameObject, wireDirection);

        string[] phases = { "A", "B", "C" };
        
        //connect capacitor to fuse switch
        for(int i = 0; i < phases.Length; i++)
        {
            string sname = "CB"+phases[i]+"1" ;
            string ename = "CB"+phases[i] + "2";

            GameObject sPoint = transform.Find(sname).gameObject;
            GameObject ePoint = transform.Find(ename).gameObject;

            if (sPoint == null || ePoint == null)
            {
                print("can't find start point or end point in capacitor bank wire connection");

            }

            //connect capacitor to fuse switch
            UtilityFunctions.lineConnect(sPoint, ePoint, 0.03f,5,0.7f);


            //find powerline and connect fuseswitch to powerline
            string topName = "CB" + phases[i] + "3"; //point on top of fuseswitch
            GameObject topPoint = transform.Find(topName).gameObject;
            GameObject linePoint;
            if (i==1)
            {
                 linePoint = transform.parent.Find(phases[i] + "2").gameObject;
            }
            else
            {
                linePoint = transform.parent.Find(phases[i]+ "1").gameObject;
            }

            UtilityFunctions.lineConnect(topPoint, linePoint, 0.02f, 5, 0.03f);


        }


    }

    public void connectToJumper(GameObject pole, string lineDirection)
    {
        //in the pole has 2 system (3 point marker, and 6 points marker)
        bool is123 = find123Marker(pole);
        if (is123)
        {
            set123toABC(pole,lineDirection);    
        }
        else
        {
            setABCtoAMBMCM(pole, lineDirection);
        }
    }

    bool find123Marker(GameObject pole)
    {
        Transform temp = pole.transform;
        if (temp.Find("1") != null && temp.Find("2") != null && temp.Find("3") != null)
            return true;
        return false;
    }

    void set123toABC(GameObject pole, string lineDirection)
    {
        //find 123
        GameObject old1 = pole.transform.Find("1").gameObject;
        GameObject old2 = pole.transform.Find("2").gameObject;
        GameObject old3 = pole.transform.Find("3").gameObject;

        //create new a,b,c
        GameObject newA = createNewPoint(old1, lineDirection, 0.5f,"A" );
        GameObject newB = createNewPoint(old2, lineDirection,-0.5f,"B");
        GameObject newC = createNewPoint(old3, lineDirection,0.8f,"C");

    }

    void setABCtoAMBMCM(GameObject pole, string lineDirection)
    {
        print("\t\t"+pole.transform.parent.name+"\t"+pole.name);
        //move a1 b2 and c1
        GameObject old1 = pole.transform.Find("A1").gameObject;
        GameObject old2 = pole.transform.Find("B2").gameObject;
        GameObject old3 = pole.transform.Find("C1").gameObject;

        //create new a,b,c
        GameObject newA = createNewPoint(old1, lineDirection, 0.5f, "A");
        GameObject newB = createNewPoint(old2, lineDirection, -0.5f, "B");
        GameObject newC = createNewPoint(old3, lineDirection, 0.8f, "C");
    }
	
    GameObject createNewPoint(GameObject old, string moveDirection, float distance,string Name)
    {
        float d = Mathf.Abs(distance);

        GameObject ret = new GameObject();
        ret.transform.position = old.transform.position;
        ret.transform.parent = old.transform.parent;

        if (Mathf.Sign(distance) == 1)
        {
            //move point to left
            if (moveDirection == "x")
                old.transform.position += new Vector3(d, 0.0f, 0.0f);
            else if (moveDirection == "z")
                old.transform.position += new Vector3(0.0f, 0.0f, d);
        }
        else
        {
            //move point to right
            if (moveDirection == "x")
                ret.transform.position -= new Vector3(d, 0.0f, 0.0f);
            else if (moveDirection == "z")
                ret.transform.position -= new Vector3(0.0f, 0.0f, d);
        }
   

        //change name
        old.name = Name + "1";
        ret.name = Name + "2";

        //connect 2 points with wire
        UtilityFunctions.lineConnect(old, ret, 0.07f, 5,0.01f);

        return ret;
    }

    void changeParent(GameObject child, GameObject parent)
    {
        child.transform.parent = parent.transform;
    }

    void changeParent(List<GameObject> children, GameObject parent)
    {
        foreach(GameObject child in children)
        {
            child.transform.parent = parent.transform;
        }
    }
}
