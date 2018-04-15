using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArresterScript : MonoBehaviour {
    [SerializeField] private GameObject v;
    [SerializeField] private GameObject mv;
    [SerializeField] private GameObject t;
    [SerializeField] private GameObject cWood;
    [SerializeField] private GameObject cConcrete;
    [SerializeField] private GameObject c2Wood;
    [SerializeField] private GameObject c2Concrete;
    private GameObject pole;
    public LAScript currentLA;
    void Awake()
    {
        if (transform.parent.name != "EquipmentSet")
        {
            pole = transform.parent.gameObject;
            getLA(pole.GetComponent<PoleData>().poleType);

            foreach(Transform t in transform)
            {
                if(t.gameObject.activeSelf == false)
                {
                    Destroy(t.gameObject);
                }
            }
            fillWire();

        }
    }

    void getLA(string poleType)
    {
        switch (poleType)
        {
            case "VConcrete":
            case "VWood":
                currentLA = v.GetComponent<LAScript>();
                v.SetActive(true);
                cConcrete.SetActive(false);
                cWood.SetActive(false);
                c2Wood.SetActive(false);
                c2Concrete.SetActive(false);
                t.SetActive(false);
                break;
            case "MVConcrete":
            case "MVWood":
                currentLA = v.GetComponent<LAScript>();
                mv.SetActive(true);
                cConcrete.SetActive(false);
                cWood.SetActive(false);
                c2Wood.SetActive(false);
                c2Concrete.SetActive(false);
                t.SetActive(false);
                break;
            case "TConcrete":
            case "TWood":
                currentLA = t.GetComponent<LAScript>();
                t.SetActive(true);
                cConcrete.SetActive(false);
                cWood.SetActive(false);
                c2Wood.SetActive(false);
                c2Concrete.SetActive(false);
                v.SetActive(false);
                mv.SetActive(false);
                break;
            case "CConcrete":
                currentLA = cConcrete.GetComponent<LAScript>();
                cConcrete.SetActive(true);
                cWood.SetActive(false);
                c2Wood.SetActive(false);
                c2Concrete.SetActive(false);
                v.SetActive(false);
                mv.SetActive(false);
                t.SetActive(false);
                break;
            case "CWood":
                currentLA = cWood.GetComponent<LAScript>();
                cWood.SetActive(true);
                cConcrete.SetActive(false);
                c2Wood.SetActive(false);
                c2Concrete.SetActive(false);
                v.SetActive(false);
                mv.SetActive(false);
                t.SetActive(false);
                break;
            case "C2Concrete":
                currentLA = c2Concrete.GetComponent<LAScript>();
                c2Concrete.SetActive(true);
                cConcrete.SetActive(false);
                cWood.SetActive(false);
                c2Wood.SetActive(false);
                v.SetActive(false);
                mv.SetActive(false);
                t.SetActive(false);
                break;
            case "C2Wood":
                currentLA = c2Wood.GetComponent<LAScript>();
                c2Wood.SetActive(true);
                cConcrete.SetActive(false);
                cWood.SetActive(false);
                c2Concrete.SetActive(false);
                v.SetActive(false);
                mv.SetActive(false);
                t.SetActive(false);
                break;

        }
    }

    void fillWire()
    {
        PoleData poleData = pole.GetComponent<PoleData>();
        if(currentLA.gameObject == c2Concrete || currentLA.gameObject == c2Wood || currentLA.gameObject == cWood)
            for (int i=0; i < 3; i++)
            {
                    //extend points;
                    GameObject newPoint = UtilityFunctions.extendPoint(poleData.wireInPoints[i], ("M_" + i),poleData.wireDirection, 0.7f);
                    UtilityFunctions.AdjustineConnect(poleData.wireInPoints[i], poleData.wireOutPoints[i], newPoint);
                    UtilityFunctions.lineConnect(currentLA.topPoints[i], poleData.wireInPoints[i], 0.02f, 3, 0.2f);
            }
        else if(currentLA.gameObject == cConcrete)
        {
            for (int i = 0; i < 3; i++)
            {
                //extend points;
                GameObject newPoint = UtilityFunctions.extendPoint(poleData.wireOutPoints[i], ("M_" + i), poleData.wireDirection, -0.7f);
                UtilityFunctions.AdjustineConnect(poleData.wireInPoints[i], poleData.wireOutPoints[i], newPoint);
                UtilityFunctions.lineConnect(currentLA.topPoints[i], poleData.wireOutPoints[i], 0.02f, 3, 0.2f);
            }
        }
        else if(currentLA.gameObject == v || currentLA.gameObject == mv)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject newPoint;
                //extend points;
                 if (i == 0)
                    newPoint = UtilityFunctions.extendPoint(poleData.wireInPoints[i], ("M_" + i), poleData.wireDirection,0.7f);
                else
                    newPoint = UtilityFunctions.extendPoint(poleData.wireInPoints[i], ("M_" + i), poleData.wireDirection,-0.7f);
                UtilityFunctions.AdjustineConnect(poleData.wireInPoints[i], poleData.wireOutPoints[i], newPoint);
                UtilityFunctions.lineConnect(currentLA.topPoints[i], poleData.wireInPoints[i], 0.07f, 3, 0.3f);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject newPoint;
                //extend points;
                if (i == 2)
                     newPoint= UtilityFunctions.extendPoint(poleData.wireInPoints[i], ("M_" + i), poleData.wireDirection, -0.7f);
                else if(i ==1)
                    newPoint = UtilityFunctions.extendPoint(poleData.wireInPoints[i], ("M_" + i), poleData.wireDirection, 1f);
                else
                    newPoint = UtilityFunctions.extendPoint(poleData.wireInPoints[i], ("M_" + i), poleData.wireDirection, 0.7f);

                UtilityFunctions.AdjustineConnect(poleData.wireInPoints[i], poleData.wireOutPoints[i], newPoint);
                UtilityFunctions.lineConnect(currentLA.topPoints[i], poleData.wireInPoints[i], 0.07f, 5, 0.3f);
            }
        }


        //fill location of equipment location need to swap
        DamagesScript damageScript = transform.GetComponent<DamagesScript>();
        damageScript.equipLocation = new GameObject[3];
        if (damageScript == null)
        {
            Debug.LogError("can't find damageScript");
        }
        for (int i = 0; i < 3; i++)
        {

            damageScript.equipLocation[i] = currentLA.GetComponent<LAScript>().insulator[i];
        }

    }
}
