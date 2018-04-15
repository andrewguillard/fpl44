using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    public string equipmentName;
    public char phase;
    public int level;

    public int extraIndex;
    public string subName;
    public void setData(Data d)
    {
        equipmentName= d.equipmentName;
        phase = d.phase;
        level = d.level;
    }

    public void printData()
    {
        print(equipmentName + "-" + phase + "-" + level);
    }
}
