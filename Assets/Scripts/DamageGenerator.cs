using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;


public class DamageGenerator : MonoBehaviour
{
    public GameObject damageSet;
    //public string[] temp;
    [SerializeField] private GameObject poleListObj;
    [SerializeField] private SceneData data;

    void Start()
    {
        damageSet.SetActive(true);
        generateDamage();
        damageSet.SetActive(false);
    }

    public void generateDamage(){
		
        //get damage equipment 
		string[] dEquip = data.getDamageEquipmentArray();
        int level = data.getDamageLevel();

        GameObject[] Poles = UtilityFunctions.getChildObjects(poleListObj);

        for(int i=0; i< Poles.Length; i++)
        {
            //Debug.Log(Poles[i].name);
            if (i == Poles.Length / 2) continue; //skip corner pole for now
            //get a damages name that random choose
            string[] childrenNames = chooseDamageForPole(dEquip, Poles[i]);
            //foreach(string ch in childrenNames)
            //{
            //    print("---children name = " + ch);
            //}
            
            //get equipment gameobject
            Transform[] properEquips = getEquipmentToReplace(Poles[i]);
            List<Transform> finalList = new List<Transform>();
            List<string> taken = new List<string>();
            int count = 0;
            foreach(Transform obj in properEquips)
            {
                if (count > childrenNames.Length)
                    break;

                string objName = obj.GetComponent<Data>().equipmentName.Replace(" ", string.Empty);
                //print("\ttobjName= " + objName);
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
            //    print("final**" + t.name);
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
                    l = Random.Range(1, dScript.Damages.Length+1);

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
            print("name** " + retArray[i]);
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
        else if(name.Equals("OHFuseSwitchALS") || name.Equals("OHFuseSwitch"))
        {
            return "OHFuse";
        }
        else
            return name;
    }
}
