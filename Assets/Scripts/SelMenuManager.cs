using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelMenuManager : MonoBehaviour {
    HashSet<string> selection;
    public readonly string[] nameList = { "" , ""};

    private void Awake()
    {
        selection = new HashSet<string>();
        clearEquipMenu();

    }

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

    public void equipButtonClick(string name)
    {
        if (!selection.Add(name))
        {
            selection.Remove(name);
        }
    }

    public string[] getSelectionArray()
    {
        string[] newstring = new string[selection.Count];
        selection.CopyTo(newstring);
        return newstring;
    }
    
    public void clearSelection()
    {
        selection.Clear();
    }
}
