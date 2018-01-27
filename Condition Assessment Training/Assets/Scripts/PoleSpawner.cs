using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleSpawner : MonoBehaviour {
    public Transform[] spawnLocation; //Location of each pole
	public GameObject[] poles;


	void Start(){

        for (int i = 0, j = Random.Range(0, poles.Length); i < spawnLocation.Length; i++, j= Random.Range(0,poles.Length)) {
            
                //increase y-axis location
            float newy = spawnLocation[i].transform.position.y +(10.886f/2f);
            //Location of new pole
            Vector3 loc = new Vector3(spawnLocation[i].transform.position.x,newy, spawnLocation[i].transform.position.z);

            //the vector3 is using 3 for the y-value because the blender models are still messed up. It's also aligning the models based off of the top of the model..weird.
            Instantiate (poles[j], loc, Quaternion.identity);
		}
	}
}
	
