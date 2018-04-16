using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBoxController : MonoBehaviour {
    [SerializeField] private GameObject compass;
    [SerializeField] private GameObject Binocular;

    // Use this for initialization
    void Start () {
        Button compassBtn = GameObject.Find("CompassBtn").GetComponent<Button>();
        Button binocularBtn = GameObject.Find("BinocularBtn").GetComponent<Button>();

        compassBtn.onClick.AddListener(CompassButton);
        binocularBtn.onClick.AddListener(binocularButton);

    }

    void CompassButton()
    {
        compass.SetActive(!compass.activeSelf);
    }
    void binocularButton()
    {
        print("Binocular is pressing");
        Binocular.SetActive(!Binocular.activeSelf);
        print(Binocular.gameObject);
    }



}
