using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions : MonoBehaviour
{
    //public GameObject s;
    //public GameObject end;
    //public void Start()
    //{
    //    UtilityFunctions.lineConnect(s, end, 0.07f);
    //}
    //public void Update()
    //{
    //    UtilityFunctions.lineConnect(s, end, 0.07f);
    //}

    public static void lineConnect(GameObject start, GameObject end, float size)
    {
        if (start.GetComponent<CableScript>() == null)
            start.AddComponent<CableScript>();


        LineRenderer wire = start.GetComponent<LineRenderer>();

        wire.SetWidth(size, size);
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
}