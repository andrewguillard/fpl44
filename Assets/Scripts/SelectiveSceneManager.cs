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

    // Use this for initialization
    void Start()
    {
        if (data == null)
            data = transform.GetComponent<SceneData>();

        poleGenerate();
        equipmentGenerate();
        wireGenerate();

        //trigger damage generator
        if (GameObject.Find("DamageGenerator") == null)
        {
            print("Can't find damage generator");
        }
        else
        {
            damageGenerator.damageSet.SetActive(true);
            damageGenerator.generateDamage();
            damageGenerator.damageSet.SetActive(false);
        }

        GameObject CAFs = new GameObject("CAFs");
        GameObject[] poles = poleGenerator.getPoleList();
        foreach (GameObject pole in poles)
        {
            Vector3 location = pole.transform.position;

            int poleIndex = pole.GetComponent<PoleData>().poleIndex;
            if (poleIndex < poles.Length / 2)
            {
                location += new Vector3(2.7f, 0.0f, 3.0f);
            }
            else
            {
                location += new Vector3(-3.0f, 0.0f, 2.7f);
            }

            GameObject tempScene = Instantiate(screenPrefab, location, screenPrefab.transform.rotation);
            if (poleIndex > poles.Length / 2)
            {
                tempScene.transform.Rotate(0, -90, 0);
            }
            else if (poleIndex == poles.Length / 2)
            {
                tempScene.transform.Rotate(0, -45, 0);
            }

            tempScene.name = "CAF" + poleIndex;
            string searchString = tempScene.name + "/CAF_CANVAS";

            ConditionAssessment aform;
            //search for condition 
            if (tempScene.transform.Find("CAF_CANVAS") != null)
            {
                aform = tempScene.transform.Find("CAF_CANVAS").GetComponent<ConditionAssessment>();
                aform.pole = pole;
            }
            else
                print("Can't find the condition assessment script in CAF_CANVAS");

            tempScene.transform.parent = CAFs.transform;
        }

        screenPrefab.SetActive(false);
    }

    void poleGenerate()
    {
        //trigger pole generator'
        if (GameObject.Find("PoleGenerator") == null)
        {
            Debug.LogError("Can't find pole generator");
            return;
        }
        else
        {
            if (poleGenerator == null)
                poleGenerator = GameObject.Find("PoleGenerator").GetComponent<PoleGeneration>();
            poleGenerator.generatePoles();
            data.setPoles(poleGenerator.getPoleList());
        }
    }

    void equipmentGenerate()
    {
        //trigger equipment generator
        if (GameObject.Find("EquipmentGenerator") == null)
        {
            Debug.LogError("Can't find equipment generator");
            return;
        }
        else
        {
            if (equipGen == null)
                equipGen = GameObject.Find("EquipmentGenerator").GetComponent<EquipmentGenerator>();
            else
                equipGen.generateEquipment(data);
        }
    }

    void wireGenerate()
    {
        //trigger wire connector
        if (GameObject.Find("WireConnector") == null)
        {
            print("Can't find wire Connector");
        }
        else
        {
            wireConnector.WireConnect();
        }
    }

}