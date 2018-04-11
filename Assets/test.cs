using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class test : MonoBehaviour {
    public GameObject prefab1 ;
    public GameObject prefab2 ;
    // Use this for initialization
    void Start() {
        int r = Random.Range(0, 2);

        if (r == 0)
        {
            Instantiate(prefab1,transform.position, transform.rotation);
        }
        else
            Instantiate(prefab2, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
