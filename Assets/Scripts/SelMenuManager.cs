using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelMenuManager : MonoBehaviour {
    public GameObject[] buttonList;
    public readonly string[] nameList = { "" , ""};

    public void clearEquipMenu()
    {
        //find equipmenu 
        Transform menu = transform.Find("EquipmentPanel");

        foreach(Transform child in menu)
        {
            foreach (Transform button in child)
            {
                if (button.name.Contains("Btn"))
                {
                    //clear selected button
                    EquipButton btn = button.GetComponent<EquipButton>();
                    btn.deselect();
                }
            }
        }
    }

    //public void loadSceneClick(string name)
    //{
    //    if(buttonList[])
    //}
}
