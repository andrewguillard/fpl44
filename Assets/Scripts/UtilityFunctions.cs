using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions : MonoBehaviour
{
    public static void lineConnect(GameObject start, GameObject end, float size)
    {
        if (start.GetComponent<CableScript>() == null)
            start.AddComponent<CableScript>();

        LineRenderer wire = start.GetComponent<LineRenderer>();
        wire.startWidth = size;
        wire.endWidth = size;

        Material yourMaterial = (Material)Resources.Load("Black", typeof(Material));
        if (yourMaterial == null)
            print("can't find line renderer material");
        wire.material = yourMaterial;

        start.GetComponent<CableScript>().setEndPoint(end);
    }

    public static void lineConnect(GameObject start, GameObject end, float size, int numPoint)
    {
        lineConnect(start, end, size);
        start.GetComponent<CableScript>().setPointInLine(numPoint);
    }

    public static void lineConnect(GameObject start, GameObject end, float size, int numPoint, float sagNum)
    {
        lineConnect(start, end, size);
        start.GetComponent<CableScript>().setPointInLine(numPoint);
        start.GetComponent<CableScript>().setSagAmplitude(sagNum);
    }

    public static Transform findInChild(Transform parent, string name)
    {
        if (parent.childCount == 0)
        {
            return ((parent.name.Equals(name)) ? parent : null);
        }

        Transform ret;
        foreach (Transform t in parent)
        {
            ret = UtilityFunctions.findInChild(t, name);
            if (ret != null)
                return ret;
        }

        return null;
    }


    public static GameObject extendPoint(GameObject oldPoint, string newPointName, string moveDirection, float distance)
    {
        float d = Mathf.Abs(distance);

        //copy old point
        GameObject newPoint = new GameObject();
        newPoint.transform.position = oldPoint.transform.position;
        newPoint.transform.parent = oldPoint.transform.parent;

        if (Mathf.Sign(distance) == 1)
        {
            //move point to left
            if (moveDirection == "x")
                oldPoint.transform.position += new Vector3(d, 0.0f, 0.0f);
            else if (moveDirection == "z")
                oldPoint.transform.position += new Vector3(0.0f, 0.0f, d);
        }
        else
        {
            //move point to right
            if (moveDirection == "x")
                oldPoint.transform.position += new Vector3(-d, 0.0f, 0.0f);
            else if (moveDirection == "z")
                oldPoint.transform.position += new Vector3(0.0f, 0.0f, -d);
        }


        //change name
        newPoint.name = newPointName;

        return newPoint;
    }

    public static void AdjustineConnect(GameObject start, GameObject end, GameObject middle)
    {
        CableScript startCable = start.GetComponent<CableScript>();
        if (startCable != null)
        {
            startCable.setEndPoint(middle);
        }
        else
        {
            //no cable script in start
            lineConnect(start, middle, 0.07f, 5, 0.0f);
        }

        //connect middle to end
        lineConnect(middle, end, 0.07f, 5, 0.0f);
    }
}