using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerTripleScript : MonoBehaviour {
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
        for (int i = 0; i < 3; i++)
        {
            transformers[i].fillWire();

            //extend wire
            GameObject newPoint;
            if (i == 1)
            {
                newPoint = UtilityFunctions.extendPoint(pole.wireInPoints[i], ("M_" + i), pole.wireDirection, 0.7f);
                UtilityFunctions.AdjustineConnect(pole.wireInPoints[i], pole.wireOutPoints[i], newPoint);
                UtilityFunctions.lineConnect(FuseSwitchs[i].top, pole.wireInPoints[i], 0.02f, 5, 0.3f);
            }
            else
            {
                newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[i], ("M_" + i), pole.wireDirection, -1.0f);
                UtilityFunctions.AdjustineConnect(pole.wireInPoints[i], pole.wireOutPoints[i], newPoint);
                UtilityFunctions.lineConnect(FuseSwitchs[i].top, pole.wireOutPoints[i], 0.02f, 5, 0.3f);
            }

        }


    }
}
