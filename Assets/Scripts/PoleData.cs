using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleData : MonoBehaviour
{
    public Data[] poleData;

    void Start()
    {
        poleData = getData();
        foreach(Data i in poleData)
        {
            i.printData();
        }
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
}
