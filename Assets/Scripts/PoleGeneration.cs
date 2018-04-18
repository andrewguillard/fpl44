using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoleGeneration : MonoBehaviour {

    public GameObject[] poles;      // sets of poles template to instantiate
    public GameObject CornerPole;   //corner pole template
    public GameObject startSpot;    // Pole next where player start 
    public int numberOfPole = 20;   //number of pole you want to put in the scene
    private GameObject[] poleList;  //list of all poles that are instatiated

    private SceneData menuSelected;
    [SerializeField] private GameObject poleSet;
    void Start()
    {
        poleSet.SetActive(true);
        startSpot.SetActive(true);
        CornerPole.SetActive(true);
        generatePoles();
        GameObject.Find("SceneManager").GetComponent<SceneData>().setPoles(poleList);
    }
    // Use this for initialization
    public void generatePoles()
    {
        //make this gameobject is where stores all poles that instatiated
        this.name = "ListOfPoles";

        menuSelected = GameObject.FindObjectOfType<SceneData>();
        menuSelected.getDamageEquipmentArray(); //load equipment list to data so it will not conflict with the framming
        print("framming = "+ ((menuSelected.getFraming()==null)?"null": menuSelected.getFraming()));

        if (menuSelected.getFraming() != null) {       
            for(int i =0; i< poles.Length; i++)
            {
                if (poles[i].name != menuSelected.getFraming())
                {
                    poles[i].SetActive(false);
                }
            }
            string st = "/PoleSet/" + menuSelected.getFraming();
            //print(st);
            poles = new GameObject[1];
            poles[0] = GameObject.Find(st);
        }

        if (startSpot == null) {
            startSpot = this.gameObject;
        }

        ////create new gameObjects
        poleList = new GameObject[numberOfPole+1];

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

        Vector3 tempStart = new Vector3(0, 0, 0);
        tempStart = startSpot.transform.position;
        int numPoleAZone  = numberOfPole / template.Length;
 
        for (int i = 0, index = 0; i < template.Length; i++) {
            //instatiate pole
            for (int j = 0; j < numPoleAZone; j++, index++)
            {
                //if cornerpole
                if (index == numberOfPole / 2)
                {
                    int randomIndex = Random.Range(0, CornerPole.transform.childCount);
                    GameObject corner = CornerPole.transform.GetChild(randomIndex).gameObject;

                    poleList[index] = Instantiate(corner,
                        tempStart, Quaternion.Euler(corner.transform.rotation.eulerAngles)); ;

                    string n = "pole" + index + corner.transform.name;
                    poleList[index].name = n;
                    poleList[index].transform.SetParent(transform);
                    poleList[index].AddComponent<PoleData>();
                    poleList[index].GetComponent<PoleData>().poleIndex = index;

                    tempStart.Set(tempStart.x, tempStart.y, tempStart.z - 20);

                    index++;
                }

                int childIndex = Random.Range(0, template[i].transform.childCount);

                GameObject temp = template[i].transform.GetChild(childIndex).gameObject;

                //get pole name
                string name = "pole" + index + temp.transform.name;
                //print("spawn pole type " + temp.transform.name);

                //spawn pole
                if (index < (numberOfPole / 2))
                    poleList[index] = Instantiate(temp, tempStart, temp.transform.rotation);
                else {
                    Vector3 tempAngle = temp.transform.rotation.eulerAngles;
                    tempAngle.y -= 90;

                    poleList[index] = Instantiate(temp, tempStart, Quaternion.Euler(tempAngle));
                }


                poleList[index].name = name;
                poleList[index].transform.SetParent(transform);
                PoleData poleData = poleList[index].GetComponent<PoleData>();
                if (poleData == null)
                {
                    poleList[index].AddComponent<PoleData>();
                    poleData = poleList[index].GetComponent<PoleData>();
                }
                poleData.poleIndex = index;
                poleData.wireDirection = (index < numberOfPole/2)?"x":"z";
                poleData.poleType = temp.transform.name;

                //set new location
                if (index <= (numberOfPole/2))
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

        CornerPole.SetActive(false);
    }

    public GameObject[] getPoleList() {
        return poleList;
    }
}
