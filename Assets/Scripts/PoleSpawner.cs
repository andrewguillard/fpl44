using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PoleSpawner : MonoBehaviour
{
    public Transform[] spawnPoleLocation; //Location of each pole

    ///
    /// INSULATORS
    ///
    public Transform[] spawnLocationVerticalA;
    public Transform[] spawnLocationVerticalB;
    public Transform[] spawnLocationVerticalC;

    public Transform[] spawnLocationModVerticalA;
    public Transform[] spawnLocationModVerticalB;
    public Transform[] spawnLocationModVerticalC;

    public Transform[] spawnLocationTriangularA;
    public Transform[] spawnLocationTriangularB;
    public Transform[] spawnLocationTriangularC;

    public Transform[] spawnLocationCrossarmA;
    public Transform[] spawnLocationCrossarmB;
    public Transform[] spawnLocationCrossarmC;

    //These are just for the crossarm backs
    public Transform[] spawnCrossarmBackWood;
    public Transform[] spawnCrossarmBackConcrete;
    public GameObject[] crossarmBackMaterial;

    public GameObject[] insulatorMaterial; //this is only one atm.
    public GameObject[] poleMaterial; //this is either wood or concrete atm.
    public GameObject[] arrayOfPoles;

    public GameObject[] poleMaterialWood;
    public GameObject[] poleMaterialConcrete;

    public GameObject[] capcitorBank;
    public Transform[] spawnCapacitorBank;

    public GameObject[] fuseSwitchHolderMaterial;
    public Transform[] spawnFuseSwitchHolder;

    public GameObject[] fuseSwitchMaterial;
    public Transform[] spawnFuseSwitchLeft;
    public Transform[] spawnFuseSwitchMiddle;
    public Transform[] spawnFuseSwitchRight;

    public GameObject[] recloserMaterial;
    public Transform[] spawnRecloser;

    public GameObject[] transformerMaterial;
    public Transform[] spawnTransformerLeft;
    public Transform[] spawnTransformerMiddle;
    public Transform[] spawnTransformerRight;

    public GameObject[] CAFMaterial;
    public Transform[] spawnCAFLocation;

    public GameObject[] afsMaterial;
    public Transform[] spawnAfs;

    public GameObject[] potheadMaterial;
    public Transform[] spawnPothead;

    public GameObject[] dcSwitchMaterial;
    public Transform[] spawnDcSwitch;

    public GameObject[] automaticLineSwitchMaterial;
    public Transform[] spawnAutomaticLineSwitch;

    public GameObject[] treeMaterial;
    public Transform[] spawnTreeLoc5;
    public Transform[] spawnTreeLoc3;
    public Transform[] spawnTreeLoc1;
    public Transform[] spawnTreeLoc0;

    public GameObject[] nestMaterial;
    public Transform[] spawnNest;

    public GameObject[] balloonMaterial;
    public Transform[] spawnBalloon;

    public GameObject[] laMaterial;
    public Transform[] spawnLaBottom;
    public Transform[] spawnLaMiddle;
    public Transform[] spawnLaTop;

    private int randomInt;

    List<string> poleTypes = new List<string>(new string[] { "Vertical", "ModVertical", "Triangular", "Crossarm" });


    //utility function to be able to use random range anywhere.
    public int getRandom(int x)  {

        randomInt = Random.Range(0, x);
        return randomInt;
    }

    PoleObject[] poleObjectArray = new PoleObject[21];

    //
    // Insulator generation functions
    //

    public void generateVerticalInsulators(int i, Vector3 loc, List<string> shuffle) {
        GameObject[] insulator = new GameObject[3];
        int t = 0;

        //if the poles are along the x axis (W->E)
        if (i <= 9)  {

            //This is going to rotate the insulator and then spawn it.
            Quaternion rotateInsulator = Quaternion.Euler(-90, 0, 0);
            Vector3 locA = new Vector3(spawnLocationVerticalA[i].transform.position.x, spawnLocationVerticalA[i].transform.position.y, spawnLocationVerticalA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationVerticalB[i].transform.position.x, spawnLocationVerticalB[i].transform.position.y, spawnLocationVerticalB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationVerticalC[i].transform.position.x, spawnLocationVerticalC[i].transform.position.y, spawnLocationVerticalC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator);


            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if(poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if(poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            poleObjectArray[i].setInsulatorType("V");
        }
        //if the poles are along the z axis (S->N)
        else if (i > 9) {

            //This is going to rotate the insulator and then spawn it.
            Quaternion rotateInsulator = Quaternion.Euler(0, 0, -90);
            Vector3 locA = new Vector3(spawnLocationVerticalA[i].transform.position.x, spawnLocationVerticalA[i].transform.position.y, spawnLocationVerticalA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationVerticalB[i].transform.position.x, spawnLocationVerticalB[i].transform.position.y, spawnLocationVerticalB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationVerticalC[i].transform.position.x, spawnLocationVerticalC[i].transform.position.y, spawnLocationVerticalC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            poleObjectArray[i].setInsulatorType("V");
        }

        GameObject[] wireLoc = new GameObject[3];
        arrayOfPoles[i].name = "Vertical" + i;
        for(int j=0; j< insulator.Length; j++)
        {
            insulator[j].transform.parent = arrayOfPoles[i].transform;
            insulator[j].name = "Insulator" + (j + 1);
            
            wireLoc[j] = insulator[j].transform.Find("Bottom").gameObject;
            wireLoc[j].transform.parent = arrayOfPoles[i].transform;
        }


        //change wire location to the right wire phase (1->phase a, 2-> b, 3-> c)
        wireLoc= wireLoc.OrderBy(wire => wire.transform.position.y).ToArray();
        string[] name = { "3","1" ,"2"};//b a c
        for (int j =0; j<wireLoc.Length ; j++)
        {
            wireLoc[j].name = name[j];

        }
    }

    public void generateModVerticalInsulators(int i, Vector3 loc, List<string> shuffle) {
        GameObject[] insulator = new GameObject[3];
        int t = 0;

        if (i <= 9)
        {
            //Spawn the B insulator w/o rotating
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationModVerticalB[i].transform.position.x, spawnLocationModVerticalB[i].transform.position.y, spawnLocationModVerticalB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the insulator and spawn
            Quaternion rotateInsulator2 = Quaternion.Euler(-90, 0, 0);
            Vector3 locA = new Vector3(spawnLocationModVerticalA[i].transform.position.x, spawnLocationModVerticalA[i].transform.position.y, spawnLocationModVerticalA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator2);

            Vector3 locC = new Vector3(spawnLocationModVerticalC[i].transform.position.x, spawnLocationModVerticalC[i].transform.position.y, spawnLocationModVerticalC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator2);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            poleObjectArray[i].setInsulatorType("M");
        }

        //if the poles are along the z axis (S->N)
        else if (i > 9) {
            //Spawn the B insulator w/o rotating
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationModVerticalB[i].transform.position.x, spawnLocationModVerticalB[i].transform.position.y, spawnLocationModVerticalB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the insulator and spawn
            Quaternion rotateInsulator2 = Quaternion.Euler(0, 0, -90);
            Vector3 locA = new Vector3(spawnLocationModVerticalA[i].transform.position.x, spawnLocationModVerticalA[i].transform.position.y, spawnLocationModVerticalA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator2);

            Vector3 locC = new Vector3(spawnLocationModVerticalC[i].transform.position.x, spawnLocationModVerticalC[i].transform.position.y, spawnLocationModVerticalC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator2);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            poleObjectArray[i].setInsulatorType("M");
        }
        GameObject[] wireLoc = new GameObject[3];

        arrayOfPoles[i].name = "ModVertical" + i;
        for (int j = 0; j < insulator.Length; j++)
        {
            insulator[j].name = "Insulator" + (j+1);
            insulator[j].transform.parent = arrayOfPoles[i].transform;
            wireLoc[j] = insulator[j].transform.Find("Bottom").gameObject;
            wireLoc[j].transform.parent = arrayOfPoles[i].transform;
        }

        //change wire location to the right wire phase (1->phase a, 2-> b, 3-> c)
        wireLoc = wireLoc.OrderBy(wire => wire.transform.position.y).ToArray();
        string[] name = { "3", "1", "2" };//b a c
        for (int j = 0; j < wireLoc.Length; j++)
        {
            wireLoc[j].name = name[j];

        }
    }

    public void generateTriangularInsulators(int i, Vector3 loc, List<string> shuffle) {
        GameObject[] insulator = new GameObject[3];
        int t = 0;

        if (i <= 9)
        {
            //Spawn the B insulator and rotate
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationTriangularB[i].transform.position.x, spawnLocationTriangularB[i].transform.position.y, spawnLocationTriangularB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the C insulator
            Quaternion rotateInsulator2 = Quaternion.Euler(90, 0, 0);
            Vector3 locC = new Vector3(spawnLocationTriangularC[i].transform.position.x, spawnLocationTriangularC[i].transform.position.y, spawnLocationTriangularC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator2);

            //Rotate A now
            Quaternion rotateInsulator3 = Quaternion.Euler(-90, 0, 0);
            Vector3 locA = new Vector3(spawnLocationTriangularA[i].transform.position.x, spawnLocationTriangularA[i].transform.position.y, spawnLocationTriangularA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator3);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            poleObjectArray[i].setInsulatorType("T");
        }

        else if (i > 9) {

            //Spawn the B insulator and rotate
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationTriangularB[i].transform.position.x, spawnLocationTriangularB[i].transform.position.y, spawnLocationTriangularB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the C insulator
            Quaternion rotateInsulator2 = Quaternion.Euler(0, 0, 90);
            Vector3 locC = new Vector3(spawnLocationTriangularC[i].transform.position.x, spawnLocationTriangularC[i].transform.position.y, spawnLocationTriangularC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator2);

            //Rotate A now
            Quaternion rotateInsulator3 = Quaternion.Euler(0, 0, -90);
            Vector3 locA = new Vector3(spawnLocationTriangularA[i].transform.position.x, spawnLocationTriangularA[i].transform.position.y, spawnLocationTriangularA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator3);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            poleObjectArray[i].setInsulatorType("T");
        }

        GameObject[] wireLoc = new GameObject[3];

        arrayOfPoles[i].name = "Triangular" + i;
        for (int j = 0; j < insulator.Length; j++)
        {
            insulator[j].name = "Insulator" + (j + 1);
            insulator[j].transform.parent = arrayOfPoles[i].transform;
            wireLoc[j] = insulator[j].transform.Find("Bottom").gameObject;
            wireLoc[j].name = (j + 1).ToString();
            wireLoc[j].transform.parent = arrayOfPoles[i].transform;
        }

        //change wire location to the right wire phase (1->phase a, 2-> b, 3-> c)
        wireLoc = wireLoc.OrderBy(wire => wire.transform.position.y).ToArray();
        string[] name = { "1", "3", "2" };//b a c
        for (int j = 0; j < wireLoc.Length; j++)
        {
            wireLoc[j].name = name[j];

        }
    }

    public void generateCrossarmInsulators(int i, Vector3 loc, List<string> shuffle) {
        GameObject[] insulator = new GameObject[3];
        int t = 0;

        if (i <= 9){
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locA = new Vector3(spawnLocationCrossarmA[i].transform.position.x, spawnLocationCrossarmA[i].transform.position.y, spawnLocationCrossarmA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationCrossarmB[i].transform.position.x, spawnLocationCrossarmB[i].transform.position.y, spawnLocationCrossarmB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationCrossarmC[i].transform.position.x, spawnLocationCrossarmC[i].transform.position.y, spawnLocationCrossarmC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            Quaternion rotatebackWood = Quaternion.Euler(0, 90, 0);
            Quaternion rotatebackConcrete = Quaternion.Euler(180, -90, 0);
            Vector3 crossWoodVec = new Vector3(spawnCrossarmBackWood[i].transform.position.x, spawnCrossarmBackWood[i].transform.position.y, spawnCrossarmBackWood[i].transform.position.z);
            Vector3 crossConcreteVec = new Vector3(spawnCrossarmBackConcrete[i].transform.position.x, spawnCrossarmBackConcrete[i].transform.position.y, spawnCrossarmBackConcrete[i].transform.position.z);

            poleObjectArray[i].setInsulatorType("SC");

            //this will spawn depending on if it's wood or concrete pole. 0 is wood
            if (poleObjectArray[i].getPoleMaterial().Equals(0)) {
                Instantiate(crossarmBackMaterial[0], crossWoodVec, rotatebackWood);
                //Debug.Log("The pole material is: " + poleObjectArray[i].poleMaterial);
            }
            //1 is concrete
            else if (poleObjectArray[i].getPoleMaterial().Equals(1)) {
                Instantiate(crossarmBackMaterial[1], crossConcreteVec, rotatebackConcrete);
                //Debug.Log("The pole material is: " + poleObjectArray[i].poleMaterial);
            }
        }

        else if (i > 9) {
            Quaternion rotateInsulator = Quaternion.Euler(-180, 90, 0);
            Vector3 locA = new Vector3(spawnLocationCrossarmA[i].transform.position.x, spawnLocationCrossarmA[i].transform.position.y, spawnLocationCrossarmA[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationCrossarmB[i].transform.position.x, spawnLocationCrossarmB[i].transform.position.y, spawnLocationCrossarmB[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationCrossarmC[i].transform.position.x, spawnLocationCrossarmC[i].transform.position.y, spawnLocationCrossarmC[i].transform.position.z);
            insulator[t++] = Instantiate(insulatorMaterial[0], locC, rotateInsulator);

            poleObjectArray[i].setPoleMaterial(poleObjectArray[i].getPoleMaterial());

            if (poleObjectArray[i].getPoleMaterial() == 0)
                arrayOfPoles[i] = Instantiate(poleMaterialWood[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);
            else if (poleObjectArray[i].getPoleMaterial() == 1)
                arrayOfPoles[i] = Instantiate(poleMaterialConcrete[poleObjectArray[i].getPoleDamage()], loc, Quaternion.identity);

            Quaternion rotatebackWood = Quaternion.Euler(0, 0, 0);
            Quaternion rotatebackConcrete = Quaternion.Euler(0, 0, 0);
            Vector3 crossWoodVec = new Vector3(spawnCrossarmBackWood[i].transform.position.x, spawnCrossarmBackWood[i].transform.position.y, spawnCrossarmBackWood[i].transform.position.z);
            Vector3 crossConcreteVec = new Vector3(spawnCrossarmBackConcrete[i].transform.position.x, spawnCrossarmBackConcrete[i].transform.position.y, spawnCrossarmBackConcrete[i].transform.position.z);

            poleObjectArray[i].setInsulatorType("SC");

            //this will spawn depending on if it's wood or concrete pole. 0 is wood
            if (poleObjectArray[i].getPoleMaterial().Equals(0))
            {
                Instantiate(crossarmBackMaterial[0], crossWoodVec, rotatebackWood);
                Debug.Log("The pole material is: " + poleObjectArray[i].getPoleMaterial());
            }
            //1 is concrete
            else if (poleObjectArray[i].getPoleMaterial().Equals(1))
            {
                Instantiate(crossarmBackMaterial[1], crossConcreteVec, rotatebackConcrete);
                Debug.Log("The pole material is: " + poleObjectArray[i].getPoleMaterial());
            }
        }

        GameObject[] wireLoc = new GameObject[3];

        arrayOfPoles[i].name = "CrossArm" + i;
        for (int j = 0; j < insulator.Length; j++)
        {
            insulator[j].name = "Insulator" + (j + 1);
            insulator[j].transform.parent = arrayOfPoles[i].transform;
            wireLoc[j] = insulator[j].transform.Find("Bottom").gameObject;
            wireLoc[j].name = (j + 1).ToString();
            wireLoc[j].transform.parent = arrayOfPoles[i].transform;
        }

        //change wire location to the right wire phase (1->phase a, 2-> b, 3-> c)

        if (i <= 9) {
            //sort by z
            wireLoc = wireLoc.OrderBy(wire => wire.transform.position.z).ToArray();
            System.Array.Reverse(wireLoc);
        }
        else {
            wireLoc = wireLoc.OrderBy(wire => wire.transform.position.x).ToArray();
            

        }
        string[] name = { "1", "2", "3" };
        for (int j = 0; j < wireLoc.Length; j++)
        {
            wireLoc[j].name = name[j];

        }
    }

    public void spawnFuseHolder(int i) {
        if (i <= 9)
        {
            if (poleObjectArray[i].getPoleMaterial().Equals(0))
            {
                Vector3 fuseVec = new Vector3(spawnFuseSwitchHolder[i].transform.position.x, spawnFuseSwitchHolder[i].transform.position.y, spawnFuseSwitchHolder[i].transform.position.z);
                Instantiate(fuseSwitchHolderMaterial[0], fuseVec, Quaternion.identity);
            }
            else
            {
                Vector3 fuseVec = new Vector3(spawnFuseSwitchHolder[i].transform.position.x, spawnFuseSwitchHolder[i].transform.position.y, spawnFuseSwitchHolder[i].transform.position.z);
                Instantiate(fuseSwitchHolderMaterial[1], fuseVec, Quaternion.identity);
            }
        }
        else if (i > 9) {
            Quaternion rotateBacking = Quaternion.Euler(0, -90, 0);
            if (poleObjectArray[i].getPoleMaterial().Equals(0))
            {
                Vector3 fuseVec = new Vector3(spawnFuseSwitchHolder[i].transform.position.x, spawnFuseSwitchHolder[i].transform.position.y, spawnFuseSwitchHolder[i].transform.position.z);
                Instantiate(fuseSwitchHolderMaterial[0], fuseVec, rotateBacking);
            }
            else
            {
                Vector3 fuseVec = new Vector3(spawnFuseSwitchHolder[i].transform.position.x, spawnFuseSwitchHolder[i].transform.position.y, spawnFuseSwitchHolder[i].transform.position.z);
                Instantiate(fuseSwitchHolderMaterial[1], fuseVec, rotateBacking);
            }
        }
    }


    public void generateCapcitorBank(int i)
    {
       
        if (i <= 9)
        {
            Quaternion rotateCapictor = Quaternion.Euler(-90, 0, 0);
            Vector3 BankVec = new Vector3(spawnCapacitorBank[i].transform.position.x, spawnCapacitorBank[i].transform.position.y, spawnCapacitorBank[i].transform.position.z);
            Instantiate(capcitorBank[poleObjectArray[i].getCapacitorBank()], BankVec, rotateCapictor);


            spawnFuseHolder(i);

        }
        else if (i > 9) {
            Quaternion rotateCapictor = Quaternion.Euler(-90, -90, 0);
            Vector3 BankVec = new Vector3(spawnCapacitorBank[i].transform.position.x, spawnCapacitorBank[i].transform.position.y, spawnCapacitorBank[i].transform.position.z);
            Instantiate(capcitorBank[poleObjectArray[i].getCapacitorBank()], BankVec, rotateCapictor);

            spawnFuseHolder(i);
        }
        /*
        string[] phases = { "A", "B", "C" };

        //connect transformer to fuse switch
        for (int t = 0; t < phases.Length; t++)
        {
            string sname = phases[t];
            string ename = phases[t] + "2";
            string topName = phases[t] + "3";

            GameObject sPoint = capcitorBank[0].transform.Find(sname).gameObject;
            GameObject ePoint = capcitorBank[0].transform.Find(ename).gameObject;
            GameObject topPoint = capcitorBank[0].transform.Find(topName).gameObject;

            UtilityFunctions.lineConnect(sPoint, ePoint, 0.03f, 5, 0.7f);
        }
        //Debug.Log("The " + i + " pole insulator type is0..." + poleObjectArray[i].getInsulatorType());
        //B3, A3, C3
        //V, M, T, SC, DC
        */
    }
    public void spawnCapacitorWires(int i) {
        if (poleObjectArray[i].getInsulatorType() == "V")
        {
            Debug.Log("Executing inside V type for index: " + i);
            //Debug.Log("Vinside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStartV = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinishV = capcitorBank[0].transform.Find("VB").gameObject;
            UtilityFunctions.lineConnect(bStartV, bFinishV, 0.03f, 5, 0.7f);

            GameObject aStartV = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinishV = capcitorBank[0].transform.Find("VA").gameObject;
            UtilityFunctions.lineConnect(aStartV, aFinishV, 0.03f, 5, 0.7f);

            GameObject cStartV = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinishV = capcitorBank[0].transform.Find("VC").gameObject;
            UtilityFunctions.lineConnect(cStartV, cFinishV, 0.03f, 5, 0.7f);
            Debug.Log("done Executing inside V type");
        }
        else if (poleObjectArray[i].getInsulatorType() == "M")
        {
            Debug.Log("Executing inside M Type for index: " + i);
            //Debug.Log("Minside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStartMV = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinishMV = capcitorBank[0].transform.Find("MVB").gameObject;
            UtilityFunctions.lineConnect(bStartMV, bFinishMV, 0.03f, 5, 0.7f);

            GameObject aStartMV = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinishMV = capcitorBank[0].transform.Find("MVA").gameObject;
            UtilityFunctions.lineConnect(aStartMV, aFinishMV, 0.03f, 5, 0.7f);

            GameObject cStartMV = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinishMV = capcitorBank[0].transform.Find("MVC").gameObject;
            UtilityFunctions.lineConnect(cStartMV, cFinishMV, 0.03f, 5, 0.7f);
            Debug.Log("done Executing inside M type");
        }
        else if (poleObjectArray[i].getInsulatorType() == "T")
        {
            Debug.Log("Executing inside T Type for index: " + i);
            //Debug.Log("Minside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStartT = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinishT = capcitorBank[0].transform.Find("TB").gameObject;
            UtilityFunctions.lineConnect(bStartT, bFinishT, 0.03f, 5, 0.7f);

            GameObject aStartT = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinishT = capcitorBank[0].transform.Find("TA").gameObject;
            UtilityFunctions.lineConnect(aStartT, aFinishT, 0.03f, 5, 0.7f);

            GameObject cStartT = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinishT = capcitorBank[0].transform.Find("TC").gameObject;
            UtilityFunctions.lineConnect(cStartT, cFinishT, 0.03f, 5, 0.7f);
            Debug.Log("done Executing inside T type");
        }

        else if (poleObjectArray[i].getInsulatorType() == "SC")
        {
            Debug.Log("Executing inside SC Type for index: " + i);
            //Debug.Log("Minside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStartSC = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinishSC = capcitorBank[0].transform.Find("SCB").gameObject;
            UtilityFunctions.lineConnect(bStartSC, bFinishSC, 0.03f, 5, 0.7f);

            GameObject aStartSC = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinishSC = capcitorBank[0].transform.Find("SCA").gameObject;
            UtilityFunctions.lineConnect(aStartSC, aFinishSC, 0.03f, 5, 0.7f);

            GameObject cStartSC = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinishSC = capcitorBank[0].transform.Find("SCC").gameObject;
            UtilityFunctions.lineConnect(cStartSC, cFinishSC, 0.03f, 5, 0.7f);
            Debug.Log("done Executing inside SC type");
        }
    }

    public void generateFuseSwitch(int i) {
        if (i <= 9)
        {

            Quaternion rotateSwitch = Quaternion.Euler(0, 90, 0);
            //Left fuse switch
            Vector3 FuseVec = new Vector3(spawnFuseSwitchLeft[i].transform.position.x, spawnFuseSwitchLeft[i].transform.position.y, spawnFuseSwitchLeft[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec, rotateSwitch);
            //Middle fuse switch
            Vector3 FuseVec2 = new Vector3(spawnFuseSwitchMiddle[i].transform.position.x, spawnFuseSwitchMiddle[i].transform.position.y, spawnFuseSwitchMiddle[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec2, rotateSwitch);
            //Right fuse switch
            Vector3 FuseVec3 = new Vector3(spawnFuseSwitchRight[i].transform.position.x, spawnFuseSwitchRight[i].transform.position.y, spawnFuseSwitchRight[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec3, rotateSwitch);

        }
        else if (i > 9) {

            //Left fuse switch
            Vector3 FuseVec = new Vector3(spawnFuseSwitchLeft[i].transform.position.x, spawnFuseSwitchLeft[i].transform.position.y, spawnFuseSwitchLeft[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec, Quaternion.identity);
            //Middle fuse switch
            Vector3 FuseVec2 = new Vector3(spawnFuseSwitchMiddle[i].transform.position.x, spawnFuseSwitchMiddle[i].transform.position.y, spawnFuseSwitchMiddle[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec2, Quaternion.identity);
            //Right fuse switch
            Vector3 FuseVec3 = new Vector3(spawnFuseSwitchRight[i].transform.position.x, spawnFuseSwitchRight[i].transform.position.y, spawnFuseSwitchRight[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec3, Quaternion.identity);
        }
    }

    public void spawnLeftFuseSwitch(int i) {
        Quaternion rotateSwitch = Quaternion.Euler(0, 90, 0);
        if (i <= 9)
        {
            //Left fuse switch
            Vector3 FuseVec = new Vector3(spawnFuseSwitchLeft[i].transform.position.x, spawnFuseSwitchLeft[i].transform.position.y, spawnFuseSwitchLeft[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec, rotateSwitch);
        }
        else if (i > 9)
        {
            //Left fuse switch
            Vector3 FuseVec = new Vector3(spawnFuseSwitchLeft[i].transform.position.x, spawnFuseSwitchLeft[i].transform.position.y, spawnFuseSwitchLeft[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec, Quaternion.identity);
        }
    }

    public void spawnMiddleFuseSwitch(int i) {
        Quaternion rotateSwitch = Quaternion.Euler(0, 90, 0);
        if (i <= 9)
        {
            //Middle fuse switch
            Vector3 FuseVec2 = new Vector3(spawnFuseSwitchMiddle[i].transform.position.x, spawnFuseSwitchMiddle[i].transform.position.y, spawnFuseSwitchMiddle[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec2, rotateSwitch);
        }
        else if (i > 9)
        {
            //Middle fuse switch
            Vector3 FuseVec2 = new Vector3(spawnFuseSwitchMiddle[i].transform.position.x, spawnFuseSwitchMiddle[i].transform.position.y, spawnFuseSwitchMiddle[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec2, Quaternion.identity);
        }
    }
    public void spawnRightFuseSwitch(int i) {
        Quaternion rotateSwitch = Quaternion.Euler(0, 90, 0);
        if (i <= 9)
        {
            //Right fuse switch
            Vector3 FuseVec3 = new Vector3(spawnFuseSwitchRight[i].transform.position.x, spawnFuseSwitchRight[i].transform.position.y, spawnFuseSwitchRight[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec3, rotateSwitch);
        }
        else if (i > 9)
        {
            //Right fuse switch
            Vector3 FuseVec3 = new Vector3(spawnFuseSwitchRight[i].transform.position.x, spawnFuseSwitchRight[i].transform.position.y, spawnFuseSwitchRight[i].transform.position.z);
            Instantiate(fuseSwitchMaterial[0], FuseVec3, Quaternion.identity);
        }
    }

    public void generateRecloser(int i) {
        if (i <= 9) {
            Quaternion rotateRec = Quaternion.Euler(0, 90, 0);
            Vector3 recVec = new Vector3(spawnRecloser[i].transform.position.x, spawnRecloser[i].transform.position.y, spawnRecloser[i].transform.position.z);
            Instantiate(recloserMaterial[poleObjectArray[i].getRecloser()], recVec, rotateRec);
        }
        else if (i > 9) {
            //Quaternion rotateRec = Quaternion.Euler(0, 90, 0);
            Vector3 recVec = new Vector3(spawnRecloser[i].transform.position.x, spawnRecloser[i].transform.position.y, spawnRecloser[i].transform.position.z);
            Instantiate(recloserMaterial[poleObjectArray[i].getRecloser()w], recVec, Quaternion.identity);
        }
    }


    public void spawnLeftTransformer(int i) {
        if (i <= 9)
        {
            //LEFT
            Quaternion rotateTranLeft = Quaternion.Euler(0, 90, 0);
            Vector3 tranVec2 = new Vector3(spawnTransformerLeft[i].transform.position.x, spawnTransformerLeft[i].transform.position.y, spawnTransformerLeft[i].transform.position.z);
            Instantiate(transformerMaterial[poleObjectArray[i].getTransformer()], tranVec2, rotateTranLeft);
        }
        else if (i > 9)
        {
            //LEFT
            //Quaternion rotateTranLeft = Quaternion.Euler(0, 90, 0);
            Vector3 tranVec2 = new Vector3(spawnTransformerLeft[i].transform.position.x, spawnTransformerLeft[i].transform.position.y, spawnTransformerLeft[i].transform.position.z);
            Instantiate(transformerMaterial[poleObjectArray[i].getTransformer()], tranVec2, Quaternion.identity);
        }
    }

    public void spawnMiddleTransformer(int i)
    {
        if (i <= 9)
        {
            //MIDDLE
            Vector3 tranVec = new Vector3(spawnTransformerMiddle[i].transform.position.x, spawnTransformerMiddle[i].transform.position.y, spawnTransformerMiddle[i].transform.position.z);
            Instantiate(transformerMaterial[poleObjectArray[i].getTransformer()], tranVec, Quaternion.identity);
        }
        else if (i > 9)
        {
            //MIDDLE
            Quaternion rotateTranMid = Quaternion.Euler(0, -90, 0);
            Vector3 tranVec = new Vector3(spawnTransformerMiddle[i].transform.position.x, spawnTransformerMiddle[i].transform.position.y, spawnTransformerMiddle[i].transform.position.z);
            Instantiate(transformerMaterial[poleObjectArray[i].getTransformer()], tranVec, rotateTranMid);
        }
    }
    public void spawnRightTransformer(int i)
    {
        if (i <= 9)
        {
            //RIGHT
            Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
            Vector3 tranVec3 = new Vector3(spawnTransformerRight[i].transform.position.x, spawnTransformerRight[i].transform.position.y, spawnTransformerRight[i].transform.position.z);
            Instantiate(transformerMaterial[poleObjectArray[i].getTransformer()], tranVec3, rotateTranRight);
        }
        else if (i > 9)
        {
            //RIGHT
            Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
            Vector3 tranVec3 = new Vector3(spawnTransformerRight[i].transform.position.x, spawnTransformerRight[i].transform.position.y, spawnTransformerRight[i].transform.position.z);
            Instantiate(transformerMaterial[poleObjectArray[i].getTransformer()], tranVec3, rotateTranRight);
        }
    }

    public void generateTransformer(int i) {
        
        if (poleObjectArray[i].getTransformerCount() == 1)
        {
            int temp = Random.Range(1,4);
            if (temp == 1) {
                spawnLeftTransformer(i);
                spawnLeftFuseSwitch(i);
            }
            else if (temp == 2) {
                spawnMiddleTransformer(i);
                spawnMiddleFuseSwitch(i);
            }
            else if (temp == 3) { 
                spawnRightTransformer(i);
                spawnRightFuseSwitch(i);
            }
        }
        else if (poleObjectArray[i].getTransformerCount() == 2) {
        int temp = Random.Range(1, 4);
            if (temp == 1) {
                spawnLeftTransformer(i);
                spawnMiddleTransformer(i);

                spawnLeftFuseSwitch(i);
                spawnMiddleFuseSwitch(i);
            }
            else if (temp == 2) {
                spawnLeftTransformer(i);
                spawnRightTransformer(i);

                spawnLeftFuseSwitch(i);
                spawnRightFuseSwitch(i);
            }
            else if (temp == 3) {
                spawnMiddleTransformer(i);
                spawnRightTransformer(i);

                spawnMiddleFuseSwitch(i);
                spawnRightFuseSwitch(i);
            }
        }
        else if (poleObjectArray[i].getTransformerCount() == 3) {
            spawnLeftTransformer(i);
            spawnMiddleTransformer(i);
            spawnRightTransformer(i);

            spawnLeftFuseSwitch(i);
            spawnMiddleFuseSwitch(i);
            spawnRightFuseSwitch(i);
        }
        spawnFuseHolder(i);
    }


    public void generateAfs(int i) {
        if (i <= 9)
        {
            Quaternion rotateAfs = Quaternion.Euler(0, 90, 0);
            Vector3 afsVec = new Vector3(spawnAfs[i].transform.position.x, spawnAfs[i].transform.position.y, spawnAfs[i].transform.position.z);
            Instantiate(afsMaterial[poleObjectArray[i].getAfs()], afsVec, rotateAfs);
        }
        else if (i > 9)
        {
            //RIGHT
            //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
            Vector3 afsVec = new Vector3(spawnAfs[i].transform.position.x, spawnAfs[i].transform.position.y, spawnAfs[i].transform.position.z);
            Instantiate(afsMaterial[poleObjectArray[i].getAfs()], afsVec, Quaternion.identity);
        }
    }

    public void generatePothead(int i) {
        if (i <= 9)
        {
            Vector3 potheadVec = new Vector3(spawnPothead[i].transform.position.x, spawnPothead[i].transform.position.y, spawnPothead[i].transform.position.z);
            Instantiate(potheadMaterial[poleObjectArray[i].getPothead()], potheadVec, Quaternion.identity);
        }
        else if (i > 9)
        {
            Quaternion rotatePothead = Quaternion.Euler(0, -90, 0);
            Vector3 potheadVec = new Vector3(spawnPothead[i].transform.position.x, spawnPothead[i].transform.position.y, spawnPothead[i].transform.position.z);
            Instantiate(potheadMaterial[poleObjectArray[i].getPothead()], potheadVec, rotatePothead);
        }
    }

    public void generateDcSwitch(int i) {
        //dcSwitchMaterial;
        //spawnDcSwitch;
        if (i <= 9)
        {
            Vector3 dcVec = new Vector3(spawnDcSwitch[i].transform.position.x, spawnDcSwitch[i].transform.position.y, spawnDcSwitch[i].transform.position.z);
            Instantiate(dcSwitchMaterial[0], dcVec, Quaternion.identity);
        }
        else if (i > 9)
        {
            Quaternion rotateDcSwitch = Quaternion.Euler(0, -90, 0);
            Vector3 dcVec = new Vector3(spawnDcSwitch[i].transform.position.x, spawnDcSwitch[i].transform.position.y, spawnDcSwitch[i].transform.position.z);
            Instantiate(dcSwitchMaterial[0], dcVec, rotateDcSwitch);
        }
    }

    public void generateAutomaticLineSwitch(int i)
    {
        //automaticLineSwitchMaterial;
        //spawnAutomaticLineSwitch;
        if (i <= 9)
        {
            Vector3 alsVec = new Vector3(spawnAutomaticLineSwitch[i].transform.position.x, spawnAutomaticLineSwitch[i].transform.position.y, spawnAutomaticLineSwitch[i].transform.position.z);
            Instantiate(automaticLineSwitchMaterial[0], alsVec, Quaternion.identity);
        }
        else if (i > 9)
        {
            Quaternion rotateAls = Quaternion.Euler(0, -90, 0);
            Vector3 alsVec = new Vector3(spawnAutomaticLineSwitch[i].transform.position.x, spawnAutomaticLineSwitch[i].transform.position.y, spawnAutomaticLineSwitch[i].transform.position.z);
            Instantiate(automaticLineSwitchMaterial[0], alsVec, rotateAls);
        }
    }

    public void generateTree(int i) {
        //treeMaterial
        //spawnTree
        if (poleObjectArray[i].getOakSpawn() == false && poleObjectArray[i].getPalmSpawn() == false)
            return;
        if(poleObjectArray[i].getOakSpawn() == true) {
            int severityLevel = poleObjectArray[i].getOak();
            if (severityLevel == 3)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc5[i].transform.position.x, spawnTreeLoc5[i].transform.position.y, spawnTreeLoc5[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc5[i].transform.position.x, spawnTreeLoc5[i].transform.position.y, spawnTreeLoc5[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
            }
            else if (severityLevel == 2)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc3[i].transform.position.x, spawnTreeLoc3[i].transform.position.y, spawnTreeLoc3[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc3[i].transform.position.x, spawnTreeLoc3[i].transform.position.y, spawnTreeLoc3[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
            }
            else if (severityLevel == 1)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc1[i].transform.position.x, spawnTreeLoc1[i].transform.position.y, spawnTreeLoc1[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc1[i].transform.position.x, spawnTreeLoc1[i].transform.position.y, spawnTreeLoc1[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
            }
            else if (severityLevel == 0)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc0[i].transform.position.x, spawnTreeLoc0[i].transform.position.y, spawnTreeLoc0[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc0[i].transform.position.x, spawnTreeLoc0[i].transform.position.y, spawnTreeLoc0[i].transform.position.z);
                    Instantiate(treeMaterial[1], treeVec, Quaternion.identity);
                }
            }
        }
        else if (poleObjectArray[i].getPalmSpawn() == true)
        {
            int severityLevel = poleObjectArray[i].getPalm();
            if (severityLevel == 3)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc5[i].transform.position.x, spawnTreeLoc5[i].transform.position.y, spawnTreeLoc5[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc5[i].transform.position.x, spawnTreeLoc5[i].transform.position.y, spawnTreeLoc5[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
            }
            else if (severityLevel == 2)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc3[i].transform.position.x, spawnTreeLoc3[i].transform.position.y, spawnTreeLoc3[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc3[i].transform.position.x, spawnTreeLoc3[i].transform.position.y, spawnTreeLoc3[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
            }
            else if (severityLevel == 1)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc1[i].transform.position.x, spawnTreeLoc1[i].transform.position.y, spawnTreeLoc1[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc1[i].transform.position.x, spawnTreeLoc1[i].transform.position.y, spawnTreeLoc1[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
            }
            else if (severityLevel == 0)
            {
                if (i <= 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc0[i].transform.position.x, spawnTreeLoc0[i].transform.position.y, spawnTreeLoc0[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
                else if (i > 9)
                {
                    //Quaternion rotateTranRight = Quaternion.Euler(0, -180, 0);
                    Vector3 treeVec = new Vector3(spawnTreeLoc0[i].transform.position.x, spawnTreeLoc0[i].transform.position.y, spawnTreeLoc0[i].transform.position.z);
                    Instantiate(treeMaterial[0], treeVec, Quaternion.identity);
                }
            }
        }
    }

    public void generateNest(int i) {
        if (poleObjectArray[i].getNestSpawn() == false) {
            return;
        }
        else if (i <= 9 && poleObjectArray[i].getNestSpawn() == true)
        {
            Vector3 nestVec = new Vector3(spawnNest[i].transform.position.x, spawnNest[i].transform.position.y, spawnNest[i].transform.position.z);
            Instantiate(nestMaterial[0], nestVec, Quaternion.identity);
        }
        else if (i > 9 && poleObjectArray[i].getNestSpawn() == true)
        {
            Vector3 nestVec = new Vector3(spawnNest[i].transform.position.x, spawnNest[i].transform.position.y, spawnNest[i].transform.position.z);
            Instantiate(nestMaterial[0], nestVec, Quaternion.identity);
        } 
    }

    //Balloon == 0 or Kite  == 1
    public void generateBalloon(int i)  {
        if (poleObjectArray[i].getBalloonSpawn() == false && poleObjectArray[i].getKiteSpawn() == false)
            return;
        if(poleObjectArray[i].getBalloonSpawn() == true) { 
            if (i <= 9)
            {
                //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                Vector3 afsVec = new Vector3(spawnBalloon[i].transform.position.x, spawnBalloon[i].transform.position.y, spawnBalloon[i].transform.position.z);
                Instantiate(balloonMaterial[0], afsVec, Quaternion.identity);
            }
            else if (i > 9)
            {
                Quaternion rotateBalloon = Quaternion.Euler(0, -90, 0);
                Vector3 afsVec = new Vector3(spawnBalloon[i].transform.position.x, spawnBalloon[i].transform.position.y, spawnBalloon[i].transform.position.z);
                Instantiate(balloonMaterial[0], afsVec, rotateBalloon);
            }
        }
        else if (poleObjectArray[i].getKiteSpawn() == true)
        {
            if (i <= 9)
            {
                //Quaternion rotateTranRight = Quaternion.Euler(0, -90, 0);
                Vector3 afsVec = new Vector3(spawnBalloon[i].transform.position.x, spawnBalloon[i].transform.position.y, spawnBalloon[i].transform.position.z);
                Instantiate(balloonMaterial[1], afsVec, Quaternion.identity);
            }
            else if (i > 9)
            {
                Quaternion rotateBalloon = Quaternion.Euler(0, -90, 0);
                Vector3 afsVec = new Vector3(spawnBalloon[i].transform.position.x, spawnBalloon[i].transform.position.y, spawnBalloon[i].transform.position.z);
                Instantiate(balloonMaterial[1], afsVec, rotateBalloon);
            }
        }
    }


    //laMaterial;
    //spawnLa;

    //spawnLaBottom;
    //spawnLaMiddle;
    //spawnLaTop;
    public void generateLa(int i)
    {

        if (i == 9)
            return;
        if (i <= 9)
        {
            Quaternion rotateLa = Quaternion.Euler(-90, 0, 0);
            Vector3 laVec = new Vector3(spawnLaBottom[i].transform.position.x, spawnLaBottom[i].transform.position.y, spawnLaBottom[i].transform.position.z);
            Instantiate(laMaterial[0], laVec, rotateLa);

            Quaternion rotateLa2 = Quaternion.Euler(-90, 180, 0);
            Vector3 la2Vec = new Vector3(spawnLaMiddle[i].transform.position.x, spawnLaMiddle[i].transform.position.y, spawnLaMiddle[i].transform.position.z);
            Instantiate(laMaterial[0], la2Vec, rotateLa2);

            Quaternion rotateLa3 = Quaternion.Euler(-90, 0, 0);
            Vector3 la3Vec = new Vector3(spawnLaTop[i].transform.position.x, spawnLaTop[i].transform.position.y, spawnLaTop[i].transform.position.z);
            Instantiate(laMaterial[0], la3Vec, rotateLa3);
        }
        else if (i > 10)
        {
            Quaternion rotateLa = Quaternion.Euler(90, 0, 90);
            Vector3 laVec = new Vector3(spawnLaBottom[i].transform.position.x, spawnLaBottom[i].transform.position.y, spawnLaBottom[i].transform.position.z);
            Instantiate(laMaterial[0], laVec, rotateLa);

            Quaternion rotateLa2 = Quaternion.Euler(90, 90, 0);
            Vector3 la2Vec = new Vector3(spawnLaMiddle[i].transform.position.x, spawnLaMiddle[i].transform.position.y, spawnLaMiddle[i].transform.position.z);
            Instantiate(laMaterial[0], la2Vec, rotateLa2);

            Vector3 la3Vec = new Vector3(spawnLaTop[i].transform.position.x, spawnLaTop[i].transform.position.y, spawnLaTop[i].transform.position.z);
            Instantiate(laMaterial[0], la3Vec, rotateLa);
        }
    }
    //int severityLevel, int materialLevel

    //0 palm, 1 oak
    public void spawnEquipmentType(int i) {
        if (poleObjectArray[i].getEquipmentType() == 0) {
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 1)
        {
            generateCapcitorBank(i);
            generateFuseSwitch(i);
            //spawnCapacitorWires(i);
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 2)
        {
            generateTransformer(i);
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 3)
        {
            generateRecloser(i);
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 4)
        {
            generateAfs(i);
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 5)
        {
            generatePothead(i);
            generateDcSwitch(i);
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 6)
        {
            generateAutomaticLineSwitch(i);
            spawnSecondaryEquip(i);
        }
        else if (poleObjectArray[i].getEquipmentType() == 7)
        {
            generateLa(i);
            spawnSecondaryEquip(i);
        }
    }

    public void spawnSecondaryEquip(int i) {
        generateBalloon(i);
        generateTree(i);
        generateNest(i);
    }

    public void spawnCAF(int i) {
        if (i <= 9) {
            Quaternion rotateCAF = Quaternion.Euler(0, 90, 0);
            Vector3 cafVec = new Vector3(spawnCAFLocation[i].transform.position.x, spawnCAFLocation[i].transform.position.y, spawnCAFLocation[i].transform.position.z);
            Instantiate(CAFMaterial[0], cafVec, rotateCAF);
        }
        else if (i > 9) {
            Vector3 cafVec = new Vector3(spawnCAFLocation[i].transform.position.x, spawnCAFLocation[i].transform.position.y, spawnCAFLocation[i].transform.position.z);
            Instantiate(CAFMaterial[0], cafVec, Quaternion.identity);
        }
    }


    void Awake()
    {

        //this is so that we can add class style fields to the objects...unless there is a better way.
        arrayOfPoles = new GameObject[21];

        List<string> shuffle = new List<string>(poleTypes);
        shuffle.ShuffleList();

        //List<string> shuffle = new List<string>();
        //set these indexes and uncomment if you want to fix the insulator type
        //shuffle.Add(poleTypes[1]); //In order to test put 0-3 into here.
        //shuffle.Add(poleTypes[1]);
        //shuffle.Add(poleTypes[1]);
        //shuffle.Add(poleTypes[1]);

        for (int i = 0; i < 21; i++)
        {
            poleObjectArray[i] = new PoleObject();
            poleObjectArray[i].setEquipmentType(getRandom(8));
            poleObjectArray[i].setNumberOfDamagedEquip(Random.Range(0,4));
            poleObjectArray[i].setDamageToItems();
            spawnEquipmentType(i);
            //spawnSecondaryEquip(i);
        }


        for (int i = 0; i < spawnPoleLocation.Length; i++)
        {

            //newPole[i] = new Pole();

            //Location of new pole
            Vector3 loc = new Vector3(spawnPoleLocation[i].transform.position.x, spawnPoleLocation[i].transform.position.y, spawnPoleLocation[i].transform.position.z);


            if (i <= 4)
            {

                //Vertical insulator: poles 0-4
                if (shuffle[0].Equals(poleTypes[0]))
                {
                    generateVerticalInsulators(i, loc, shuffle);


                }
                //Modified Vertical
                else if ((shuffle[0].Equals(poleTypes[1])))
                {
                    generateModVerticalInsulators(i, loc, shuffle);


                }

                //Triangular
                else if ((shuffle[0].Equals(poleTypes[2])))
                {
                    generateTriangularInsulators(i, loc, shuffle);


                }

                //Crossarm
                else if ((shuffle[0].Equals(poleTypes[3])))
                {
                    generateCrossarmInsulators(i, loc, shuffle);


                }

            }
            else if (i >= 5 && i <= 9)
            {

                //Vertical insulator: poles 5-9
                if (shuffle[1].Equals(poleTypes[0]))
                {

                    generateVerticalInsulators(i, loc, shuffle);

                }
                //Modified Vertical: poles 5-9
                else if ((shuffle[1].Equals(poleTypes[1])))
                {

                    generateModVerticalInsulators(i, loc, shuffle);

                }

                //Triangular: poles 5-9
                else if ((shuffle[1].Equals(poleTypes[2])))
                {

                    generateTriangularInsulators(i, loc, shuffle);

                }

                //Crossarm: poles 5-9
                else if ((shuffle[1].Equals(poleTypes[3])))
                {

                    generateCrossarmInsulators(i, loc, shuffle);

                }
            }
            //else if (i == 10)
            //continue;
            else if (i >= 10 && i <= 14)
            {

                //Vertical insulator: poles 10-14
                if (shuffle[2].Equals(poleTypes[0]))
                {

                    generateVerticalInsulators(i, loc, shuffle);

                }
                //Modified Vertical: poles 10-14
                else if ((shuffle[2].Equals(poleTypes[1])))
                {

                    generateModVerticalInsulators(i, loc, shuffle);
                }

                //Triangular: poles 10-14
                else if ((shuffle[2].Equals(poleTypes[2])))
                {

                    generateTriangularInsulators(i, loc, shuffle);
                }

                //Crossarm: poles 10-14
                else if ((shuffle[2].Equals(poleTypes[3])))
                {

                    generateCrossarmInsulators(i, loc, shuffle);
                }
            }
            else if (i > 14 && i < 21)
            {
                //Vertical insulator: poles 15-19

                if (shuffle[3].Equals(poleTypes[0]))
                {

                    generateVerticalInsulators(i, loc, shuffle);

                }
                //Modified Vertical: poles 15-19
                else if ((shuffle[3].Equals(poleTypes[1])))
                {

                    generateModVerticalInsulators(i, loc, shuffle);
                }

                //Triangular: poles 15-19
                else if ((shuffle[3].Equals(poleTypes[2])))
                {

                    generateTriangularInsulators(i, loc, shuffle);
                }

                //Crossarm: poles 15-19
                else if ((shuffle[3].Equals(poleTypes[3])))
                {

                    generateCrossarmInsulators(i, loc, shuffle);
                }
            }
            //This randomizes equipment



            //generateLa(i);

            //generateBalloon(i);
            //generateNest(i);
            //generateTree(i, Random.Range(0, 4), Random.Range(0, 2));
            //generateNest(i);
            //generateAutomaticLineSwitch(i);
            //generatePothead(i);
            //generateDcSwitch(i);
            //generateAfs(i);

            //generateCapcitorBank(i);
            //generateFuseSwitch(i);
            //generateRecloser(i);

            //spawnCAF(i);
            
        }
        /*
        for (int i = 0; i < 21; i++) {
            Debug.Log(poleObjectArray[i].getInsulatorType());
        }
        for (int i = 0; i < 21; i++)
        {
            Debug.Log(poleObjectArray[i].getPoleMaterial());
        }
        */
        for (int i = 0; i < 21; i++)
        {
            Debug.Log("The equipment type is: "+poleObjectArray[i].getEquipmentType());
        }

        for (int i = 0; i < 21; i++)
        {
            Debug.Log("The number of damaged items is: "+poleObjectArray[i].getNumberOfDamagedEquip() );
        }
        //printDamagedList();
        for (int i = 0; i < 21; i++)
        {
            Debug.Log("Damage list for pole #"+i+" with "+ poleObjectArray[i].getNumberOfDamagedEquip() + " dmg equipment:");
            poleObjectArray[i].printDamagedList();
        }

        //Debug.Log("Number of pole objects: " + poleObjectArray.Length);

        //spawnPoleLocation
        //Debug.Log("Number of pole spawn locations: " + poleObjectArray.Length);
        //foreach(var item in listOfDamagedEquip )

    }
    void Update() {

    }

    public GameObject[] getPoleList()
    {
        return arrayOfPoles;
    }
    
}

