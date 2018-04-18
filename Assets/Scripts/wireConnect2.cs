using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wireConnect2 : MonoBehaviour
{
    public GameObject poleSpawnObject;
    private GameObject[,] wireObject;
    private GameObject[] poles;
    public Material wireMaterial;

    void Start()
    {
        WireConnect();
    }

    // Use this for initialization
    public void WireConnect()
    {
        if (poleSpawnObject.GetComponent<PoleGeneration>() != null)
            poles = poleSpawnObject.GetComponent<PoleGeneration>().getPoleList();
        else
        {
            Debug.LogError("Can't find pole "); 
            return;
        }
        
        //go through each pole
        for (int i = 0; i < poles.Length - 1; i++)
        {
            PoleData wireStart = poles[i].GetComponent<PoleData>();
            PoleData wireEnd = poles[i + 1].GetComponent<PoleData>();

            for (int j = 0; j < 3; j++)
            {
                //when wire start already connect to the splice , don't connect them
                if(wireStart.GetComponent<CableScript>() != null)
                {
                    continue;
                }
                UtilityFunctions.lineConnect(wireStart.wireOutPoints[j], wireEnd.wireInPoints[j], 0.07f, 5, 0.2f);
            }
        }
    }
}
