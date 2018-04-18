using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBoxController : MonoBehaviour {
    [SerializeField] private GameObject compass;
    [SerializeField] private GameObject Binocular;
    [SerializeField] private Button compassBtn;
    [SerializeField] private Button binocularBtn;


    // Use this for initialization
    void Start () {
        if (compassBtn.gameObject.activeSelf)
            compassBtn.onClick.AddListener(CompassButton);
        if(binocularBtn.gameObject.activeSelf)
            binocularBtn.onClick.AddListener(binocularButton);

    }

    void CompassButton()
    {
        print("Compass btn is pressed");
        compass.SetActive(!compass.activeSelf);
    }
    void binocularButton()
    {
        print("Binocular is pressing");
        Binocular.SetActive(!Binocular.activeSelf);
        print(Binocular.gameObject);
    }



}
