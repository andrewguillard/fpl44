using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wireConnect : MonoBehaviour {
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

        wireObject = new GameObject[poles.Length,3];
        
        //get all wireobjects 
        for (int i = 0; i < poles.Length; i++) {
            for(int j=0;j< 3; j++)
            {
                string name =(j+1).ToString();
                GameObject temp; 

                if (poles[i].transform.Find(name) == null)
                {
                    print("can't find wire object");
                }
                else
                {
                    temp = poles[i].transform.Find(name).gameObject;
                    wireObject[i,j] = temp;
                    if (i == poles.Length - 1)
                        continue;
                    wireObject[i,j].AddComponent<CableScript>();
                    //add material

                    //change 
                    LineRenderer wire = wireObject[i, j].GetComponent<LineRenderer>();
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
                CableScript cable =  wireObject[i,j].transform.GetComponent<CableScript>();
                cable.setEndPoint(wireObject[i+1,j ].gameObject);
            }
        }

    }


	
}
