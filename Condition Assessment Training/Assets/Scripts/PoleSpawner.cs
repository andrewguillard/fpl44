using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleSpawner : MonoBehaviour
{
    public Transform[] spawnLocation; //Location of each pole

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


    public GameObject[] insulatorMaterial; //this is only one atm.
    public GameObject[] poleMaterial; //this is either wood or concrete atm.
    public GameObject[] arrayOfPoles;

    //Array of pole objects
    Pole[] newPole = new Pole[20];
   
    public int randomInt;

    List<string> poleTypes = new List<string>(new string[] { "Vertical", "ModVertical", "Triangular", "Crossarm" });


    //utility function to be able to use random range anywhere.
    public int getRandom(int x)
    {
        randomInt = Random.Range(0, x);
        return randomInt;
    }

    public class Pole {
        public GameObject PoleObject;   //this might not be needed.
        public string poleType = "";
        public int POLEINT;
    }


    void Start()
    {
        //this is so that we can add class style fields to the objects...unless there is a beter way.
        arrayOfPoles = new GameObject[20];

        //The shuffle list is taking our poleTypes List and randomizing it.
        //We probably need to come up with a better shuffle method, this does not check for redundancy
        List<string> shuffle = new List<string>();
        shuffle.Add(poleTypes[3]);
        shuffle.Add(poleTypes[1]);
        shuffle.Add(poleTypes[1]);
        //shuffle.Add(poleTypes[getRandom(4)]);
        shuffle.Add(poleTypes[1]);

        for (int i = 0; i < spawnLocation.Length; i++)
        {
            newPole[i] = new Pole();

            //increase y-axis location
            float newy = spawnLocation[i].transform.position.y + (10.886f / 2f);

            //Location of new pole
            Vector3 loc = new Vector3(spawnLocation[i].transform.position.x, newy, spawnLocation[i].transform.position.z);

            if (i <= 4)
            {

                //Vertical insulator: poles 0-4
                if (shuffle[0].Equals(poleTypes[0]))
                {

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
                //Modified Vertical
                else if ((shuffle[0].Equals(poleTypes[1])))
                {

                    //Spawn the B insulator and rotate
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

                //Triangular
                else if ((shuffle[0].Equals(poleTypes[2])))
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

                //Crossarm
                else if ((shuffle[0].Equals(poleTypes[3])))
                {
                    Quaternion rotateInsulator = Quaternion.Euler(-90, 0, 0);
                    Vector3 locA = new Vector3(spawnLocationCrossarmA[i].transform.position.x, spawnLocationCrossarmA[i].transform.position.y, spawnLocationCrossarmA[i].transform.position.z);
                    Instantiate(insulatorMaterial[0], locA, rotateInsulator);

                    Vector3 locB = new Vector3(spawnLocationCrossarmB[i].transform.position.x, spawnLocationCrossarmB[i].transform.position.y, spawnLocationCrossarmB[i].transform.position.z);
                    Instantiate(insulatorMaterial[0], locB, rotateInsulator);

                    Vector3 locC = new Vector3(spawnLocationCrossarmC[i].transform.position.x, spawnLocationCrossarmC[i].transform.position.y, spawnLocationCrossarmC[i].transform.position.z);
                    Instantiate(insulatorMaterial[0], locC, rotateInsulator);

                    arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                    newPole[i].PoleObject = arrayOfPoles[i];
                    newPole[i].poleType = shuffle[0];
                    Debug.Log("shuffle is =" + shuffle[0]);
                }

            }
            else if (i >= 5 && i <= 9)
            {
                //Vertical insulator: poles 5-9
                if (shuffle[0].Equals(poleTypes[0]))
                {

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
                //Modified Vertical: poles 5-9
                else if ((shuffle[0].Equals(poleTypes[1])))
                {
                    //Spawn the B insulator w/o rotating
                    Quaternion rotateInsulator = Quaternion.Euler(-180,0,0);
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
                //Triangular: poles 5-9
                else if ((shuffle[0].Equals(poleTypes[2])))
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
                //Crossarm: poles 5-9
                else if ((shuffle[0].Equals(poleTypes[3])))
                {
                    Quaternion rotateInsulator = Quaternion.Euler(-90, 0, 0);
                    Vector3 locA = new Vector3(spawnLocationCrossarmA[i].transform.position.x, spawnLocationCrossarmA[i].transform.position.y, spawnLocationCrossarmA[i].transform.position.z);
                    Instantiate(insulatorMaterial[0], locA, rotateInsulator);

                    Vector3 locB = new Vector3(spawnLocationCrossarmB[i].transform.position.x, spawnLocationCrossarmB[i].transform.position.y, spawnLocationCrossarmB[i].transform.position.z);
                    Instantiate(insulatorMaterial[0], locB, rotateInsulator);

                    Vector3 locC = new Vector3(spawnLocationCrossarmC[i].transform.position.x, spawnLocationCrossarmC[i].transform.position.y, spawnLocationCrossarmC[i].transform.position.z);
                    Instantiate(insulatorMaterial[0], locC, rotateInsulator);

                    arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                    newPole[i].PoleObject = arrayOfPoles[i];
                    newPole[i].poleType = shuffle[0];
                    Debug.Log("shuffle is =" + shuffle[0]);
                }

            }
            else if (i >= 10 && i <= 14)
            {
                arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                newPole[i].PoleObject = arrayOfPoles[i];
                newPole[i].poleType = poleTypes[2];
                //Debug.Log("shuffle is =" + shuffle[2]);
                //Debug.Log("i is:" + i);
            }
            else if (i > 14)
            {
                arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                newPole[i].PoleObject = arrayOfPoles[i];
                newPole[i].poleType = poleTypes[3];
                // Debug.Log("shuffle is =" + shuffle[3]);
                //Debug.Log("i is:" + i);

            }
            }


        }
    }

 