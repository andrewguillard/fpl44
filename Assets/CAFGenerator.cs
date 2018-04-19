using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAFGenerator : MonoBehaviour {

    [SerializeField] GameObject cafPrefab;
    public GameObject[] poles;
	// Use this for initialization
	void Start () {
        setCAFS();
	}

    void setCAFS()
    {
        poles =  GameObject.Find("SceneManager").GetComponent<SceneData>().getPoles();

        GameObject CAFs = gameObject;

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

            GameObject tempScene = Instantiate(cafPrefab, location, cafPrefab.transform.rotation);

            if (poleIndex > poles.Length / 2)
            {
                tempScene.transform.Rotate(0, -90, 0);
            }
            else if (poleIndex == poles.Length / 2)
            {
                tempScene.transform.Rotate(0, -45, 0);
            }

            tempScene.name = "CAF" + poleIndex;
            //-> to this point I'm done with pole generation
            
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
    }
}
