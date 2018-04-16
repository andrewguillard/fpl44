using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpliceScript : MonoBehaviour
{
    public GameObject inpoint;
    public GameObject outpoint;
    public PoleData pole;
    private readonly int minDistance = 5;
    private readonly int maxDistance = 10;
    public int phaseNum;
    [SerializeField] private PoleGeneration poleGenerator;
    // Use this for initialization

    void Start()
    {
        if (poleGenerator == null)
        {
            poleGenerator = GameObject.Find("PoleGenerator").GetComponent<PoleGeneration>();
        }

        if (transform.parent.name != "EquipmentSet" && transform.parent.name != "DamageSet") {
            pole = transform.parent.GetComponent<PoleData>();
            //print(transform.parent.name);

            Vector3 rotation = transform.eulerAngles;
            rotation.y += 90;
            Vector3 position;

            int phaseNum = Random.Range(0, 3); //choose wire phase
            float distance = Random.Range(minDistance, maxDistance);

            char phaseChar='N';
            //Store phase data
            switch (phaseNum)
            {
                case 0:
                    phaseChar = 'A'; break;
                case 1:
                    phaseChar = 'B'; break;
                case 2:
                    phaseChar = 'C'; break;

            }
            transform.GetComponent<Data>().phase = phaseChar;

            //print(pole.wireOutPoints[rNum].transform);
            position = pole.wireOutPoints[phaseNum].transform.position;

            if (pole.wireDirection.ToLower().Equals("x"))
                position.x -= distance;
            else
                position.z -= distance;

            position.y -= 0.1f;
            transform.position = position;
            transform.eulerAngles = rotation;

            //connect to wire
            GameObject startPoint = pole.wireOutPoints[phaseNum];
            if(pole.wireOutPoints[phaseNum].GetComponent<CableScript>() != null)
            {
                GameObject endPoint = pole.wireOutPoints[phaseNum].GetComponent<CableScript>().getEndPoint();

                //connect 
                startPoint.GetComponent<CableScript>().setEndPoint(inpoint);
                startPoint.GetComponent<CableScript>().setSagAmplitude(0.1f);

                UtilityFunctions.lineConnect(outpoint, endPoint, 0.07f, 5, 0.1f);

            }
            else
            {
                print("Poole index" + pole.poleIndex);
                if (pole.poleIndex < poleGenerator.getPoleList().Length-1)
                {
                    GameObject endPoint = poleGenerator.getPoleList()[pole.poleIndex + 1].GetComponent<PoleData>().wireInPoints[phaseNum]; //sorry ^^
                    UtilityFunctions.lineConnect(startPoint, inpoint, 0.07f, 5, 0.1f);
                    UtilityFunctions.lineConnect(outpoint, inpoint, 0.07f, 5, 0.1f);

                }

            }
        }
    }


}
