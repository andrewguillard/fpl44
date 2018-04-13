using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneData : MonoBehaviour {
    public static string framing;
    public static int damageLevel = -1;
    GameObject[] poles;

    //for debug
    public string[] testingData;

    //data generate from user selection;
    private static List<string> equipments = new List<string>();
    private static List<string> damages = new List<string>();

    //constant list
    readonly string[] OHSWITCH = { "Disconnect Switch", "OH Pothead Switch " };
    readonly string[] LA = {"Lightning Arrester Polymer", "Lightning Arrester Ceramic"};
    readonly string[] INSULATOR = {"HInsulator", "VInsulator", "LInsulator"};
    readonly string[] POLE = {"Wooden Pole", "Concrete Pole"};
    readonly string[] CROSSARM = {"Wooden Pole Single Cross Arm", "Concrete Pole Single Cross Arm", "Wooden Pole Double Cross Arm", "Concrete Pole Double Cross Arm"};
    readonly string[] VEGETATION = {"Palm Tree", "Oak Tree"};
    readonly string[] CONDUCTOR ={"Power line", "Jumper", "Stirrup"};
    readonly string[] OHTRANSFORMER = {"Transformer Single","Transformer Double","Transformer Triple"};
    readonly string[] OHFUSE = { "OH Fuse Switch ALS" }; // "OH Fuse Switch",
    readonly string[] CAPACITOR = {"Capacitor Bank"};
    readonly string[] RECLOSER = {"Recloser" };
    readonly string[] CONNECTIONS = { "Splice"};
    readonly string[] NEST = { "Nest"};
    readonly string[] DOWNGUY= {"Down Guy" };
    readonly string[] RISERSHIELD = { "Riser Shield"};
    readonly string[] OBJECT=  { "Kite" ,"Ballon"};
    readonly string[] AFS = {"Automatic Feeder Switch" };
    readonly string[] FCI = { "Fault Current Indicator" };
    readonly string[] FIELDREGULATOR = { "Regulator"};

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
            case "OHSwitch":
                //add equipment to equipment list 
                equipments.Add("OHPotheadSwitch");
                //add equipment to generate damage
                addToList(OHSWITCH, damages);

                break;
            case "Insulator":
                //not add anything for equipment
                addToList(INSULATOR, damages);
                break;

            case "Pole":
                addToList(POLE, damages);
                //not add anything for equipment

                break;
            case "LightningArrester":
                break;
            case "CrossArm":
                //set framming is crossarm
                setFraming("C");
                break;
            case "Vegetation":
                break;
            case "Conductor":
                break;
            case "OHTransformer":
                addToList(OHTRANSFORMER, equipments);
                damages.Add("Transformer");
                break;
            case "OHFuse":
                //not add fuse switch to damage , add OH-FSand ALS
                addToList(OHFUSE, equipments);
                //add all to damage
                addToList(new string[] { "FuseSwitch", "ALS"}, damages);

                break;
            case "Capacitor":
                addToList(CAPACITOR, equipments,damages);
                break;
            case "Connections":
                break;
            case "Nest":
                break;
            case "DownGuy":
                addToList(DOWNGUY, equipments);
                break;
            case "RiserShield":
                break;
            case "ForeignObject":
                break;
            case "AFS":
                break;
            case "FCI":
                break;
            case "FeildRegulator":
                break;
            case "Recloser":
                addToList(RECLOSER, equipments);
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


    public void clearEquip()
    {
        if(damages != null )
            damages.Clear();
        if (equipments != null)
            equipments.Clear();
    }

    private void submitSelection()
    {
        //go through all button and add equipment

    }

	public void setDamageLevel(int i){
        damageLevel = i;
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
}
