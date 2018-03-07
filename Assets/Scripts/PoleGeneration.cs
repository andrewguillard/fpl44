using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleGeneration : MonoBehaviour {

    //Global Variables
    public GameObject[] poles; // give all pole that need to random
    public GameObject startSpot; // Pole next where player start 
    public LineRenderer line1;
    public int numberOfPole = 20;
    private GameObject[] poleList;
    private GameObject[][] wirePoint; 
    private Vector3[] wire1Pos;

    // Use this for initialization
    void Start()
    {
        this.name = "ListOfPoles";
        if (startSpot == null) {
            startSpot = this.gameObject;
        }
        //create 10 new gameObject
        int poleNum = numberOfPole;
        poleList = new GameObject[poleNum];
        wirePoint = new GameObject[poleNum][];
        wire1Pos = new Vector3[poleNum];

        if (poles.Length == 0)
        {
            poles = GameObject.FindGameObjectsWithTag("Pole");
        }

        //populate poles
        setPole(startSpot.gameObject.transform.position);

        //disable template Poles
        deactivePole();

        //connect line 
        setLine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    ////void fillRandomPole() {
    //    //4 zone : 0 vertical (V) ,1 ModifiedVertical (MV),2 Triangular(T),3 CrossArm(C)

    //    int randomNum = Random.Range(0,4);

    //    bool[] fill = new bool[4];
    //    int start = 0;
    //    for (int i = 0; i < 4; i++) {
    //        while (fill[randomNum] == true) {
    //            //if that framing is already random, change it
    //            randomNum = Random.Range(0, 3);
                
    //        }
    //        fill[randomNum] = true;
    //        GameObject[] temp = new GameObject[2];
    //        switch(randomNum)
    //        {
    //            case 0:
    //                temp = GameObject.FindGameObjectsWithTag("VPole");
    //                break;
    //            case 1:
    //                temp = GameObject.FindGameObjectsWithTag("MVPole");
    //                break;
    //            case 2:
    //                temp = GameObject.FindGameObjectsWithTag("VPole"); //change it
    //                break;
    //            case 3:
    //                temp = GameObject.FindGameObjectsWithTag("VPole"); //change it
    //                break;
    //        }

    //        //fill a portion of poles array with list of pole template.
    //        start = smallerRandom(temp, start);
    //    }


    //}

    //return next start value
    //int smallerRandom(GameObject[] p, int start) {
        

    //    for (int i=0; i < (numberOfPole / 4);i++)
    //    {
    //        int num = Random.Range(0, p.Length);
    //        //poleList[start + i] = p[num];
    //        print("Smaller Random   :"+ i+"----"+p[num]);
    //    }

    //    return start + (numberOfPole / 4);
    //}


    void deactivePole()
    {
        for (int i = 0; i < poles.Length; i++) {
            poles[i].SetActive(false);
        }
    }

    void setLine() {
        for (int i = 0; i < numberOfPole-1; i++) {
            for(int j = 0; j < 3; j++)
            {
                GameObject current = wirePoint[i][j];
                GameObject next = wirePoint[i + 1][j];
                print("setting pole " + i + " name" + current);
                
                current.GetComponent<CableScript>().setEndPoint(next);
            }
        }


    }

    void setPole(Vector3 startLoc)
    {
        //1st z locaiont
        Vector3 temp = startLoc;
        for (int i = 0, n=0; i < numberOfPole; i++, n++) //n is pole numnber in poleList Array 
        {
            int j = Random.Range(0, poles.Length); //random variable

            Quaternion rotation = new Quaternion();
            if (n <= numberOfPole/2) {
                rotation = Quaternion.Euler(0, 90, 0);
            }
            else {
                rotation = Quaternion.Euler(0, 180,0);
            }

            poleList[n] = Instantiate(poles[j], temp, rotation);
            string name = "pole" + n;
            poleList[n].name = name;

            poleList[n].transform.parent = transform;
            GameObject[] wireLoc = new GameObject[3]; //3 intesection locations of insulator and wire

            //save location of insulator point that wire on
            for (int k = 0; k < 3; k++) {
                wireLoc[k] = poleList[n].gameObject.transform.GetChild(k+4).gameObject;
                wire1Pos[n] = (transform.TransformPoint(transform.TransformPoint(transform.TransformPoint(transform.TransformPoint(wireLoc[k].transform.position)))));
                name = "wire" + n;
                wireLoc[k].name = name; 
            }


            wirePoint[n] = wireLoc;
            //update x location
            if (n < numberOfPole/2) {
                temp.Set(temp.x, temp.y, temp.z + 20);
            }
            else{
                temp.Set(temp.x + 20, temp.y, temp.z);
            }
        }
    }
}
