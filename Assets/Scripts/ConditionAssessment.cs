using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//TODO: Need to make buttons act like radio buttons

public class ConditionAssessment : MonoBehaviour
{
    //This array holds all the "included" Form structs the user has filled out
    ArrayList UserInputList = new ArrayList();

    public Image currentImage;
    public string currentIconName;

    #region DropDown Options
    //Create a List of new Dropdown options
    public List<string> DropOptions_OH_SWITCH = new List<string> { "Disconnect Switch", "Overhead Switch Pothead", "AFS" };
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

    public Image OH_SWITCH_IMG;
    public Image LIGHTNING_ARRESTER_IMG;
    public Image INSULATOR_IMG;
    public Image POLE_IMG;
    public Image CROSS_ARM_IMG;
    public Image VEGETATION_IMG;
    public Image CONDUCTOR_IMG;
    public Image OH_TRANSFORMER_IMG;
    public Image OH_FUSE_SWITCH_IMG;
    public Image CAPACITOR_IMG;
    public Image CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG;
    public Image NEST_IMG;
    public Image DOWN_GUY_IMG;
    public Image RISER_SHIELD_IMG;
    public Image FOREIGN_OBJECT_IN_WIRE_IMG;
    public Image REGULATOR_IMG;
    public Image RECLOSER_IMG;
    public Image FAULT_CURRENT_INDICATOR_IMG;

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

    void Start()
    {
        #region get all the components
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

        OH_SWITCH_IMG = GameObject.Find("OH_SWITCH_IMG").GetComponent<Image>();
        LIGHTNING_ARRESTER_IMG = GameObject.Find("LIGHTNING_ARRESTER_IMG").GetComponent<Image>();
        INSULATOR_IMG = GameObject.Find("INSULATOR_IMG").GetComponent<Image>();
        POLE_IMG = GameObject.Find("POLE_IMG").GetComponent<Image>();
        CROSS_ARM_IMG = GameObject.Find("CROSS_ARM_IMG").GetComponent<Image>();
        VEGETATION_IMG = GameObject.Find("VEGETATION_IMG").GetComponent<Image>();
        CONDUCTOR_IMG = GameObject.Find("CONDUCTOR_IMG").GetComponent<Image>();
        OH_TRANSFORMER_IMG = GameObject.Find("OH_TRANSFORMER_IMG").GetComponent<Image>();
        OH_FUSE_SWITCH_IMG = GameObject.Find("OH_FUSE_SWITCH_IMG").GetComponent<Image>();
        CAPACITOR_IMG = GameObject.Find("CAPACITOR_IMG").GetComponent<Image>();
        CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG = GameObject.Find("CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG").GetComponent<Image>();
        NEST_IMG = GameObject.Find("NEST_IMG").GetComponent<Image>();
        DOWN_GUY_IMG = GameObject.Find("DOWN_GUY_IMG").GetComponent<Image>();
        RISER_SHIELD_IMG = GameObject.Find("RISER_SHIELD_IMG").GetComponent<Image>();
        FOREIGN_OBJECT_IN_WIRE_IMG = GameObject.Find("FOREIGN_OBJECT_IN_WIRE_IMG").GetComponent<Image>();
        REGULATOR_IMG = GameObject.Find("REGULATOR_IMG").GetComponent<Image>();
        RECLOSER_IMG = GameObject.Find("RECLOSER_IMG").GetComponent<Image>();
        FAULT_CURRENT_INDICATOR_IMG = GameObject.Find("FAULT_CURRENT_INDICATOR_IMG").GetComponent<Image>();
        #endregion

        resetToStart();
    }

    //Highlights the icon image depending on the state
    public void highlight(Image image, string state)
    {
        if (state == "active")
        {
            if (image.color == Color.white)
            {
                image.color = Color.grey;
            }
        }
        if (state == "included")
        {
            image.color = Color.yellow;
        }
        if (state == "removed")
        {
            image.color = Color.white;
        }
        if (state == "correct")
        {
            image.color = Color.green;
        }
        if (state == "incorrect")
        {
            image.color = Color.red;
        }
    }

    //Depending on the icon that was clicked, call the appropriate form generator
    public void icon_OnClick(string iconName)
    {
        EQUIPMENT_DROPDWN.ClearOptions();
        hideDrop();
        if (currentImage != null)
        {
            if (currentImage.color == Color.grey)
                highlight(currentImage, "removed");
        }

        switch (iconName)
        {
            case "OH_SWITCH":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_OH_SWITCH);
                showDrop();
                severityForm(iconName);
                currentImage = OH_SWITCH_IMG;
                highlight(currentImage, "active");
                break;

            case "LIGHTNING_ARRESTER":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_LIGHTNING_ARRESTER);
                showDrop();
                severityForm(iconName);
                currentImage = LIGHTNING_ARRESTER_IMG;
                highlight(currentImage, "active");
                break;

            case "INSULATOR":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_INSULATOR);
                showDrop();
                phaseSeverityForm(iconName);
                currentImage = INSULATOR_IMG;
                highlight(currentImage, "active");
                break;

            case "POLE":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_POLE);
                showDrop();
                severityForm(iconName);
                currentImage = POLE_IMG;
                highlight(currentImage, "active");
                break;

            case "CROSSARM":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_CROSSARM);
                showDrop();
                severityForm(iconName);
                currentImage = CROSS_ARM_IMG;
                highlight(currentImage, "active");
                break;

            case "REGULATOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Regulator";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = REGULATOR_IMG;
                highlight(currentImage, "active");
                break;

            case "VEGETATION":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_VEGETATION);
                showDrop();
                severityForm(iconName);
                currentImage = VEGETATION_IMG;
                highlight(currentImage, "active");
                break;

            case "CONDUCTOR":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_CONDUCTOR);
                showDrop();
                severityForm(iconName);
                currentImage = CONDUCTOR_IMG;
                highlight(currentImage, "active");
                break;

            case "OH_TRANSFORMER":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_OH_TRANSFORMER);
                showDrop();
                severityForm(iconName);
                currentImage = OH_TRANSFORMER_IMG;
                highlight(currentImage, "active");
                break;

            case "OH_FUSE_SWITCH":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_OH_FUSE_SWITCH);
                showDrop();
                severityForm(iconName);
                currentImage = OH_FUSE_SWITCH_IMG;
                highlight(currentImage, "active");
                break;

            case "CAPACITOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Capacitor Bank";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = CAPACITOR_IMG;
                highlight(currentImage, "active"); break;

            case "RECLOSER":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Recloser OCR";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = RECLOSER_IMG;
                highlight(currentImage, "active");
                break;

            case "CONNECTIONS_ON_FEEDER_CONDUCTOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Splice";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG;
                highlight(currentImage, "active");
                break;

            case "NEST":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Nest";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = NEST_IMG;
                highlight(currentImage, "active");
                break;

            case "DOWN_GUY":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Down Guy";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = DOWN_GUY_IMG;
                highlight(currentImage, "active");
                break;

            case "RISER_SHIELD":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Riser Shield";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = RISER_SHIELD_IMG;
                highlight(currentImage, "active");
                break;

            case "FOREIGN_OBJECT_IN_WIRE":
                currentIconName = iconName;
                EQUIPMENT_DROPDWN.AddOptions(DropOptions_FOREIGN_OBJECT_IN_WIRE);
                showDrop();
                severityForm(iconName);
                highlight(FOREIGN_OBJECT_IN_WIRE_IMG, "active");
                currentImage = FOREIGN_OBJECT_IN_WIRE_IMG;
                highlight(currentImage, "active");
                break;

            case "FAULT_CURRENT_INDICATOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "FCI";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = FAULT_CURRENT_INDICATOR_IMG;
                highlight(currentImage, "active");
                break;

            default:
                print("ERROR: Icon not recognized.");
                break;
        }
    }

    #region Form Options
    public void severityForm(string iconName)
    {
        hideDefaultText();

        hidePhase();

        showSeverity();

        showIncludeDiscard();
    }

    public void phaseSeverityForm(string iconName)
    {
        hideDefaultText();

        showPhase();

        showSeverity();

        showIncludeDiscard();
    }

    #endregion

    //Store user's form in formArray
    public void include_OnClick()
    {
        print("include_OnClick method fired");
        
        //Create a new Form struct
        Form form = new Form();

        //Highlight the equipment icon yellow
        highlight(currentImage, "included");

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

        //TODO: Add the struct to the user's answers array

        resetToStart();
    }

    //Clear user's answers for that specific form
    public void discard_OnClick()
    {
        print("discard_OnClick method fired");

        //Find appropriate struct in formArray and delete it

        //Remove yellow Highlight From icon
        highlight(currentImage, "removed");


        resetToStart();

    }

    //If the form for the selected icon has already been filled out, populate the form
    public void fillForm()
    {

    }

    #region hide/show buttons
    public void hideSeverity() {
        LD_TXT.gameObject.SetActive(false);
        LD_1_BTN.gameObject.SetActive(false);
        LD_3_BTN.gameObject.SetActive(false);
        LD_5_BTN.gameObject.SetActive(false);
    }
    public void showSeverity() {
        LD_TXT.gameObject.SetActive(true);
        LD_1_BTN.gameObject.SetActive(true);
        LD_3_BTN.gameObject.SetActive(true);
        LD_5_BTN.gameObject.SetActive(true);
    }

    public void hidePhase() {
        PHASE_TXT.gameObject.SetActive(false);
        PHASE_A_BTN.gameObject.SetActive(false);
        PHASE_B_BTN.gameObject.SetActive(false);
        PHASE_C_BTN.gameObject.SetActive(false);
    }
    public void showPhase() {
        PHASE_TXT.gameObject.SetActive(true);
        PHASE_A_BTN.gameObject.SetActive(true);
        PHASE_B_BTN.gameObject.SetActive(true);
        PHASE_C_BTN.gameObject.SetActive(true);
    }

    public void hideDrop() {
        EQUIPMENT_DROPDWN.gameObject.SetActive(false);
    }
    public void showDrop() {
        EQUIPMENT_DROPDWN.gameObject.SetActive(true);
    }

    public void hideIncludeDiscard() {
        INCLUDE_BTN.gameObject.SetActive(false);
        DISCARD_BTN.gameObject.SetActive(false);
    }
    public void showIncludeDiscard() {
        INCLUDE_BTN.gameObject.SetActive(true);
        DISCARD_BTN.gameObject.SetActive(true);
    }

    public void hideDefaultText() {
        DEFAULT_TXT.gameObject.SetActive(false);
    }
    public void showDefaultText() {
        DEFAULT_TXT.gameObject.SetActive(true);
    }

    public void showIconSelectedText()
    {
        ICON_SELECTED_TXT.gameObject.SetActive(true);
    }
    public void hideIconSelectedText()
    {
        ICON_SELECTED_TXT.gameObject.SetActive(false);
    }

    public void resetToStart()
    {
        hideSeverity();
        hidePhase();
        hideDrop();
        hideIncludeDiscard();
        showDefaultText();
        hideIconSelectedText();
    }
    #endregion

    //Check user's answers
    public void submit_OnClick()
    {
        print("submit_OnClick method fired");
        resetToStart();
        hideDefaultText();

        //print the solution on the form
    }

}