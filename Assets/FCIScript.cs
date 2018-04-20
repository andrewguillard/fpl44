using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCIScript : MonoBehaviour {
    [SerializeField] private GameObject inPoint;
    [SerializeField] private GameObject outPoint;
    [SerializeField] private PoleGeneration poleGenerator;
    public GameObject fciObject;
    private readonly float DISTANCE = 4;
    // Use this for initialization
    public void setFCI (PoleData pole, int phaseNum) {
        if (poleGenerator == null) poleGenerator =  GameObject.Find("ListOfPoles").GetComponent<PoleGeneration>();

        Vector3 loc = pole.wireOutPoints[phaseNum].transform.position;

        if (pole.wireDirection.ToLower().Equals("x"))
        {
            loc.x -= DISTANCE;
        }
        else
        {
            loc.z -= DISTANCE;
        }

        transform.position = loc;
        //wire Connect
        GameObject startPoint = pole.wireOutPoints[phaseNum];
        GameObject endPoint = null;
        if (startPoint.GetComponent<CableScript>() != null)
        {
            endPoint = startPoint.GetComponent<CableScript>().getEndPoint();
            UtilityFunctions.AdjustineConnect(startPoint, endPoint, outPoint);
        }
        else
        {
            UtilityFunctions.lineConnect(startPoint, outPoint, 0.07f, 5, 0.1f);
            if (pole.poleIndex < poleGenerator.getPoleList().Length-1) {
                endPoint = poleGenerator.getPoleList()[pole.poleIndex + 1].GetComponent<PoleData>().wireInPoints[phaseNum];
                UtilityFunctions.lineConnect(outPoint, endPoint, 0.07f, 5, 0.2f);

            }
        }
        pole.wireOutPoints[phaseNum] = outPoint;
    }

}
