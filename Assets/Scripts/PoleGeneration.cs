using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleGeneration : MonoBehaviour {

    public GameObject[] poles; // sets of poles
    public GameObject startSpot; // Pole next where player start 
    public int numberOfPole = 20;
    private GameObject[] poleList;

    private SceneData menuSelected;
    // Use this for initialization
    void Awake()
    {
        this.name = "ListOfPoles";

        menuSelected = GameObject.FindObjectOfType<SceneData>();
        print("framming = "+menuSelected.getFraming());
        print(transform);
        if (menuSelected.getFraming() == null) {
            //No Selection of frame 
            poles = new GameObject[1];
            poles[0] = GameObject.Find("PoleSet/V");

        }
        else
        {
            string st = "/PoleSet/" + menuSelected.getFraming();
            print(st);
            poles = new GameObject[1];
            poles[0] = GameObject.Find(st);
        }

        if (startSpot == null) {
            startSpot = this.gameObject;
        }

        ////create 10 new gameObject
        poleList = new GameObject[numberOfPole];

        //get a zone order
        int[] zoneOrder = getRandomZone();

        //put poles model set into a new order
        GameObject[] zoneSet = new GameObject[poles.Length];
        for (int i = 0; i < poles.Length; i++) {
            zoneSet[i] = poles[zoneOrder[i]];
        }

        ////populate poles
        populatePole(zoneSet);

        //disable template Poles
        deactivePole();
    }

    private int[] getRandomZone() {
        int lengthList = poles.Length;
        int[] list = new int[lengthList];
        bool[] isAdded = new bool[lengthList];
        for (int i = 0; i < lengthList; i++) {
            int num = Random.Range(0, lengthList);
            while (isAdded[num] == true) {
                //if that number is added to list , get a new number
                num = Random.Range(0, lengthList);
            }
            list[i] = num;
            isAdded[num] = true;
        }
        return list;
    }

    //populate poles into scence
    private void populatePole(GameObject[] template) {

        startSpot.name = "ListOfPole";

        Vector3 tempStart = new Vector3(0, 0, 0);
        tempStart = startSpot.transform.position;
        int numPoleAZone  = numberOfPole / template.Length;
 
        for (int i = 0; i < template.Length; i++) {

            //get rotation
            Quaternion angle = Quaternion.Euler(0, 90, 0);

            //instatiate pole
            for (int j = 0; j < numPoleAZone; j++)
            {
                int childIndex = Random.Range(0, template[i].transform.childCount);

                GameObject temp = template[i].transform.GetChild(childIndex).gameObject;

                //get pole name
                string name = "pole" + (numPoleAZone * i + j) + temp.transform.name;
                int index = numPoleAZone * i + j;
                if (index < (numberOfPole / 2))
                    poleList[index] = Instantiate(temp, tempStart, temp.transform.rotation);
                else {
                    Vector3 tempAngle = temp.transform.rotation.eulerAngles;
                    tempAngle.y -= 90;

                    poleList[index] = Instantiate(temp, tempStart, Quaternion.Euler(tempAngle));
                }
                poleList[index].name = name;
                poleList[index].transform.SetParent(transform);

                //set new location
                if (index < (numberOfPole/2))
                    tempStart.Set(tempStart.x -20, tempStart.y, tempStart.z);
                else
                    tempStart.Set(tempStart.x, tempStart.y, tempStart.z-20);
            }
        }
    }


    void deactivePole()
    {
        for (int i = 0; i < poles.Length; i++)
        {
            poles[i].SetActive(false);
        }
    }

    public GameObject[] getPoleList() {
        return poleList;
    }
}
