using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Transformer : MonoBehaviour {

	//// Use this for initialization
	//void Start () {
	//    //find all fuseswitch & move them out
 //       foreach(Transform t in transform)
 //       {
 //           if(t.GetComponent<Data>() != null)
 //           {
 //               if (t.GetComponent<Data>().name.Contains("FuseSwitch"))
 //               {
 //                   t.parent = transform.parent;
 //               }
 //           }
 //       }

	//}
	
    public void fillWire()
    {
        //find wire points
        List<Transform> pointsT = new List<Transform>();

        List<Transform> pointsF = new List<Transform>();

        foreach (Transform t in transform)
        {
            if (t.name.Contains("Tran-FS"))
            {
                pointsT.Add(t);
            }else if (t.name.Contains("BottomFS"))
            {
                pointsF.Add(t);
            }
        }
        pointsT = pointsT.OrderBy(o => o.name).ToList();
        pointsF = pointsF.OrderBy(o => o.name).ToList();


        //Connect transformer to fuseswitch
        Transform[] tempT = pointsT.ToArray();
        Transform[] tempF = pointsF.ToArray();

        for(int i = 0; i < tempT.Length; i++)
        {
            UtilityFunctions.lineConnect(tempT[i].gameObject, tempF[i].gameObject, 0.02f, 5, 0.03f);            
        }
        
        //connect FuseSwitch to wire




    }
}
