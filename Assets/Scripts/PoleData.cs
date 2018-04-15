using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleData : MonoBehaviour
{
    public Data[] poleData;
    public int poleIndex;
    public string wireDirection;
    public GameObject[] wireInPoints;
    public GameObject[] wireOutPoints;
    public string poleType;
    public List<GameObject> equipments;

    void Start()
    {

    }

    public Data[] getData()
    {
        List<Data> ret = new List<Data>();
        foreach(Transform i in transform)
        {
            Data childData = i.GetComponent<Data>();
            if (childData != null && childData.level != 0)
            {
                ret.Add(childData);
            }

            foreach(Transform anotherI in i)
            {
                Data grandChildData = anotherI.GetComponent<Data>();
                if (grandChildData != null && grandChildData.level != 0)
                {
                    ret.Add(grandChildData);
                }
            }
        }

        return ret.ToArray();
    }

    public string[,] getDataString()
    {
        return null;
    }

}
