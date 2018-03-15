using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// POWER LINES
    /// </summary>
    public Transform[] spawnVerticalPowerLineA;
    public Transform[] spawnVerticalPowerLineB;
    public Transform[] spawnVerticalPowerLineC;

    public Transform[] spawnModVerticalPowerLineA;
    public Transform[] spawnModVerticalPowerLineB;
    public Transform[] spawnModVerticalPowerLineC;

    public Transform[] spawnTriangularPowerLineA;
    public Transform[] spawnTriangularPowerLineB;
    public Transform[] spawnTriangularPowerLineC;

    public Transform[] spawnCrossarmPowerLineA;
    public Transform[] spawnCrossarmPowerLineB;
    public Transform[] spawnCrossarmPowerLineC;

    //These are just for the crossarm backs
    public Transform[] spawnCrossarmBackWood;
    public Transform[] spawnCrossarmBackConcrete;
    public GameObject[] crossarmBackMaterial;

    public GameObject[] powerLineObject;
    //public Transform[] spawnPowerLineVerticalB;
    //public Transform[] spawnPowerLineVerticalC;

    public GameObject[] insulatorMaterial; //this is only one atm.
    public GameObject[] poleMaterial; //this is either wood or concrete atm.
    public GameObject[] arrayOfPoles;

  
    //Array of pole objects
    Pole[] newPole = new Pole[20];
   
    public int randomInt;

    List<string> poleTypes = new List<string>(new string[] { "Vertical", "ModVertical", "Triangular", "Crossarm" });


    //utility function to be able to use random range anywhere.
    public int getRandom(int x)  {

        randomInt = Random.Range(0, x);
        return randomInt;
    }

    public class Pole {
        public GameObject PoleObject;   //this might not be needed.
        public string poleType = "";
        public int poleMaterial = 0;
        //public Insulator insulator;
    }

    public void shuffleDis(List<string> oldList) {
        int i = oldList.Count;



    }

    public void generateVerticalPowerline(int i, Vector3 loc) {

        if (i == 0)
        {
            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnVerticalPowerLineB[0].transform.position.x, spawnVerticalPowerLineB[0].transform.position.y, spawnVerticalPowerLineB[0].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnVerticalPowerLineA[0].transform.position.x, spawnVerticalPowerLineA[0].transform.position.y, spawnVerticalPowerLineA[0].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnVerticalPowerLineC[0].transform.position.x, spawnVerticalPowerLineC[0].transform.position.y, spawnVerticalPowerLineC[0].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);

        }
        else if (i == 5)
        {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnVerticalPowerLineB[1].transform.position.x, spawnVerticalPowerLineB[1].transform.position.y, spawnVerticalPowerLineB[1].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnVerticalPowerLineA[1].transform.position.x, spawnVerticalPowerLineA[1].transform.position.y, spawnVerticalPowerLineA[1].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnVerticalPowerLineC[1].transform.position.x, spawnVerticalPowerLineC[1].transform.position.y, spawnVerticalPowerLineC[1].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);

        }
        else if (i == 11) {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -180, 0);
            Vector3 locB = new Vector3(spawnVerticalPowerLineB[2].transform.position.x, spawnVerticalPowerLineB[2].transform.position.y, spawnVerticalPowerLineB[2].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnVerticalPowerLineA[2].transform.position.x, spawnVerticalPowerLineA[2].transform.position.y, spawnVerticalPowerLineA[2].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnVerticalPowerLineC[2].transform.position.x, spawnVerticalPowerLineC[2].transform.position.y, spawnVerticalPowerLineC[2].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);

        }
        else if (i == 16) {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -180, 0);
            Vector3 locB = new Vector3(spawnVerticalPowerLineB[3].transform.position.x, spawnVerticalPowerLineB[3].transform.position.y, spawnVerticalPowerLineB[3].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnVerticalPowerLineA[3].transform.position.x, spawnVerticalPowerLineA[3].transform.position.y, spawnVerticalPowerLineA[3].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnVerticalPowerLineC[3].transform.position.x, spawnVerticalPowerLineC[3].transform.position.y, spawnVerticalPowerLineC[3].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);

        }

        else
            return;
    }

    public void generateModVerticalPowerline(int i, Vector3 loc) {
        if (i == 0)
        {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnModVerticalPowerLineB[0].transform.position.x, spawnModVerticalPowerLineB[0].transform.position.y, spawnModVerticalPowerLineB[0].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnModVerticalPowerLineA[0].transform.position.x, spawnModVerticalPowerLineA[0].transform.position.y, spawnModVerticalPowerLineA[0].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnModVerticalPowerLineC[0].transform.position.x, spawnModVerticalPowerLineC[0].transform.position.y, spawnModVerticalPowerLineC[0].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);

        }
        else if (i == 5)
        {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnModVerticalPowerLineB[1].transform.position.x, spawnModVerticalPowerLineB[1].transform.position.y, spawnModVerticalPowerLineB[1].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnModVerticalPowerLineA[1].transform.position.x, spawnModVerticalPowerLineA[1].transform.position.y, spawnModVerticalPowerLineA[1].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnModVerticalPowerLineC[1].transform.position.x, spawnModVerticalPowerLineC[1].transform.position.y, spawnModVerticalPowerLineC[1].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);

        }
        else
            return;
    }

    public void generateTriangularPowerline(int i, Vector3 loc)
    {
        if (i == 0)
        {
            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnTriangularPowerLineB[0].transform.position.x, spawnTriangularPowerLineB[0].transform.position.y, spawnTriangularPowerLineB[0].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnTriangularPowerLineA[0].transform.position.x, spawnTriangularPowerLineA[0].transform.position.y, spawnTriangularPowerLineA[0].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnTriangularPowerLineC[0].transform.position.x, spawnTriangularPowerLineC[0].transform.position.y, spawnTriangularPowerLineC[0].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);
        }
        else if (i == 5)
        {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnTriangularPowerLineB[1].transform.position.x, spawnTriangularPowerLineB[1].transform.position.y, spawnTriangularPowerLineB[1].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnTriangularPowerLineA[1].transform.position.x, spawnTriangularPowerLineA[1].transform.position.y, spawnTriangularPowerLineA[1].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnTriangularPowerLineC[1].transform.position.x, spawnTriangularPowerLineC[1].transform.position.y, spawnTriangularPowerLineC[1].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);
        }
        else
            return;
    }

    public void generateCrossarmPowerline(int i, Vector3 loc)
    {
        if (i == 0)
        {
            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnCrossarmPowerLineB[0].transform.position.x, spawnCrossarmPowerLineB[0].transform.position.y, spawnCrossarmPowerLineB[0].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnCrossarmPowerLineA[0].transform.position.x, spawnCrossarmPowerLineA[0].transform.position.y, spawnCrossarmPowerLineA[0].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnCrossarmPowerLineC[0].transform.position.x, spawnCrossarmPowerLineC[0].transform.position.y, spawnCrossarmPowerLineC[0].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);
        }
        else if (i == 5)
        {

            //For powerline at position B.
            Quaternion rotate = Quaternion.Euler(0, -90, 0);
            Vector3 locB = new Vector3(spawnCrossarmPowerLineB[1].transform.position.x, spawnCrossarmPowerLineB[1].transform.position.y, spawnCrossarmPowerLineB[1].transform.position.z);
            Instantiate(powerLineObject[0], locB, rotate);

            Vector3 locA = new Vector3(spawnCrossarmPowerLineA[1].transform.position.x, spawnCrossarmPowerLineA[1].transform.position.y, spawnCrossarmPowerLineA[1].transform.position.z);
            Instantiate(powerLineObject[0], locA, rotate);

            Vector3 locC = new Vector3(spawnCrossarmPowerLineC[1].transform.position.x, spawnCrossarmPowerLineC[1].transform.position.y, spawnCrossarmPowerLineC[1].transform.position.z);
            Instantiate(powerLineObject[0], locC, rotate);
        }
        else
            return;
    }

    //
    // Insulator generation functions
    //

    public void generateVerticalInsulators(int i, Vector3 loc, List<string> shuffle) {

        //if the poles are along the x axis (W->E)
        if (i <= 9)  {

            //This is going to rotate the insulator and then spawn it.
            Quaternion rotateInsulator = Quaternion.Euler(-90, 0, 0);
            Vector3 locA = new Vector3(spawnLocationVerticalA[i].transform.position.x, spawnLocationVerticalA[i].transform.position.y, spawnLocationVerticalA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationVerticalB[i].transform.position.x, spawnLocationVerticalB[i].transform.position.y, spawnLocationVerticalB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationVerticalC[i].transform.position.x, spawnLocationVerticalC[i].transform.position.y, spawnLocationVerticalC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator);

            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            // Debug.Log("shuffle is =" + shuffle[0]);
        }
        //if the poles are along the z axis (S->N)
        else if (i > 9) {

            //This is going to rotate the insulator and then spawn it.
            Quaternion rotateInsulator = Quaternion.Euler(0, 0, -90);
            Vector3 locA = new Vector3(spawnLocationVerticalA[i].transform.position.x, spawnLocationVerticalA[i].transform.position.y, spawnLocationVerticalA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationVerticalB[i].transform.position.x, spawnLocationVerticalB[i].transform.position.y, spawnLocationVerticalB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationVerticalC[i].transform.position.x, spawnLocationVerticalC[i].transform.position.y, spawnLocationVerticalC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator);

            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            // Debug.Log("shuffle is =" + shuffle[0]);
        }
    }

    public void generateModVerticalInsulators(int i, Vector3 loc, List<string> shuffle) {
        if (i <= 9)
        {
            //Spawn the B insulator w/o rotating
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationModVerticalB[i].transform.position.x, spawnLocationModVerticalB[i].transform.position.y, spawnLocationModVerticalB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the insulator and spawn
            Quaternion rotateInsulator2 = Quaternion.Euler(-90, 0, 0);
            Vector3 locA = new Vector3(spawnLocationModVerticalA[i].transform.position.x, spawnLocationModVerticalA[i].transform.position.y, spawnLocationModVerticalA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator2);

            Vector3 locC = new Vector3(spawnLocationModVerticalC[i].transform.position.x, spawnLocationModVerticalC[i].transform.position.y, spawnLocationModVerticalC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator2);


            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            Debug.Log("shuffle is =" + shuffle[0]);
        }

        //if the poles are along the z axis (S->N)
        else if (i > 9) {
            //Spawn the B insulator w/o rotating
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationModVerticalB[i].transform.position.x, spawnLocationModVerticalB[i].transform.position.y, spawnLocationModVerticalB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the insulator and spawn
            Quaternion rotateInsulator2 = Quaternion.Euler(0, 0, -90);
            Vector3 locA = new Vector3(spawnLocationModVerticalA[i].transform.position.x, spawnLocationModVerticalA[i].transform.position.y, spawnLocationModVerticalA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator2);

            Vector3 locC = new Vector3(spawnLocationModVerticalC[i].transform.position.x, spawnLocationModVerticalC[i].transform.position.y, spawnLocationModVerticalC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator2);


            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            Debug.Log("shuffle is =" + shuffle[0]);
        }

    }

    public void generateTriangularInsulators(int i, Vector3 loc, List<string> shuffle) {
        if (i <= 9)
        {
            //Spawn the B insulator and rotate
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationTriangularB[i].transform.position.x, spawnLocationTriangularB[i].transform.position.y, spawnLocationTriangularB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the C insulator
            Quaternion rotateInsulator2 = Quaternion.Euler(90, 0, 0);
            Vector3 locC = new Vector3(spawnLocationTriangularC[i].transform.position.x, spawnLocationTriangularC[i].transform.position.y, spawnLocationTriangularC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator2);

            //Rotate A now
            Quaternion rotateInsulator3 = Quaternion.Euler(-90, 0, 0);
            Vector3 locA = new Vector3(spawnLocationTriangularA[i].transform.position.x, spawnLocationTriangularA[i].transform.position.y, spawnLocationTriangularA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator3);

            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            Debug.Log("shuffle is =" + shuffle[0]);
        }

        else if (i > 9) {

            //Spawn the B insulator and rotate
            Quaternion rotateInsulator = Quaternion.Euler(-180, 0, 0);
            Vector3 locB = new Vector3(spawnLocationTriangularB[i].transform.position.x, spawnLocationTriangularB[i].transform.position.y, spawnLocationTriangularB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            //Rotate the C insulator
            Quaternion rotateInsulator2 = Quaternion.Euler(0, 0, 90);
            Vector3 locC = new Vector3(spawnLocationTriangularC[i].transform.position.x, spawnLocationTriangularC[i].transform.position.y, spawnLocationTriangularC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator2);

            //Rotate A now
            Quaternion rotateInsulator3 = Quaternion.Euler(0, 0, -90);
            Vector3 locA = new Vector3(spawnLocationTriangularA[i].transform.position.x, spawnLocationTriangularA[i].transform.position.y, spawnLocationTriangularA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator3);

            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            Debug.Log("shuffle is =" + shuffle[0]);
        }

    }

    public void generateCrossarmInsulators(int i, Vector3 loc, List<string> shuffle) {

        if (i <= 9)
        {

            //Quaternion rotateInsulator = Quaternion.Euler(0, 0, 0);
            Vector3 locA = new Vector3(spawnLocationCrossarmA[i].transform.position.x, spawnLocationCrossarmA[i].transform.position.y, spawnLocationCrossarmA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, Quaternion.identity);

            Vector3 locB = new Vector3(spawnLocationCrossarmB[i].transform.position.x, spawnLocationCrossarmB[i].transform.position.y, spawnLocationCrossarmB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, Quaternion.identity);

            Vector3 locC = new Vector3(spawnLocationCrossarmC[i].transform.position.x, spawnLocationCrossarmC[i].transform.position.y, spawnLocationCrossarmC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, Quaternion.identity);

            int tempPoleMaterial = getRandom(2);
            Debug.Log("tempmaterial is:" + tempPoleMaterial);

            //arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            arrayOfPoles[i] = Instantiate(poleMaterial[tempPoleMaterial], loc, Quaternion.identity);

            //store the type of pole material
            newPole[i].poleMaterial = tempPoleMaterial;
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            Debug.Log("shuffle is =" + shuffle[0]);

            Quaternion rotatebackWood = Quaternion.Euler(0, 90, 0);
            Quaternion rotatebackConcrete = Quaternion.Euler(180, -90, 0);
            Vector3 crossWoodVec = new Vector3(spawnCrossarmBackWood[i].transform.position.x, spawnCrossarmBackWood[i].transform.position.y, spawnCrossarmBackWood[i].transform.position.z);
            Vector3 crossConcreteVec = new Vector3(spawnCrossarmBackConcrete[i].transform.position.x, spawnCrossarmBackConcrete[i].transform.position.y, spawnCrossarmBackConcrete[i].transform.position.z);

            //this will spawn depending on if it's wood or concrete pole. 0 is wood
            if (newPole[i].poleMaterial.Equals(0)) { 
                Instantiate(crossarmBackMaterial[0], crossWoodVec, rotatebackWood);
                Debug.Log("The pole material is: "+newPole[i].poleMaterial);
            }
            //1 is concrete
            else if (newPole[i].poleMaterial.Equals(1)) { 
                Instantiate(crossarmBackMaterial[1], crossConcreteVec, rotatebackConcrete);
                Debug.Log("The pole material is: " + newPole[i].poleMaterial);
            }
        }

        else if (i > 9) {
            Quaternion rotateInsulator = Quaternion.Euler(0, 90, 0);
            Vector3 locA = new Vector3(spawnLocationCrossarmA[i].transform.position.x, spawnLocationCrossarmA[i].transform.position.y, spawnLocationCrossarmA[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locA, rotateInsulator);

            Vector3 locB = new Vector3(spawnLocationCrossarmB[i].transform.position.x, spawnLocationCrossarmB[i].transform.position.y, spawnLocationCrossarmB[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locB, rotateInsulator);

            Vector3 locC = new Vector3(spawnLocationCrossarmC[i].transform.position.x, spawnLocationCrossarmC[i].transform.position.y, spawnLocationCrossarmC[i].transform.position.z);
            Instantiate(insulatorMaterial[0], locC, rotateInsulator);

            int tempPoleMaterial = getRandom(2);
            Debug.Log("tempmaterial is:" + tempPoleMaterial);

            //arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
            arrayOfPoles[i] = Instantiate(poleMaterial[tempPoleMaterial], loc, Quaternion.identity);

            //store the type of pole material
            newPole[i].poleMaterial = tempPoleMaterial;
            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].poleType = shuffle[0];
            Debug.Log("shuffle is =" + shuffle[0]);

            Quaternion rotatebackWood = Quaternion.Euler(0, 0, 0);
            Quaternion rotatebackConcrete = Quaternion.Euler(0, 0, 0);
            Vector3 crossWoodVec = new Vector3(spawnCrossarmBackWood[i].transform.position.x, spawnCrossarmBackWood[i].transform.position.y, spawnCrossarmBackWood[i].transform.position.z);
            Vector3 crossConcreteVec = new Vector3(spawnCrossarmBackConcrete[i].transform.position.x, spawnCrossarmBackConcrete[i].transform.position.y, spawnCrossarmBackConcrete[i].transform.position.z);

            //this will spawn depending on if it's wood or concrete pole. 0 is wood
            if (newPole[i].poleMaterial.Equals(0))
            {
                Instantiate(crossarmBackMaterial[0], crossWoodVec, rotatebackWood);
                Debug.Log("The pole material is: " + newPole[i].poleMaterial);
            }
            //1 is concrete
            else if (newPole[i].poleMaterial.Equals(1))
            {
                Instantiate(crossarmBackMaterial[1], crossConcreteVec, rotatebackConcrete);
                Debug.Log("The pole material is: " + newPole[i].poleMaterial);
                //.296
            }
        }
    }





    void Start()
    {
        
        //this is so that we can add class style fields to the objects...unless there is a beter way.
        arrayOfPoles = new GameObject[20];

        List<string> shuffle = new List<string>(poleTypes);
        shuffle.ShuffleList();
        //set these indexes and uncomment if you want to fix the insulator type
        //shuffle.Add(poleTypes[3]); //In order to test put 0-3 into here.
        //shuffle.Add(poleTypes[3]);
        //shuffle.Add(poleTypes[3]);
        //shuffle.Add(poleTypes[3]);

        //List<string> testingThisList = new List<string>(poleTypes);
        //testingThisList.ShuffleList();

        //testingThisList.AddRange(shuffleList(poleTypes));
        //testingThisList.ForEach(Debug.Log);


        for (int i = 0; i < spawnPoleLocation.Length; i++) {

            newPole[i] = new Pole();

            //Location of new pole
            Vector3 loc = new Vector3(spawnPoleLocation[i].transform.position.x, spawnPoleLocation[i].transform.position.y, spawnPoleLocation[i].transform.position.z);

            if (i <= 4) {

                //Vertical insulator: poles 0-4
                if (shuffle[0].Equals(poleTypes[0]))
                {
                    generateVerticalInsulators(i, loc, shuffle);
                    //generateVerticalPowerline(i, loc);

                }
                //Modified Vertical
                else if ((shuffle[0].Equals(poleTypes[1])))
                {
                    generateModVerticalInsulators(i, loc, shuffle);
                    //generateModVerticalPowerline(i , loc);

                }

                //Triangular
                else if ((shuffle[0].Equals(poleTypes[2])))
                {
                    generateTriangularInsulators(i, loc, shuffle);
                    //generateTriangularPowerline(i, loc);
                }

                //Crossarm
                else if ((shuffle[0].Equals(poleTypes[3])))
                {
                    generateCrossarmInsulators(i, loc, shuffle);
                    //generateCrossarmPowerline(i, loc);
                }

            }
            else if (i >= 5 && i <= 9) {

                //Vertical insulator: poles 5-9
                if (shuffle[1].Equals(poleTypes[0])) {

                    generateVerticalInsulators(i, loc, shuffle);
                    //generateVerticalPowerline(i, loc);
                }
                //Modified Vertical: poles 5-9
                else if ((shuffle[1].Equals(poleTypes[1]))) {

                    generateModVerticalInsulators(i, loc, shuffle);
                    //generateModVerticalPowerline(i, loc);
                }

                //Triangular: poles 5-9
                else if ((shuffle[1].Equals(poleTypes[2]))) {

                    generateTriangularInsulators(i, loc, shuffle);
                    //generateTriangularPowerline(i, loc);
                }

                //Crossarm: poles 5-9
                else if ((shuffle[1].Equals(poleTypes[3]))) {

                    generateCrossarmInsulators(i, loc, shuffle);
                    //generateCrossarmPowerline(i, loc);
                }
            }
            else if (i >= 10 && i <= 14) {

                //Vertical insulator: poles 10-14
                if (shuffle[2].Equals(poleTypes[0]))  {

                    generateVerticalInsulators(i, loc, shuffle);
                    //generateVerticalPowerline(i, loc);
                }
                //Modified Vertical: poles 10-14
                else if ((shuffle[2].Equals(poleTypes[1])))  {

                    generateModVerticalInsulators(i, loc, shuffle);
                }

                //Triangular: poles 10-14
                else if ((shuffle[2].Equals(poleTypes[2])))  {

                    generateTriangularInsulators(i, loc, shuffle);
                }

                //Crossarm: poles 10-14
                else if ((shuffle[2].Equals(poleTypes[3])))  {

                    generateCrossarmInsulators(i, loc, shuffle);
                }
            }
            else if (i > 14)   {
                //Vertical insulator: poles 15-19

                if (shuffle[3].Equals(poleTypes[0]))  {

                    generateVerticalInsulators(i, loc, shuffle);
                    //generateVerticalPowerline(i, loc);
                }
                //Modified Vertical: poles 15-19
                else if ((shuffle[3].Equals(poleTypes[1]))) {

                    generateModVerticalInsulators(i, loc, shuffle);
                }

                //Triangular: poles 15-19
                else if ((shuffle[3].Equals(poleTypes[2]))) {

                    generateTriangularInsulators(i, loc, shuffle);
                }

                //Crossarm: poles 15-19
                else if ((shuffle[3].Equals(poleTypes[3]))) {

                    generateCrossarmInsulators(i, loc, shuffle);
                }
            }
        }
    }

    void Update() {

    }

    
}

