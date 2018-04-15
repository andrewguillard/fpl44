using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour {
    public GameObject currentTree;
    [SerializeField] private GameObject[] trees;
    private PoleData pole;
    private float distance = 5.0f;

    void Start()
    {
        Data treeData = transform.GetComponent<Data>();

        if (treeData.level == 0|| transform.parent.name == "EquipmentSet" || transform.parent.name == "DamageSet")
            return;

        pole = transform.parent.GetComponent<PoleData>();

        int rNum = Random.Range(0, trees.Length);

        currentTree = Instantiate(trees[rNum], transform);

        //set location
        Vector3 position = transform.localPosition;

        switch (treeData.level)
        {
            case 1:
                position.z -= Random.Range(9, 12);
                position.x -= Random.Range(3,5);


                break;
            case 2:
                position.z -= Random.Range(9, 12);
                position.x -= Random.Range(3, 5);
                break;
            case 3:
                position.z = ((int)Random.Range(0, 2) == 0) ? distance : -distance;
                position.x -= Random.Range(3, 6);

                break;
        }

        transform.localPosition = position;
        
    }
}
