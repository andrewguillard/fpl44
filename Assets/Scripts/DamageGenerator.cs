using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;


public class DamageGenerator : MonoBehaviour
{
    public GameObject damageSet;

    [SerializeField]private GameObject poleListObj;
    [SerializeField] private SceneData data;

    public void generateDamage(){
		
        //get damage equipment 
		string[] dEquip = data.getDamageEquipmentArray();
        int level = data.getDamageLevel();
        //temp = dEquip;

        GameObject[] Poles = UtilityFunctions.getChildObjects(poleListObj);

        for(int i=0; i< Poles.Length; i++)
        {
            if (i == Poles.Length / 2) continue; //skip corner pole for now
            //get a damages name that random choose
            string[] childrenNames = chooseDamageForPole(dEquip, Poles[i]);

            //get equipment gameobject
            Transform[] properEquips = getEquipmentToReplace(Poles[i]);
            List<Transform> finalList = new List<Transform>();
            List<string> taken = new List<string>();
            int count = 0;
            foreach(Transform obj in properEquips)
            {
                if (count > childrenNames.Length)
                    break;

                string objName = obj.GetComponent<Data>().equipmentName;
                if (childrenNames.Contains(objName) && !taken.Contains(objName) )
                {
                    finalList.Add(obj);
                    count++;
                    taken.Add(objName);
                }
                 
            }
            //foreach (Transform t in properEquips)
            //{
            //    print("\t**" + t.name);
            //}
            //foreach (Transform t in finalList)
            //{
            //    print("**" + t.name);
            //}
            foreach (Transform obj in finalList)
            {
                DamagesScript dScript = obj.GetComponent<DamagesScript>();

                if (dScript == null)
                {
                    Debug.LogError("null Damage script at" + Poles[i].name + "/" + obj.name);
                }

                int l = level;
                if (level == -1)
                    l = Random.Range(1, dScript.Damages.Length);

                //swap for damage equipment
                dScript.setDamage(l);
            }
        }
    }


    string[] chooseDamageForPole(string[] damageList, GameObject pole)
    {
        //get list object name in pole
        HashSet<string> uniqueNameList = new HashSet<string>();
        //collect name of all child and discard duplicated
        foreach (Transform child in pole.transform)
        {
            if (child.GetComponent<Data>() != null)
                uniqueNameList.Add(child.name);
            
            foreach (Transform grandChild in child)
                if (grandChild.GetComponent<Data>() != null)
                    uniqueNameList.Add(grandChild.name);
        }
        List<string> ret = new List<string>();

        //compare with list of damage equipment
        foreach (string t in uniqueNameList)
        {
            if (damageList.Contains(t))
            {
                ret.Add(t);
                continue;
            }
        }
        //shuffle list of name equipment and return maxmum 3 names
        ret.ShuffleList<string>();
        string[] retArray = ret.GetRange(0, (ret.Count < 3) ? ret.Count : 3).ToArray();

        for (int i =0; i< retArray.Length;i++)
        {
            retArray[i] = sanitizeName(retArray[i]);
            //print("name** " + retArray[i]);
        }
        return retArray;
    }
    GameObject[] getChildObjects(GameObject parent)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            temp.Add(child.gameObject);
        }

        return temp.ToArray();
    }
    Transform[] getEquipmentToReplace(GameObject pole)
    {
        List<Transform> ret = new List<Transform>();

        foreach(Transform c1 in pole.transform)
        {
            if (c1.GetComponent<Data>() != null)
                ret.Add(c1);
            foreach(Transform c2 in c1)
                if (c2.GetComponent<Data>() != null)
                    ret.Add(c2);
        }
        ret.ShuffleList();


        return ret.ToArray();
    }
    string sanitizeName(string name)
    {   
        if (name.Equals("HInsulator") || name.Equals("VInsulator") || name.Equals("LInsulator"))
            return "Insulator";
        else if (name.Equals("TransformerSingle") || name.Equals("TransformerDouble") || name.Equals("TransformerTriple"))
        {
            return "Transformer";
        }
        else
            return name;
    }


    ////get prefab of damage equipment for an available set
    //GameObject getDamagePrefab(GameObject damageSet, string equipment, int level)
    //{
    //    if (damageSet.transform.Find(equipment) == null)
    //    {
    //        Debug.LogError("Damage set doesn't have " + equipment);
    //        return null;
    //    }

    //    //if damage level is any
    //    GameObject ret;
    //    if (level == -1)
    //    {
    //        //replace level with a random level
    //        level = Random.Range(1, 4);

    //    }

    //    //if damage is a specific number
    //    string name = equipment + "/" + equipment + level;
    //    ret = GameObject.Find(name);
    //    return ret;
    //}

    
 //   // Use this for initialization
	//public void generateDamage()
 //   {
 //       //get damage equipment array
 //       string[] equipments = data.getDamageEquipmentArray();
 //       int level = data.getDamageLevel();

 //       //get all pole gameobject to an gameobject array
 //       GameObject[] poleArray = getChildObjects(poleListObj);

 //       //for each pole
 //       foreach (GameObject pole in poleArray)
 //       {
 //           //choose maximum 3 equipment name that exist in pole and damageList to replace
 //           string[] chosenEquipName = chooseDamageForPole(equipments, pole);
 //           print("Pole " + pole.name);
 //           string temp = "";
 //           foreach (string t in chosenEquipName)
 //           {
 //               temp += t + "-----";
 //           }
 //           print(temp);
 //           foreach (string equipment in chosenEquipName)
 //           {
 //               Debug.Log(equipment);
 //               //put damage to each equipment in damageList
 //               int tempLevel = level;
 //               //check if they want random level
 //               if (level == -1)
 //                   //generate a random number 
 //                   tempLevel = UnityEngine.Random.Range(1, 4);// 3 level of damage 1/2/3/

 //               GameObject oldEquipment = getEquipmentToReplace(pole, equipment);
 //               Debug.Log("\told " + oldEquipment);
 //               GameObject damagePrefab = getDamagePrefab(damageSet, oldEquipment.name, tempLevel);

 //               if (damagePrefab == null || oldEquipment == null)
 //               {
 //                   Debug.LogError("Can't find prefab damage for " + oldEquipment);
 //                   Debug.LogError(" Or Can't find equipment " + equipment);

 //                   return;
 //               }

 //               //record damage level and equipment to poledata
 //               Data oldData = oldEquipment.GetComponent<Data>();

 //               GameObject newObject = replaceObject(oldEquipment, damagePrefab);
 //               if (newObject.GetComponent<Data>() == null)
 //                   newObject.AddComponent<Data>();

 //               Data newData = newObject.GetComponent<Data>();

 //               newData.setData(oldData);
 //               newData.level = tempLevel;
 //           }

 //       }
 //       //at the end , deactive damageset
 //       damageSet.SetActive(false);
 //   }

    //find all children object in a gameobject
    //GameObject getEquipmentToReplace(GameObject pole, string name)
    //{
    //    //all gameobject is a single pole
    //    List<GameObject> equipmentList = new List<GameObject>();

    //    foreach (Transform child in pole.transform)
    //    {
    //        if (child.GetComponent<Data>() != null && child.name.Equals(name))
    //        {
    //            equipmentList.Add(child.gameObject);
    //        }

    //        //if(name == "FuseSwitch")
    //        foreach (Transform child2 in child)
    //        {
    //            if (child2.GetComponent<Data>() != null && child2.name.Equals(name))
    //            {
    //                equipmentList.Add(child2.gameObject);
    //            }
    //        }
    //    }
    //    if (equipmentList.Count == 0) { return null; }


    //    int randomIndex = Random.Range(0, equipmentList.Count);

    //    GameObject ret = equipmentList.ToArray()[randomIndex];

    //    return ret;
    //}


    //function check all insulator in a pole and return an insulator
    //GameObject getRandomInsulator(GameObject pole)
    //{

    //    List<GameObject> insulatorList = new List<GameObject>();
    //    for (int i = 0; i < pole.transform.childCount; i++)
    //    {
    //        GameObject temp = pole.transform.GetChild(i).gameObject;
    //        if (temp.name.Contains("Insulator"))
    //        {
    //            insulatorList.Add(temp);
    //        }
    //    }

    //    int index = Random.Range(0, insulatorList.Count);


    //    return insulatorList.ToArray()[index];

    //}

}
