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

    public GameObject[] capcitorBank;
    public Transform[] spawnCapacitorBank;

    public GameObject[] fuseSwitchHolderMaterial;
    public Transform[] spawnFuseSwitchHolder;

    public GameObject[] fuseSwitchMaterial;
    public Transform[] spawnFuseSwitchLeft;
    public Transform[] spawnFuseSwitchMiddle;
    public Transform[] spawnFuseSwitchRight;

    private int randomInt;

    List<string> poleTypes = new List<string>(new string[] { "Vertical", "ModVertical", "Triangular", "Crossarm" });


    //utility function to be able to use random range anywhere.
    public int getRandom(int x)  {

        randomInt = Random.Range(0, x);
        return randomInt;
    }

    PoleObject[] poleObjectArray = new PoleObject[20];

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

            Quaternion rotatebackWood = Quaternion.Euler(0, 90, 0);
            Quaternion rotatebackConcrete = Quaternion.Euler(180, -90, 0);
            Vector3 crossWoodVec = new Vector3(spawnCrossarmBackWood[i].transform.position.x, spawnCrossarmBackWood[i].transform.position.y, spawnCrossarmBackWood[i].transform.position.z);
            Vector3 crossConcreteVec = new Vector3(spawnCrossarmBackConcrete[i].transform.position.x, spawnCrossarmBackConcrete[i].transform.position.y, spawnCrossarmBackConcrete[i].transform.position.z);

            poleObjectArray[i].setInsulatorType("SC");

            //this will spawn depending on if it's wood or concrete pole. 0 is wood
            if (poleObjectArray[i].poleMaterial.Equals(0)) {
                Instantiate(crossarmBackMaterial[0], crossWoodVec, rotatebackWood);
                //Debug.Log("The pole material is: " + poleObjectArray[i].poleMaterial);
            }
            //1 is concrete
            else if (poleObjectArray[i].poleMaterial.Equals(1)) {
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

            int poleRandoNum = getRandom(2);
            poleObjectArray[i].setPoleMaterial(poleRandoNum);

            //arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            arrayOfPoles[i] = Instantiate(poleMaterial[poleRandoNum], loc, Quaternion.identity);

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

    public void generateCapcitorBank(int i)
    {
        
        if (i <= 9)
        {
            //Quaternion rotateCapictor = Quaternion.Euler(-90, 0, -90);
            Vector3 BankVec = new Vector3(spawnCapacitorBank[i].transform.position.x, spawnCapacitorBank[i].transform.position.y, spawnCapacitorBank[i].transform.position.z);
            Instantiate(capcitorBank[0], BankVec, Quaternion.identity);

            if (poleObjectArray[i].getPoleMaterial().Equals(0))
            {
                Vector3 fuseVec = new Vector3(spawnFuseSwitchHolder[i].transform.position.x, spawnFuseSwitchHolder[i].transform.position.y, spawnFuseSwitchHolder[i].transform.position.z);
                Instantiate(fuseSwitchHolderMaterial[0], fuseVec, Quaternion.identity);
            }
            else {
                Vector3 fuseVec = new Vector3(spawnFuseSwitchHolder[i].transform.position.x, spawnFuseSwitchHolder[i].transform.position.y, spawnFuseSwitchHolder[i].transform.position.z);
                Instantiate(fuseSwitchHolderMaterial[1], fuseVec, Quaternion.identity);
            }

            /*
            //UtilityFunctions.lineConnect(s, e, 0.03f, 5, 0.7f);

            //GameObject sPoint = this.gameObject.transform.GetChild(4).gameObject;
            /*
            if (sPoint == null || ePoint == null)
                Debug.Log("Couldn't find it");
            else
                UtilityFunctions.lineConnect(sPoint, ePoint, 0.03f, 5, 0.7f);
              */

        }
        else if (i > 9) {
            Quaternion rotateCapictor = Quaternion.Euler(0, -90, 0);
            Vector3 BankVec = new Vector3(spawnCapacitorBank[i].transform.position.x, spawnCapacitorBank[i].transform.position.y, spawnCapacitorBank[i].transform.position.z);
            Instantiate(capcitorBank[0], BankVec, rotateCapictor);

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
        /*
        string[] fuseConnectors = { "LFS", "MFS", "RFS" };
        for (int t = 0; t < fuseConnectors.Length; t++)
        {
            string fuseBottom = fuseConnectors[t];
            string bank = fuseConnectors[t] + 1;

            GameObject s = fuseSwitchMaterial[0].transform.Find(fuseBottom).gameObject;
            GameObject e = fuseSwitchMaterial[0].transform.Find(bank).gameObject; 

            UtilityFunctions.lineConnect(s, e, 0.03f, 5, 0.7f);
        }
        */


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
        if (poleObjectArray[i].getInsulatorType() == "V")
        {
            Debug.Log("Vinside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStart = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinish = capcitorBank[0].transform.Find("VB").gameObject;
            UtilityFunctions.lineConnect(bStart, bFinish, 0.03f, 5, 0.7f);

            GameObject aStart = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinish = capcitorBank[0].transform.Find("VA").gameObject;
            UtilityFunctions.lineConnect(aStart, aFinish, 0.03f, 5, 0.7f);

            GameObject cStart = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinish = capcitorBank[0].transform.Find("VC").gameObject;
            UtilityFunctions.lineConnect(cStart, cFinish, 0.03f, 5, 0.7f);
        }
        else if (poleObjectArray[i].getInsulatorType() == "M")
        {
            Debug.Log("Minside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStart = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinish = capcitorBank[0].transform.Find("MVB").gameObject;
            UtilityFunctions.lineConnect(bStart, bFinish, 0.03f, 5, 0.7f);

            GameObject aStart = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinish = capcitorBank[0].transform.Find("MVA").gameObject;
            UtilityFunctions.lineConnect(aStart, aFinish, 0.03f, 5, 0.7f);

            GameObject cStart = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinish = capcitorBank[0].transform.Find("MVC").gameObject;
            UtilityFunctions.lineConnect(cStart, cFinish, 0.03f, 5, 0.7f);
        }
        else if (poleObjectArray[i].getInsulatorType() == "T")
        {
            Debug.Log("Minside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStart = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinish = capcitorBank[0].transform.Find("TB").gameObject;
            UtilityFunctions.lineConnect(bStart, bFinish, 0.03f, 5, 0.7f);

            GameObject aStart = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinish = capcitorBank[0].transform.Find("TA").gameObject;
            UtilityFunctions.lineConnect(aStart, aFinish, 0.03f, 5, 0.7f);

            GameObject cStart = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinish = capcitorBank[0].transform.Find("TC").gameObject;
            UtilityFunctions.lineConnect(cStart, cFinish, 0.03f, 5, 0.7f);
        }
        
        else if (poleObjectArray[i].getInsulatorType() == "SC")
        {
            Debug.Log("Minside The " + i + " pole insulator type is..." + poleObjectArray[i].getInsulatorType());
            GameObject bStart = capcitorBank[0].transform.Find("B3").gameObject;
            GameObject bFinish = capcitorBank[0].transform.Find("SCB").gameObject;
            UtilityFunctions.lineConnect(bStart, bFinish, 0.03f, 5, 0.7f);

            GameObject aStart = capcitorBank[0].transform.Find("A3").gameObject;
            GameObject aFinish = capcitorBank[0].transform.Find("SCA").gameObject;
            UtilityFunctions.lineConnect(aStart, aFinish, 0.03f, 5, 0.7f);

            GameObject cStart = capcitorBank[0].transform.Find("C3").gameObject;
            GameObject cFinish = capcitorBank[0].transform.Find("SCC").gameObject;
            UtilityFunctions.lineConnect(cStart, cFinish, 0.03f, 5, 0.7f);
        }
        
        else
            return;
           
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
       // GameObject s = transform.Find("Bank").gameObject;
      //  GameObject e = transform.Find("Bottom of FS").gameObject;
       // UtilityFunctions.lineConnect(s, e, 0.03f, 5, 0.7f);

        //GameObject s = fuseSwitchMaterial[0].transform.Find("LFS").gameObject;
        //GameObject e = fuseSwitchMaterial[0].transform.Find("RFS").gameObject;
        //UtilityFunctions.lineConnect(s, e, 0.03f, 5, 0.7f);

        //GameObject s3 = fuseSwitchMaterial[0].transform.Find("RFS").gameObject;
        //GameObject e3 = fuseSwitchMaterial[0].transform.Find("RFS1").gameObject;
        //UtilityFunctions.lineConnect(s3, e3, 0.03f, 5, 0.7f);

        /*
        string[] fuseConnectors = { "LFS", "MFS", "RFS" };
        for (int t = 0; t < fuseConnectors.Length; t++)
        {
            string fuseBottom = fuseConnectors[t];
            string bank = fuseConnectors[t] + 1;

            GameObject s = fuseSwitchMaterial[0].transform.Find(fuseBottom).gameObject;
            GameObject e = fuseSwitchMaterial[0].transform.Find(bank).gameObject;

            UtilityFunctions.lineConnect(s, e, 0.03f, 5, 0.7f);
        }
       */
    }

    void Awake()
    {

        //this is so that we can add class style fields to the objects...unless there is a better way.
        arrayOfPoles = new GameObject[20];


        List<string> shuffle = new List<string>(poleTypes);
        shuffle.ShuffleList();

        //List<string> shuffle = new List<string>();
        //set these indexes and uncomment if you want to fix the insulator type
        //shuffle.Add(poleTypes[0]); //In order to test put 0-3 into here.
        //shuffle.Add(poleTypes[3]);
        //shuffle.Add(poleTypes[0]);
        //shuffle.Add(poleTypes[0]);

        for (int i = 0; i < 20; i++)
        {
            poleObjectArray[i] = new PoleObject();
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
            else if (i > 14)
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
            generateCapcitorBank(i);
            generateFuseSwitch(i);
        }
        for (int i = 0; i < 20; i++) {
            Debug.Log(poleObjectArray[i].getInsulatorType());
        }
        for (int i = 0; i < 20; i++)
        {
            Debug.Log(poleObjectArray[i].getPoleMaterial());
        }
    }

    void Update() {

    }

    public GameObject[] getPoleList()
    {
        return arrayOfPoles;
    }
    
}

