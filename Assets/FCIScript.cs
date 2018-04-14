using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCIScript : MonoBehaviour {
    [SerializeField] private GameObject inPoint;
    [SerializeField] private GameObject outPoint;
    [SerializeField] private PoleGeneration poleGenerator;

    private PoleData pole;
    private readonly float DISTANCE = 4;
    // Use this for initialization
    void Start () {
        if (transform.parent.name != "EquipmentSet" && transform.parent.name != "DamageSet")
        {
            pole = transform.parent.GetComponent<PoleData>();

            int phaseNum = Random.Range(0, 3);

            Vector3 loc = pole.wireOutPoints[phaseNum].transform.position;

            if (pole.wireDirection.ToLower().Equals("x"))
            {
                loc.x -= DISTANCE;
            }
            else
            {
                loc.y -= DISTANCE;
            }

            transform.position = loc;
            //wire Connect
            GameObject startPoint = pole.wireOutPoints[phaseNum];
            GameObject endPoint;
            if (startPoint.GetComponent<CableScript>() != null)
            {
                endPoint = startPoint.GetComponent<CableScript>().getEndPoint();
                UtilityFunctions.AdjustineConnect(startPoint, endPoint, outPoint);
            }
            else
            {
                endPoint = poleGenerator.getPoleList()[pole.poleIndex + 1].GetComponent<PoleData>().wireInPoints[phaseNum];
                UtilityFunctions.lineConnect(startPoint, outPoint, 0.07f, 5, 0.1f);
                UtilityFunctions.lineConnect(outPoint, endPoint, 0.07f, 5, 0.2f);

            }

        }



    }

    // Update is called once per frame
    void Update () {
		
	}
}
