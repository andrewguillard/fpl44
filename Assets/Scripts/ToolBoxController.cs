using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBoxController : MonoBehaviour {
    public GameObject compass;

    // Use this for initialization
    void Start () {
        Button compassBtn = GameObject.Find("CompassBtn").GetComponent<Button>();
        compassBtn.onClick.AddListener(CompassButton);
	}

    void CompassButton()
    {
        compass.gameObject.SetActive(!compass.gameObject.activeSelf);
    }
	
    
}
