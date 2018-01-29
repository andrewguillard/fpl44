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
    public GameObject[] arrayOfPoles; //delete this?

    //Array of pole objects
    Pole[] newPole = new Pole[20];
   

    //public string typeOfPole = "POLEA";

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

    /*
    public List<string> getRandomPole(int x) {
        int y = 0;
        return List<string>;
    }
    */

    void Start()
    {
        /*
        arrayOfPoles = new GameObject[20];
        int j = 0;
        for (int i = 0; i < spawnLocation.Length; i++) {
            j = Random.Range(0, poleMaterial.Length);

            newPole[i] = new Pole();

            //increase y-axis location
            float newy = spawnLocation[i].transform.position.y + (10.886f / 2f);
            //Location of new pole
            Vector3 loc = new Vector3(spawnLocation[i].transform.position.x, newy, spawnLocation[i].transform.position.z);

            arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);

            newPole[i].PoleObject = arrayOfPoles[i];
            newPole[i].polyType = "HOOPEDDEEDOO";

           // newPole[i] = arrayOfPoles[i].GetComponent<Pole>();
           //arrayOfPoles[i].typeOfPole1 = "typeOfPole";
            Debug.Log("var i ="  + i);
        }
    }
}
*/
        arrayOfPoles = new GameObject[20];
        
        for (int i = 0; i < spawnLocation.Length; i++)
        {
            newPole[i] = new Pole();
           
            //increase y-axis location
            float newy = spawnLocation[i].transform.position.y + (10.886f / 2f);

            //Location of new pole
            Vector3 loc = new Vector3(spawnLocation[i].transform.position.x, newy, spawnLocation[i].transform.position.z);

            if (i <= 4)
            {
                //This is going to rotate the insulator and then spawn it.
                Quaternion rotateInsulator = Quaternion.Euler(90, 0, 0);
                Vector3 locA = new Vector3(spawnLocationVerticalA[i].transform.position.x, spawnLocationVerticalA[i].transform.position.y, spawnLocationVerticalA[i].transform.position.z);
                Instantiate(insulatorMaterial[0], locA, rotateInsulator);
           
                Vector3 locB = new Vector3(spawnLocationVerticalB[i].transform.position.x, spawnLocationVerticalB[i].transform.position.y, spawnLocationVerticalB[i].transform.position.z);
                Instantiate(insulatorMaterial[0], locB, rotateInsulator);

                Vector3 locC = new Vector3(spawnLocationVerticalC[i].transform.position.x, spawnLocationVerticalC[i].transform.position.y, spawnLocationVerticalC[i].transform.position.z);
                Instantiate(insulatorMaterial[0], locC, rotateInsulator);

                arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                newPole[i].PoleObject = arrayOfPoles[i];
                newPole[i].poleType = poleTypes[0];
                Debug.Log("Pole Type is =" + newPole[i].poleType);
                Debug.Log("i is:" +i);
            }
            else if (i >= 5 && i <= 9)
            {
                arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                newPole[i].PoleObject = arrayOfPoles[i];
                newPole[i].poleType = poleTypes[1];
                Debug.Log("Pole Type is =" + newPole[i].poleType);
                Debug.Log("i is:" + i);
            }
            else if (i >= 10 && i <= 14)
            {
                arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                newPole[i].PoleObject = arrayOfPoles[i];
                newPole[i].poleType = poleTypes[2];
                Debug.Log("Pole Type is =" + newPole[i].poleType);
                Debug.Log("i is:" + i);
            }
            else if(i > 14)
            {
                arrayOfPoles[i] = Instantiate(poleMaterial[getRandom(2)], loc, Quaternion.identity);
                newPole[i].PoleObject = arrayOfPoles[i];
                newPole[i].poleType = poleTypes[3];
                Debug.Log("Pole Type is =" + newPole[i].poleType);
                Debug.Log("i is:" + i);
                
            }
        }


    }
}

 