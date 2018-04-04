using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneData data = transform.GetComponent<SceneData>();

        //trigger pole generator'
        if (GameObject.Find("PoleGenerator") == null) {
            print("Can't find pole generator");
            return;
        }
        
        PoleGeneration poleGenerator =  GameObject.Find("PoleGenerator").GetComponent<PoleGeneration>();
        poleGenerator.generatePoles();
        data.setPoles(poleGenerator.getPoleList());

        //trigger equipment generator
        if (GameObject.Find("EquipmentGenerator") == null)
        {
            print("Can't find equipment generator");
            return;
        }
        EquipmentGenerator equipGen = GameObject.Find("EquipmentGenerator").GetComponent<EquipmentGenerator>();
        equipGen.generateEquipment(data);


        //trigger damage generator
        if (GameObject.Find("DamageGenerator") == null)
        {
            print("Can't find damage generator");
        }
        else
        {
            DamageGenerator damageGenerator = GameObject.Find("DamageGenerator").GetComponent<DamageGenerator>();
            damageGenerator.generateDamage();
        }

        //trigger wire connector
        if (GameObject.Find("WireConnector") == null)
        {
            print("Can't find wire Connector");
        }
        else
        {
            wireConnect2 wireConnector = GameObject.Find("WireConnector").GetComponent<wireConnect2>();
            wireConnector.connectWire();
        }


        //CAF generator 
		GameObject[] poles =  poleGenerator.getPoleList();
		GameObject screenPrefab = GameObject.Find ("CAFScreen").gameObject;
		foreach (GameObject pole in poles) {
			Vector3 location = pole.transform.position;

			int poleIndex = pole.GetComponent<PoleData> ().poleIndex;
			if ( poleIndex < poles.Length / 2) {
				location += new Vector3(0.0f, 0.0f,3.0f);
			} else {
				location += new Vector3(-3.0f, 0.0f,0.0f);
			}
			GameObject tempScene = Instantiate (screenPrefab,location ,screenPrefab.transform.rotation);
			tempScene.name = "CAF" + poleIndex;

			tempScene.GetComponent<ConditionAssessment> ().pole = pole;
		}

		screenPrefab.SetActive (false);

    }

}
