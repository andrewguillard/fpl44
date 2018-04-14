using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerDouble : MonoBehaviour {
    [SerializeField] private FuseSwitchScript[] FuseSwitchs;
    [SerializeField] private TransformerScript[] transformers;
    private PoleData pole;
    void Start()
    {
        if (transform.parent.name != "EquipmentSet")
        {
            pole = transform.parent.GetComponent<PoleData>();
            fillWire();
        }
    }

    void fillWire()
    {
        int[] rNums = new int[2];
        for(int i=0; i< 2; i++)
        {
            int temp = Random.Range(0, 3);
            while (i == 1 && temp == rNums[0])
                temp = Random.Range(0, 3);
            rNums[i] = temp;
        }

        for (int i = 0; i < 2; i++)
        {
            transformers[i].fillWire();

            //extend wire
            GameObject newPoint;
            if (i != 0)
            {
                newPoint = UtilityFunctions.extendPoint(pole.wireInPoints[rNums[i]], ("M_" + rNums[i]), pole.wireDirection, 0.7f);
                UtilityFunctions.AdjustineConnect(pole.wireInPoints[rNums[i]], pole.wireOutPoints[rNums[i]], newPoint);
                UtilityFunctions.lineConnect(FuseSwitchs[i].top, pole.wireInPoints[rNums[i]], 0.02f, 5, 0.3f);
            }
            else
            {
                newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[rNums[i]], ("M_" + rNums[i]), pole.wireDirection, -0.7f);
                UtilityFunctions.AdjustineConnect(pole.wireInPoints[rNums[i]], pole.wireOutPoints[rNums[i]], newPoint);
                UtilityFunctions.lineConnect(FuseSwitchs[i].top, pole.wireOutPoints[rNums[i]], 0.02f, 5, 0.3f);
            }

        }


    }
}
