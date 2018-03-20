using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapicatorBank : MonoBehaviour
{



    public  GameObject[] capcitorBank;
    //public GameObject[] fuseSwitch;
    //public GameObject[] lightningArrester;
    //public GameObject[] recloser;
    //public GameObject[] overheadFSwitchALS;
    //public GameObject[] disconnectSwitch;
    //public GameObject[] ballon;
    //public GameObject[] tree;

    public  Transform[] spawnCapacitorBank;
    //public Transform[] spawnFuseSwitch;
    //public Transform[] spawnLightningArrester;
    //public Transform[] spawnRecloser;
    //public Transform[] spawnOverheadFSwitchALS;
    //public Transform[] spawnDisconnectSwitch;
    //public Transform[] spawnBallon;
    //public Transform[] spawnTree;

    //public  EquipmentSpawner newEquip = new EquipmentSpawner();


    public void generateCapcitorBank(int i) {

        Vector3 BankVec = new Vector3(spawnCapacitorBank[i].transform.position.x, spawnCapacitorBank[i].transform.position.y, spawnCapacitorBank[i].transform.position.z );
        Instantiate(capcitorBank[0], BankVec, Quaternion.identity);
    }


    void Start() { }


    }
    /*
    public void generateFuseSwitch(int i)
    {
        if (i <= 9) {


        }

    }
    public void generateLightningarrestor(int i) {
        {
            if (i <= 9)
            {


            }

        }
        // Use this for initialization

        }
         */
  