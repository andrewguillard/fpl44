using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wireConnect2 : MonoBehaviour {
    public GameObject poleSpawnObject;
    private GameObject[,] wireObject;
    private GameObject[] poles;
    public Material wireMaterial;
	// Use this for initialization
	void Start () {

        if(poleSpawnObject.GetComponent<PoleGeneration>() != null)
            poles = poleSpawnObject.GetComponent<PoleGeneration>().getPoleList();
        else
            poles = poleSpawnObject.GetComponent<PoleSpawner>().getPoleList();

        wireObject = new GameObject[poles.Length,6]; //1st 3 is in , 2nd 3 is out
        
        //get all wireobjects 
        for (int i = 0; i < poles.Length; i++) {
            for(int j=0;j< 3; j++)
            {
                string name =(j+1).ToString();
                GameObject temp;

                if (findMarker(name, poles[i]) == null)
                {
                    print("can't find wire object");
                }
                else
                {
                    temp = findMarker(name, poles[i]);
                    print(temp.name);
                    wireObject[i,j] = temp;

                    //find out marker, if not found use in marker
                    wireObject[i, j + 3] = findOutMarker(name, poles[i]);
                    print(findOutMarker(name, poles[i]).name);

                    //dont add cable script to the last pole
                    if (i == poles.Length - 1)
                        continue;
                    if (wireObject[i, j + 3].GetComponent<CableScript>() ==null)
                        wireObject[i,j+3].AddComponent<CableScript>();
                    //add material

                    //change 
                    LineRenderer wire = wireObject[i, j+3].GetComponent<LineRenderer>();
                    wire.SetWidth(0.07f,0.07f);
                    wire.material = wireMaterial;
                }
            }
        }

        //connect all wire object together

        for (int i = 0; i < poles.Length-1; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                CableScript cable =  wireObject[i,j+3].transform.GetComponent<CableScript>();
                cable.setEndPoint(wireObject[i+1,j].gameObject);
            }
        }

    }

	GameObject findMarker(string name, GameObject pole)
    {
        // 11-21-31 and 12-22-32 format
        string name2 = name + "1";
        //A1-B1-C1 and A2-B2-C2 format
        string name3 = "";
        switch (name)
        {
            case "1":
                name3 = "A";
                break;
            case "2":
                name3 = "B";
                break;
            case "3":
                name3 = "C";
                break;
        }
        name3 += "1";

        //find 1/2/3
        if (pole.transform.Find(name) != null)
            return pole.transform.Find(name).gameObject;
        else if (pole.transform.Find(name2) != null)
            return pole.transform.Find(name2).gameObject;
        else
            return pole.transform.Find(name3).gameObject;
    }

    GameObject findOutMarker(string name, GameObject pole)
    {
        // 11-21-31 and 12-22-32 format
        string name2 = name + "2";
        //A1-B1-C1 and A2-B2-C2 format
        string name3 = "";
        switch (name)
        {
            case "1":
                name3 = "A";
                break;
            case "2":
                name3 = "B";
                break;
            case "3":
                name3 = "C";
                break;
        }
        name3 += "2";


        //find 1/2/3
        if (pole.transform.Find(name) != null)
            return pole.transform.Find(name).gameObject;
        else if (pole.transform.Find(name2) != null)
            return pole.transform.Find(name2).gameObject;
        else
            return pole.transform.Find(name3).gameObject;
    }
}
