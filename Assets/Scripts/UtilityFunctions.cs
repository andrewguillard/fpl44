
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

        Material yourMaterial = (Material)Resources.Load("Black", typeof(Material));
        if (yourMaterial == null)
            print("can't find line renderer material");
        wire.material = yourMaterial;

        wire.startWidth = size;
        wire.endWidth = size;

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
        if (middle.GetComponent<CableScript>() ==null)
        {
            lineConnect(middle, end, 0.07f, 5, 0.0f);
        }
        else
        {
            middle.GetComponent<CableScript>().setEndPoint(end);
        }
    }

	public static GameObject replaceObject(GameObject oldObject, GameObject damagePrefab)
	{
		GameObject newObject;
		newObject = Instantiate(damagePrefab);
		newObject.name = oldObject.name;

		newObject.transform.parent = oldObject.transform.parent;
		newObject.transform.localPosition = oldObject.transform.localPosition;
		newObject.transform.localRotation = oldObject.transform.localRotation;
		newObject.transform.localScale = oldObject.transform.localScale;

		DestroyImmediate (oldObject);
        //oldObject.SetActive(false);

        print("In " + newObject.transform.parent.name + " replace with " + newObject.name + newObject.GetComponent<Data>().level );

        return newObject;
	}

    //find all children object in a gameobject
    public static GameObject[] getChildObjects(GameObject parent)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            temp.Add(child.gameObject);
        }

        return temp.ToArray();
    }

    public static T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}