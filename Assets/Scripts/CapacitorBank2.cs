using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacitorBank2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //make points for jumper
        connectToJumper(transform.parent.gameObject, "x");

        string[] phases = { "A", "B", "C" };
        
        //connect transformer to fuse switch
        for(int i = 0; i < phases.Length; i++)
        {
            string sname = phases[i] ;
            string ename = phases[i] + "2";
            string topName = phases[i] + "3";

            GameObject sPoint = transform.Find(sname).gameObject;
            GameObject ePoint = transform.Find(ename).gameObject;
            GameObject topPoint = transform.Find(topName).gameObject;

            if (sPoint == null || ePoint == null)
            {
                print("can't find start point or end point in capacitor bank wire connection");

            }

            UtilityFunctions.lineConnect(sPoint, ePoint, 0.03f,5,0.7f);

            //find powerline and connect fuseswitch with line
            GameObject linePoint;
            if (phases[i] == "B")
            {
                 linePoint = transform.parent.Find(sname + "2").gameObject;
            }
            else
            {
                linePoint = transform.parent.Find(sname + "1").gameObject;
            }

            UtilityFunctions.lineConnect(topPoint, linePoint, 0.02f, 5, 0.03f);


        }


    }

    public void connectToJumper(GameObject pole, string lineDirection)
    {
        //in the pole has 2 system (3 point marker, and 6 points marker)
        bool is123 = find123Marker(pole);
        GameObject newA, newB, newC;
        if (is123)
        {
            set123toABC(pole,lineDirection);    
        }
        else
        {
            setABCtoAMBMCM(pole, lineDirection);
        }

        
        ////base on line direction , I can decide which way to move the point x or z
        //GameObject newA = new GameObject(jumper);
        ////move points 
        //if (lineDirection.ToLower() == "x")
        //    A.transform.Translate(0.5f, 0.0f, 0.0f);
        //else
        //    A.transform.Translate(0.0f, 0.0f, 0.5f);

        
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

    }
	
    GameObject createNewPoint(GameObject old, string moveDirection, float distance,string Name)
    {
        float d = Mathf.Abs(distance);
        GameObject ret = new GameObject();
        ret.transform.position = old.transform.position;
        if (moveDirection == "x")
            ret.transform.Translate(d, 0.0f, 0.0f);
        else if (moveDirection == "y")
            ret.transform.Translate(0.0f, d, 0.0f);
        else
            ret.transform.Translate(0.0f, 0.0f, d);

        ret.transform.parent = old.transform.parent;

        if(Mathf.Sign(distance) == -1)
        {
            //move point to right
            if (moveDirection == "x")
            {
                ret.transform.Translate(distance, 0.0f, 0.0f);
                old.transform.Translate(distance, 0.0f, 0.0f);

            }
            else if (moveDirection == "y")
            {
                ret.transform.Translate(0.0f, distance, 0.0f);
                old.transform.Translate(0.0f, distance, 0.0f);

            }
            else
            {
                ret.transform.Translate(0.0f, 0.0f, distance);
                old.transform.Translate(0.0f, 0.0f, distance);

            }
        }

        //change name
        ret.name = Name + "1";
        old.name = Name + "2";

        //connect 2 points with wire
        UtilityFunctions.lineConnect(ret, old, 0.07f, 5,0.01f);

        return ret;
    }
}
