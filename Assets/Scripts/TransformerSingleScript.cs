using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerSingleScript : MonoBehaviour {
    [SerializeField] private FuseSwitchScript FuseSwitch;
    [SerializeField] private TransformerScript transformer;
    private PoleData pole;
    void Start()
    {
        if(transform.parent.name != "EquipmentSet"  && transform.parent.name != "DamageSet")
        {
            pole = transform.parent.GetComponent<PoleData>();

            fillWire();
        }
    }

    void fillWire()
    {
        print(transform.parent.name + "/" + transform.name);
        Transform temp = transform.Find("Transformer");
        if( temp== null)
        {
            //debug;
            StartCoroutine(wait(3));
        }
        else
        {
            transformer = temp.gameObject.GetComponent<TransformerScript>();
        }

        if(transformer == null)
        transformer.fillWire();

        //connect fuse switch to wire
        int rNum = Random.Range(0, 3);

        //extend wire
        GameObject newPoint;
        //if (rNum != 1)
        //{
        //    newPoint = UtilityFunctions.extendPoint(pole.wireInPoints[rNum], ("M_" + rNum), pole.wireDirection,0.7f);
        //    UtilityFunctions.AdjustineConnect(pole.wireInPoints[rNum], pole.wireOutPoints[rNum], newPoint);
        //    UtilityFunctions.lineConnect(FuseSwitch.top, pole.wireInPoints[rNum], 0.02f, 5, 0.3f);
        //}
        //else
        //{
        print(transform.parent);
            newPoint = UtilityFunctions.extendPoint(pole.wireOutPoints[rNum], ("M_" + rNum), pole.wireDirection, -0.7f);
            UtilityFunctions.AdjustineConnect(pole.wireInPoints[rNum], pole.wireOutPoints[rNum], newPoint);
            UtilityFunctions.lineConnect(FuseSwitch.top, pole.wireOutPoints[rNum], 0.02f, 5, 0.3f);
        //}


    }

    IEnumerator wait(int time)
    {
        yield return new WaitForSeconds(time);
    }

}
