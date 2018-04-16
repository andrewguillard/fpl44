using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneData : MonoBehaviour {
    public static string framing;
    public static int damageLevel = -1;
    //data generate from user selection;
    private static List<string> equipments = new List<string>();
    private static List<string> damages = new List<string>();

    GameObject[] poles;
    public SelMenuManager subMenuManager;
    public string[] testingData;

    //constant list
    readonly string[] OHSWITCH = {"OH Pothead Switch " };
    readonly string[] LA = {"Lightning Arrester Polymer", "Lightning Arrester Ceramic"}; 
    readonly string[] INSULATOR = {"HInsulator", "VInsulator", "LInsulator"};
    readonly string[] POLE = {"Wooden Pole", "Concrete Pole"};
    readonly string[] CROSSARM = { "Wooden Single", "Wooden Double", "Concrete Single" };
    readonly string[] VEGETATION = {"Palm Tree", "Oak Tree"}; 
    readonly string[] OHTRANSFORMER = {"Transformer Single","Transformer Double","Transformer Triple"};
    readonly string[] OHFUSE = { "OH Fuse Switch ALS", "OH Fuse Switch" };  
    readonly string[] CAPACITOR = {"Capacitor Bank"};
    readonly string[] RECLOSER = {"Recloser" }; 
    readonly string[] CONNECTIONS = { "Splice"};
    readonly string[] NEST = { "Nest"};
    readonly string[] DOWNGUY= {"Down Guy" };
    readonly string[] OBJECT=  { "Kite" ,"Ballon"}; 
    readonly string[] AFS = {"Automatic Feeder Switch" }; 
    readonly string[] FCI = { "FCI" }; 

    //getter functions
    public string getFraming(){return framing;}
	public string[] getDamageEquipmentArray(){
        if(damages == null || damages.Count == 0)
        {
            //this only for development 
            damages = new List<string>();
            foreach(string data in testingData)
            {
                string t = data.Replace(" ", string.Empty);
                this.addDamageEquipment(t);
            }
        }

        return damages.ToArray();
    }

    public string[] getEquipmentArray()
    {
        return equipments.ToArray();
    }

	public int getDamageLevel(){ return damageLevel;}
    public GameObject[] getPoles() { return poles; }
    public Transform[] getPolesTransform()
    {
        Transform[] ret = new Transform[poles.Length];
        for(int i = 0; i < poles.Length; i++)
        {
            ret[i] = poles[i].transform;
        }
        return ret;
    }
    
    
    //setfunctions
    public void setFraming(string f) {
        if (f == "any")
        {
            framing = null;
        }
        else
        {
            print("set framing" + f);
            framing = f;
        }
    }

    public void setPoles(GameObject[] p) {
        poles = p;
    }

	public void addDamageEquipment(string t){
        switch (t)
        {
            
            case "Insulator":
                //not add anything for equipment
                addToList(INSULATOR, damages);
                break;

            case "Pole":
                //not add anything for equipment , only for damages
                addToList(POLE, damages);

                break;
            case "LightningArrester":
                equipments.Add("LightningArrester");
                damages.Add("LightningArrester");
                break;
            case "ForeignObject":
                equipments.Add("ObjectsOnWire");
                damages.Add("ObjectsOnWire");
                break;
            case "Nest":
                addToList(NEST, equipments, damages);
                break;
            case "Recloser":
                addToList(RECLOSER, equipments,damages);
                break;
            case "Vegetation":
                addToList(new String[] { "Vegetation" }, equipments, damages);
                break;
            case "OHTransformer":
                addToList(OHTRANSFORMER, equipments,damages);
                break;
            case "Capacitor":
                addToList(CAPACITOR, equipments,damages);
                break;
            case "DownGuy":
                addToList(DOWNGUY, equipments,damages);
                break;
            case "Connections":
                addToList(CONNECTIONS, equipments,damages);
                break;
            case "CrossArm":
                //set framming is crossarm
                setFraming("C");
                addToList(CROSSARM, damages);
                break;
            case "OHSwitch":
                equipments.Add("OHPotheadSwitch");
                addToList(OHSWITCH, damages);
                break;
            case "AFS":
                addToList(new string[] { "AFS" }, equipments, damages);
                break;
            case "FCI":
                addToList(new string[] { "FCI" }, equipments, damages);
                break;
            case "OHFuse":
                addToList(OHFUSE, equipments);
                damages.Add("OH Fuse Switch");
                break;
            default:
                Debug.LogError("Not a selection of equipment" + t);
                break;
        }
    }

    private void addToList(string[] fromArray, List<string> toList)
    {
        if (toList == null)
            toList = new List<string>();

        foreach(string str in fromArray)
        {
            string s = str.Replace(" ", string.Empty);
            toList.Add(s);
        }
    }
    private void addToList(string[] fromArray, List<string> toList, List<String> to2List)
    {
        addToList(fromArray, toList);
        addToList(fromArray, to2List);
    }


	public void setDamageLevel(int i){
        damageLevel = i;
	}
    public void RandomizeTrainingload(string name)
    {
        string[] listofselection = { "OHSwitch", "AFS", "Insulator", "Pole", "Vegetation", "OHTransformer", "Capacitor", "Connections", "Recloser", "Nest", "DownGuy" };

        bool[] visited = new bool[listofselection.Length];
        for (int i = 0; i < 5; i++)
        {
            int ran = UnityEngine.Random.Range(0, listofselection.Length);
            while (visited[ran])
            {
                ran = UnityEngine.Random.Range(0, listofselection.Length);

            }
            visited[ran] = true;
            addDamageEquipment(listofselection[ran]);
            print(listofselection[ran]);
        }

        setDamageLevel(-1);

        SceneManager.LoadScene(name);
    }
    public void loadScene(string sceneName)
    {
        print("button click and  load scene " + sceneName);
        SceneManager.LoadScene(sceneName);
        //SteamVR_LoadLevel.Begin(sceneName);
        //testing
        print("load scene");
        print("framming = "+getFraming() + "\t\t level = "+getDamageLevel());
        string ret = "";
        foreach(string t in getDamageEquipmentArray())
        {
            ret += t + "--";
        }
        print(ret);
    }

    //platform specific compilation: code will run differently depending on if it's being run on Unity or not
    public void quit()
    {
        //if we are running on the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        //if we are not running in the editor (like the build)
        #else
        Application.Quit();
        
        #endif
    }

    

    public void clearData()
    {
        framing = null;
        damages = null;
        equipments = null;
        damageLevel = -1;
    }

    public void SelectiveLoad()
    {
        //get data
        string[] temp = subMenuManager.getSelectionArray();
        foreach(string t in temp)
        {
            addDamageEquipment(t);
        }

        SceneManager.LoadScene("SelectiveTraining");
    }


}
