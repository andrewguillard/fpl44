using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour {
    public GameObject EquipmentSet;

    public void generateEquipment(SceneData data)
    {
        string[] equips = data.getDamageEquipmentArray();
        GameObject[] poleList = data.getPoles();

        //list of prefab to store and spawn
        HashSet<GameObject> listPrefab = new HashSet<GameObject>();
        
        //get list of prefab to spawn
        foreach (string equip in equips)
        {
            //Declare and initialize
            GameObject prefab = getEquipPrefab(equip);

            //debug
            print("equipment = " + equip);


            if (equip.Contains("Pole") || equip.Contains("Insulator")) //all pole comes with it
                continue;

            //feed the equipment to the pole 
            if (prefab != null)
            {
                listPrefab.Add(prefab);
            }
            else
            {
                //not in the set but have to check other place too (check as grandchild )
                foreach (Transform eq in EquipmentSet.transform)
                {
                    foreach (Transform grandchild in eq)
                    {
                        if (grandchild.name.Contains(equip))
                        {
                            if(listPrefab.Add(eq.gameObject))
                                listPrefab.Add(eq.gameObject);
                            break;
                        }
                    }
                }
            }
        }

        //decide what pole and what equipment to spawn
        GameObject[] prefabArray= new GameObject[listPrefab.Count];
        listPrefab.CopyTo(prefabArray);

        //for each pole 
        foreach(GameObject pole in poleList)
        {
            //if corner pole skip
            if (pole.transform.GetComponent<PoleData>().poleIndex == poleList.Length / 2)
                continue;

            //a new random generator to put a empty pole
            int random = Random.Range(0, 10); // p = 0.1 
            if (random.Equals(9))
                continue;

            int randomIndex = Random.Range(0, prefabArray.Length);


            GameObject eq = Instantiate(prefabArray[randomIndex], pole.transform);
            eq.transform.parent = pole.transform;
            eq.name = prefabArray[randomIndex].name;

            ////call appriate function for different type of equipment
            //if (eq.name == "CapacitorBank")
            //{
            //    eq.GetComponent<CapacitorBank2>().fillwire();
            //}

            //add more equipment in this pole
        }


        disableEquipmentSet();
    }

    void disableEquipmentSet()
    {
        if(EquipmentSet != null)
        {
            EquipmentSet.SetActive(false);
        }
    }


    GameObject getEquipPrefab(string name)
    {
        //special Case
        if(name == "Transformer")
        {
            int ran = Random.Range(1,4);
            name += ran;
        }

        if(EquipmentSet == null)
        {
            print("Equipment set is empty");
        }
        else if(EquipmentSet.transform.Find(name) == null)
        {
            return null;
        }

        return EquipmentSet.transform.Find(name).gameObject;
    }
}
