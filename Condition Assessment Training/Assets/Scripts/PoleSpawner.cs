using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleSpawner : MonoBehaviour {

	public GameObject[] poles;


	void Start(){
	
		for (int i = 0; i < 20; i++) {
			int randomNumber= Random.Range(0, poles.Length);
			//the vector3 is using 3 for the y-value because the blender models are still messed up. It's also aligning the models based off of the top of the model..weird.
			Instantiate (poles[randomNumber], new Vector3 (i*2, 3, 0), Quaternion.identity);
		}
	}
}
	
