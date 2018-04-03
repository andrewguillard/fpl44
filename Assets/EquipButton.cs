using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipButton : MonoBehaviour
{
    Sprite clicked;
    Sprite normal;
    SceneData data;
    string equip;
    bool isClicked = false;

    // Use this for initialization
    void Start()
    {
        normal = Resources.Load<Sprite>("Button/Rects/rectRy8");
        clicked = Resources.Load<Sprite>("Button/Rects/rect4pxRy8");
        data = GameObject.Find("SceneData").GetComponent<SceneData>();
        equip = transform.Find("Text").GetComponent<Text>().text.Replace(" ", string.Empty);

        Button btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!isClicked)
        {
            data.addDamageEquipment(equip);
            transform.GetComponent<Image>().overrideSprite = clicked;
        }

        else
        {
            data.removeDamageEquipment(equip);
            transform.GetComponent<Image>().overrideSprite = normal;
        }

        isClicked = !isClicked;
    }

    public void deselect()
    {
        transform.GetComponent<Image>().overrideSprite = normal;
        isClicked = false;
    }
}
