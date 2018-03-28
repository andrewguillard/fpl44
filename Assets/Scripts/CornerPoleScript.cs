using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerPoleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string[] phase = { "A", "B", "C" };
        for(int i = 0; i < phase.Length; i++)
        {
            GameObject s = gameObject.transform.Find(phase[i] + "1").gameObject;
            GameObject end = gameObject.transform.Find(phase[i] + "2").gameObject;

            UtilityFunctions.lineConnect(s,end,0.07f);

            s.GetComponent<CableScript>().setPointInLine(10);
            s.GetComponent<CableScript>().setSagAmplitude(0.5f);
        }
    }

}
