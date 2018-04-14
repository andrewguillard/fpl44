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
        if (transform.parent.name == "EquipmentSet")
            return;

        pole = transform.parent.GetComponent<PoleData>();

        //choose Tree
        int rNum = Random.Range(0, trees.Length);
        //for (int i = 0; i < trees.Length; i++)
        //{
        //    //if (i != rNum)
        //    //{
        //    //    //Destroy(trees[i].gameObject);
        //    //    trees[i].SetActive(false);
        //    //}


        //}
        Instantiate(trees[rNum], transform);
        currentTree = trees[rNum];

        //set location
        Vector3 position = transform.localPosition;

        position.x = ((int)Random.Range(0, 2) == 0) ? distance : -distance;
        
        transform.localPosition = position;
    }
}
