using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is " + scene.name + ".");
        Debug.Log("Num scene = " + SceneManager.sceneCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
