using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//TODO: Need to make buttons act like radio buttons

public class ConditionAssessment : MonoBehaviour
{
    //This array holds all the "included" Form structs the user has filled out
    ArrayList FormList = new ArrayList();

    public string currentIconName;
	public GameObject parent;

    #region DropDown Options
    //Create a List of new Dropdown options
    public List<string> DropOptions_OH_SWITCH = new List<string> { "Disconnect Switch", "Overhead Switch Pothead" };
    public List<string> DropOptions_LIGHTNING_ARRESTER = new List<string> { "Ceramic", "Polymer", "Deadend" };
    public List<string> DropOptions_INSULATOR = new List<string> { "Ceramic", "Polymer" };
    public List<string> DropOptions_POLE = new List<string> { "Wooden", "Concrete" };
    public List<string> DropOptions_CROSSARM = new List<string> { "Wooden Single", "Wooden Double", "Concrete Single", "Concrete Double" };
    public List<string> DropOptions_VEGETATION = new List<string> { "Oak", "Palm" };
    public List<string> DropOptions_CONDUCTOR = new List<string> { "Power line", "Jumper", "Stirrup" };
    public List<string> DropOptions_OH_TRANSFORMER = new List<string> { "Single", "Double", "Triple" };
    public List<string> DropOptions_OH_FUSE_SWITCH = new List<string> { "Standard Cut Out", "ALS" };
    public List<string> DropOptions_FOREIGN_OBJECT_IN_WIRE = new List<string> { "Mylar Balloon", "Kite" };
    #endregion

    #region Condition Assessment Components
    public Dropdown EQUIPMENT_DROPDWN;
    public Text ICON_SELECTED_TXT;      
    public Text DEFAULT_TXT;

    public Text LD_TXT;
    public Button LD_1_BTN;             
    public Button LD_3_BTN;
    public Button LD_5_BTN;

    public Text PHASE_TXT;
    public Button PHASE_A_BTN;         
    public Button PHASE_B_BTN;
    public Button PHASE_C_BTN;
    
    public Button DISCARD_BTN;          
    public Button INCLUDE_BTN;
    #endregion

    //Form Struct: One individual Form
    public struct Form
    {
        public string iconName;
        public bool phaseA, phaseB, phaseC, DL1, DL3, DL5, selected;

        public Form(string iconName, bool phaseA, bool phaseB, bool phaseC, bool DL1, bool DL3, bool DL5, bool selected)
        {
            this.iconName = null;
            this.phaseA = false;
            this.phaseB = false;
            this.phaseC = false;
            this.DL1 = false;
            this.DL3 = false;
            this.DL5 = false;
            this.selected = false;
        }
    }

<<<<<<< HEAD
    void Start()
    {
        ICON_SELECTED_TXT = GameObject.Find("ICON_SELECTED_TXT").GetComponent<Text>();
        EQUIPMENT_DROPDWN = GameObject.Find("EQUIPMENT_DROPDWN").GetComponent<Dropdown>();

        DEFAULT_TXT = GameObject.Find("DEFAULT_TXT").GetComponent<Text>();

        PHASE_TXT = GameObject.Find("PHASE_TXT").GetComponent<Text>();
        PHASE_A_BTN = GameObject.Find("PHASE_A_BTN").GetComponent<Button>();
        PHASE_B_BTN = GameObject.Find("PHASE_B_BTN").GetComponent<Button>();
        PHASE_C_BTN = GameObject.Find("PHASE_C_BTN").GetComponent<Button>();

        LD_TXT = GameObject.Find("LD_TXT").GetComponent<Text>();
        LD_1_BTN = GameObject.Find("LD_1_BTN").GetComponent<Button>();
        LD_3_BTN = GameObject.Find("LD_3_BTN").GetComponent<Button>();
        LD_5_BTN = GameObject.Find("LD_5_BTN").GetComponent<Button>();

        INCLUDE_BTN = GameObject.Find("INCLUDE_BTN").GetComponent<Button>();
        DISCARD_BTN = GameObject.Find("DISCARD_BTN").GetComponent<Button>();

        //DEFAULT_TXT.gameObject.SetActive(true);
        ////ICON_SELECTED_TXT = gameObject.SetActive(false);
        ////EQUIPMENT_DROPDWN = gameObject.SetActive(false);

        //PHASE_TXT.gameObject.SetActive(false);
        //PHASE_A_BTN.gameObject.SetActive(false);
        //PHASE_B_BTN.gameObject.SetActive(false);
        //PHASE_C_BTN.gameObject.SetActive(false);

        //LD_TXT.gameObject.SetActive(false);
        //LD_1_BTN.gameObject.SetActive(false);
        //LD_3_BTN.gameObject.SetActive(false);
        //LD_5_BTN.gameObject.SetActive(false);

        //INCLUDE_BTN.gameObject.SetActive(false);
        //DISCARD_BTN.gameObject.SetActive(false);
    }
=======
	public void start(){
		//Get the parent object of the button (ie the CAF canvas)
		this.parent = this.transform.parent.gameObject;

		//Enable the DEFAULT_TXT by default
		parent.transform.Find("DEFAULT_TXT").GetComponent<Text>().enabled = true;

		//TODO: Make"ICON_SELECTED_TXT" invisible
		//TODO: Make Level of Damage buttons invisible
		//TODO: Make Phase buttons invisible
		//TODO: Make Discard and Include buttons invisible
	}
    
>>>>>>> e53f0bb29ed61d0dba8c2d87f621329e9a6865fb

    //Depending on the icon that was clicked, call the appropriate form generator
    public void icon_OnClick(string iconName)
    {
        EQUIPMENT_DROPDWN.ClearOptions();

        switch (iconName)
        {
            case "OH_SWITCH":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_OH_SWITCH);
                severityForm(iconName);
                break;

            case "LIGHTNING_ARRESTER":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_LIGHTNING_ARRESTER);
                severityForm(iconName);
                break;

            case "INSULATOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_INSULATOR);
                phaseSeverityForm(iconName);
                break;

            case "POLE":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_POLE);
                severityForm(iconName);
                break;

            case "CROSSARM":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_CROSSARM);
                severityForm(iconName);
                break;

            case "REGULATOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Regulator";
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "VEGETATION":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_VEGETATION);
                trueFalseForm(iconName);
                break;

            case "CONDUCTOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_CONDUCTOR);
                trueFalseForm(iconName);
                break;

            case "OH_TRANSFORMER":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_OH_TRANSFORMER);
                severityForm(iconName);
                break;

            case "OH_FUSE_SWITCH":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_OH_FUSE_SWITCH);
                severityForm(iconName);
                break;

            case "CAPACITOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Capacitor Bank";
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "RECLOSER":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Recloser OCR";
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "CONNECTIONS_ON_FEEDER_CONDUCTOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Splice";
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "NEST":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Nest";
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "DOWN_GUY":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Down Guy";
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "RISER_SHIELD":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Riser Shield";
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "FOREIGN_OBJECT_IN_WIRE":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_FOREIGN_OBJECT_IN_WIRE);
                trueFalseForm(iconName);
                break;

            case "FAULT_CURRENT_INDICATOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "FCI";
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            default:
                print("ERROR: Icon not recognized.");
                break;
        }
    }

    #region Form Options
    public void severityForm(string iconName)
    {
        print("severityForm method fired");
<<<<<<< HEAD
        DEFAULT_TXT.gameObject.SetActive(false);

        PHASE_TXT.gameObject.SetActive(false);
        PHASE_A_BTN.gameObject.SetActive(false);
        PHASE_B_BTN.gameObject.SetActive(false);
        PHASE_C_BTN.gameObject.SetActive(false);

        LD_TXT.gameObject.SetActive(true);
        LD_1_BTN.gameObject.SetActive(true);
        LD_3_BTN.gameObject.SetActive(true);
        LD_5_BTN.gameObject.SetActive(true);

        INCLUDE_BTN.gameObject.SetActive(true);
        DISCARD_BTN.gameObject.SetActive(true);
=======
        //TODO: Make "DEFAULT_TXT" invisible

		//set parent and then find Default_TXT and make is disappear.
		this.parent = this.transform.parent.gameObject;
		parent.transform.Find("DEFAULT_TXT").GetComponent<Text>().enabled = false;

        //TODO: Generate appropriate equipment name in "ICON_SELECTED_TXT"
        //TODO: Make Level of Damage buttons visible
        //TODO: Make Phase buttons invisible
        //TODO: Make Discard and Include buttons visible
>>>>>>> e53f0bb29ed61d0dba8c2d87f621329e9a6865fb
    }

    public void phaseSeverityForm(string iconName)
    {
        print("phaseSeverityForm method fired");
        DEFAULT_TXT.gameObject.SetActive(false);

<<<<<<< HEAD
        PHASE_TXT.gameObject.SetActive(true);
        PHASE_A_BTN.gameObject.SetActive(true);
        PHASE_B_BTN.gameObject.SetActive(true);
        PHASE_C_BTN.gameObject.SetActive(true);
=======
        //TODO: Make "DEFAULT_TXT" invisible
        //DEFAULT_TXT.SetActive(false);
		parent.transform.Find("DEFAULT_TXT").GetComponent<Text>().enabled = false;

        //TODO: Generate appropriate equipment name in "ICON_SELECTED_TXT"
        //ICON_SELECTED_TXT.Text = iconName;
>>>>>>> e53f0bb29ed61d0dba8c2d87f621329e9a6865fb

        LD_TXT.gameObject.SetActive(true);
        LD_1_BTN.gameObject.SetActive(true);
        LD_3_BTN.gameObject.SetActive(true);
        LD_5_BTN.gameObject.SetActive(true);

        INCLUDE_BTN.gameObject.SetActive(true);
        DISCARD_BTN.gameObject.SetActive(true);
    }

    public void trueFalseForm(string iconName)
    {
        print("trueFalseForm method fired");
        //TODO: Add True False buttons
        //TODO: Make "DEFAULT_TXT" invisible
        //TODO: Make Level of Damage buttons invisible
        //TODO: Make Phase buttons invisible
        //TODO: Make Discard and Include buttons visible
    }
    #endregion

    //Store user's form in formArray
    public void include_OnClick()
    {
        print("include_OnClick method fired");
        //Create a new Form struct
        Form form = new Form();

        //TODO: Fill out form struct
        //form.iconName = currentIconName;
        //if (currentIconName.selected)
        //    form.iconName = true;
        //if (PHASE_A_BTN.selected)
        //    form.phaseA = true;
        //if (PHASE_B_BTN.selected)
        //    form.phaseA = true;
        //if (PHASE_C_BTN.selected)
        //    form.phaseA = true;
        //if (DL_1_BTN.selected)
        //    form.DL1 = true;
        //if (DL_3_BTN.selected)
        //    form.DL3 = true;
        //if (DL_5_BTN.selected)
        //    form.DL5 = true;

        DEFAULT_TXT.gameObject.SetActive(true);
        //ICON_SELECTED_TXT = gameObject.SetActive(false);
        //EQUIPMENT_DROPDWN = gameObject.SetActive(false);

        PHASE_TXT.gameObject.SetActive(false);
        PHASE_A_BTN.gameObject.SetActive(false);
        PHASE_B_BTN.gameObject.SetActive(false);
        PHASE_C_BTN.gameObject.SetActive(false);

        LD_TXT.gameObject.SetActive(false);
        LD_1_BTN.gameObject.SetActive(false);
        LD_3_BTN.gameObject.SetActive(false);
        LD_5_BTN.gameObject.SetActive(false);

        INCLUDE_BTN.gameObject.SetActive(false);
        DISCARD_BTN.gameObject.SetActive(false);
    }

    //Clear user's answers for that specific form
    public void discard_OnClick()
    {
        print("discard_OnClick method fired");
        //Find appropriate struct in formArray
        //for (int i = 0; i < 20; i++)
        //{
        //    if (formArray[i].iconName == currentIconName)
        //    {
        //        //delete struct
        //        break;
        //    }
        //}

        //Remove Highlight From icon

        DEFAULT_TXT.gameObject.SetActive(true);
        //ICON_SELECTED_TXT = gameObject.SetActive(false);
        //EQUIPMENT_DROPDWN = gameObject.SetActive(false);

        PHASE_TXT.gameObject.SetActive(false);
        PHASE_A_BTN.gameObject.SetActive(false);
        PHASE_B_BTN.gameObject.SetActive(false);
        PHASE_C_BTN.gameObject.SetActive(false);

        LD_TXT.gameObject.SetActive(false);
        LD_1_BTN.gameObject.SetActive(false);
        LD_3_BTN.gameObject.SetActive(false);
        LD_5_BTN.gameObject.SetActive(false);

        INCLUDE_BTN.gameObject.SetActive(false);
        DISCARD_BTN.gameObject.SetActive(false);
    }

    //Check user's answers
    public void submit_OnClick()
    {
        print("submit_OnClick method fired");
    }

}