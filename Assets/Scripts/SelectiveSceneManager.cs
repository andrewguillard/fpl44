using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject screenPrefab;
    [SerializeField] private SceneData data;
    [SerializeField] private PoleGeneration poleGenerator;
    [SerializeField] private EquipmentGenerator equipGen;
    [SerializeField] private DamageGenerator damageGenerator;
    [SerializeField] private wireConnect2 wireConnector;
    [SerializeField] private CAFGenerator cafGenerator;

    // Use this for initialization
    void Start()
    {


        if (data == null)
            data = transform.GetComponent<SceneData>();

        //generate pole
        poleGenerator.gameObject.SetActive(true);
        equipGen.gameObject.SetActive(true);

        wireConnector.gameObject.SetActive(true);

        damageGenerator.gameObject.SetActive(true);

        cafGenerator.gameObject.SetActive(true);
    }

    

    //GameObject CAFs = new GameObject("CAFs");
    //foreach (GameObject pole in poles)
    //{
    //    Vector3 location = pole.transform.position;

    //    int poleIndex = pole.GetComponent<PoleData>().poleIndex;
    //    if (poleIndex < poles.Length / 2)
    //    {
    //        location += new Vector3(2.7f, 0.0f, 3.0f);
    //    }
    //    else
    //    {
    //        location += new Vector3(-3.0f, 0.0f, 2.7f);
    //    }

    //    GameObject tempScene = Instantiate(screenPrefab, location, screenPrefab.transform.rotation);
    //    if (poleIndex > poles.Length / 2)
    //    {
    //        tempScene.transform.Rotate(0, -90, 0);
    //    }
    //    else if (poleIndex == poles.Length / 2)
    //    {
    //        tempScene.transform.Rotate(0, -45, 0);
    //    }

    //    tempScene.name = "CAF" + poleIndex;
    //    string searchString = tempScene.name + "/CAF_CANVAS";

    //    ConditionAssessment aform;
    //    //search for condition 
    //    if (tempScene.transform.Find("CAF_CANVAS") != null)
    //    {
    //        aform = tempScene.transform.Find("CAF_CANVAS").GetComponent<ConditionAssessment>();
    //        aform.pole = pole;
    //    }
    //    else
    //        print("Can't find the condition assessment script in CAF_CANVAS");

    //    tempScene.transform.parent = CAFs.transform;
    //}

    //screenPrefab.SetActive(false);

}