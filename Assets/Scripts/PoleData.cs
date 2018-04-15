using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleData : MonoBehaviour
{
    Data[] poleData;
    public int poleIndex;
    public string wireDirection;
    public GameObject[] wireInPoints;
    public GameObject[] wireOutPoints;
    public string poleType;
    public List<GameObject> equipments;

    void Start()
    {
        poleData = getData();
    }

    public Data[] getData()
    {
        List<Data> ret = new List<Data>();
        foreach(Transform i in transform)
        {
            Data childData = i.GetComponent<Data>();
            if (childData != null)
            {
                ret.Add(childData);
            }
        }

        return ret.ToArray();
    }

    public string[,] getDataString()
    {
        return null;
    }

}
