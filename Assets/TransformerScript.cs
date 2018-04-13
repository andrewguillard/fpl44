using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerScript : MonoBehaviour {

    [SerializeField] private GameObject FuseSwitch;
    [SerializeField] private GameObject FSTop;
    [SerializeField] private GameObject FSBottom;
    [SerializeField] private GameObject Insulator_FS;
    [SerializeField] private GameObject Insulator1;
    [SerializeField] private GameObject Arrester1;
    [SerializeField] private string phase;
    [SerializeField] private GameObject pole;


    void Start()
    {
        if (transform.parent.parent.name != "EquipmentSet")
        {
            pole = transform.parent.parent.gameObject;
            fillWire();
        }

    }

    void fillWire()
    {
        //fill wire between transformer and FuseSwitch
        UtilityFunctions.lineConnect(Arrester1, Insulator1, 0.02f, 5, -0.3f);
        UtilityFunctions.lineConnect(Insulator_FS, FSBottom, 0.02f, 5, -0.2f);

        //connecFuseswitch to pole
        switch (phase)
        {
            case "A":
                break;
            case "B":
                break;
            case "C":
                break;
        }

        //connect wire

    }



    


}
