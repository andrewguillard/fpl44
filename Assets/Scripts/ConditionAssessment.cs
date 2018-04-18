using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConditionAssessment : MonoBehaviour
{
    //Set default points to 5
    //If the user gets anything wrong, set points to 0
    public int points4quiz = 5;

    //This array holds all the "included" Form structs the user has filled out
    ArrayList UserInputList = new ArrayList();

    //This is an array for test purposes that is the answer key
    ArrayList AnswerKeyTest = new ArrayList();

    public GameObject pole;
    public Data[] poleData;
    public bool LD1;
    public bool LD3;
    public bool LD5;

    public bool PHA;
    public bool PHB;
    public bool PHC;

    public bool found;

    public Image currentImage;
    public static string currentIconName;
    public static string currentEquipmentName;
    public bool HasBeenSubmitted = false;

    #region DropDown Options
    //Create a List of new Dropdown options
    public List<string> DropOptions_OH_SWITCH = new List<string> { "-----------------------------", "Disconnect Switch", "Overhead Switch Pothead", "AFS" };
    public List<string> DropOptions_LIGHTNING_ARRESTER = new List<string> { "-----------------------------", "Ceramic LA", "Polymer LA" };
    public List<string> DropOptions_INSULATOR = new List<string> { "-----------------------------", "Ceramic Insulator", "Polymer Insulator", "Deadend Insulator" };
    public List<string> DropOptions_POLE = new List<string> { "-----------------------------", "Wooden Pole", "Concrete Pole" };
    public List<string> DropOptions_CROSSARM = new List<string> { "-----------------------------", "Wooden Single", "Wooden Double", "Concrete Single", "Concrete Double" };
    public List<string> DropOptions_VEGETATION = new List<string> { "-----------------------------", "Oak", "Palm" };
    public List<string> DropOptions_CONDUCTOR = new List<string> { "-----------------------------", "Power line", "Jumper", "Stirrup" };
    public List<string> DropOptions_OH_TRANSFORMER = new List<string> { "-----------------------------", "Single Transformer", "Double Transformer", "Triple Transformer" };
    public List<string> DropOptions_OH_FUSE_SWITCH = new List<string> { "-----------------------------", "Fuse Switch", "ALS" };
    public List<string> DropOptions_FOREIGN_OBJECT_IN_WIRE = new List<string> { "-----------------------------", "Balloon", "Kite" };
    #endregion

    #region Condition Assessment Components
    public Dropdown EQUIPMENT_DROPDWN;
    public Text ICON_SELECTED_TXT;
    public Text DEFAULT_TXT;

    public Text LD_TXT;
    public Button LD_1_BTN;
    public Image LD_1_IMG;
    public Button LD_3_BTN;
    public Image LD_3_IMG;
    public Button LD_5_BTN;
    public Image LD_5_IMG;

    public Text PHASE_TXT;
    public Button PHASE_A_BTN;
    public Image PHASE_A_IMG;
    public Button PHASE_B_BTN;
    public Image PHASE_B_IMG;
    public Button PHASE_C_BTN;
    public Image PHASE_C_IMG;

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
        public bool phaseA;
        public bool phaseB;
        public bool phaseC;
        public bool DL1;
        public bool DL3;
        public bool DL5;
    }

    //Create a new Form struct
    Form form = new Form();
    public bool gotdata = false;
    void Start()
    {
        #region get all the components
        ICON_SELECTED_TXT = gameObject.transform.Find("ICON_SELECTED_TXT").GetComponent<Text>();
        EQUIPMENT_DROPDWN = gameObject.transform.Find("EQUIPMENT_DROPDWN").GetComponent<Dropdown>();
        EQUIPMENT_DROPDWN.onValueChanged.AddListener(delegate { myDropdownValueChangedHandler(EQUIPMENT_DROPDWN); });

        DEFAULT_TXT = gameObject.transform.Find("DEFAULT_TXT").GetComponent<Text>();

        PHASE_TXT = gameObject.transform.Find("PHASE_TXT").GetComponent<Text>();
        PHASE_A_BTN = gameObject.transform.Find("PHASE_A_BTN").GetComponent<Button>();
        PHASE_A_IMG = gameObject.transform.Find("PHASE_A_BTN/PHASE_A_IMG").GetComponent<Image>();
        PHASE_B_BTN = gameObject.transform.Find("PHASE_B_BTN").GetComponent<Button>();
        PHASE_B_IMG = gameObject.transform.Find("PHASE_B_BTN/PHASE_B_IMG").GetComponent<Image>();
        PHASE_C_BTN = gameObject.transform.Find("PHASE_C_BTN").GetComponent<Button>();
        PHASE_C_IMG = gameObject.transform.Find("PHASE_C_BTN/PHASE_C_IMG").GetComponent<Image>();

        LD_TXT = gameObject.transform.Find("LD_TXT").GetComponent<Text>();
        LD_1_BTN = gameObject.transform.Find("LD_1_BTN").GetComponent<Button>();
        LD_1_IMG = gameObject.transform.Find("LD_1_BTN/LD_1_IMG").GetComponent<Image>();
        LD_3_BTN = gameObject.transform.Find("LD_3_BTN").GetComponent<Button>();
        LD_3_IMG = gameObject.transform.Find("LD_3_BTN/LD_3_IMG").GetComponent<Image>();
        LD_5_BTN = gameObject.transform.Find("LD_5_BTN").GetComponent<Button>();
        LD_5_IMG = gameObject.transform.Find("LD_5_BTN/LD_5_IMG").GetComponent<Image>();


        INCLUDE_BTN = gameObject.transform.Find("INCLUDE_BTN").GetComponent<Button>();
        DISCARD_BTN = gameObject.transform.Find("DISCARD_BTN").GetComponent<Button>();

        OH_SWITCH_IMG = gameObject.transform.Find("OH_SWITCH_BTN/OH_SWITCH_IMG").GetComponent<Image>();
        LIGHTNING_ARRESTER_IMG = gameObject.transform.Find("LIGHTNING_ARRESTER_BTN/LIGHTNING_ARRESTER_IMG").GetComponent<Image>();
        INSULATOR_IMG = gameObject.transform.Find("INSULATOR_BTN/INSULATOR_IMG").GetComponent<Image>();
        POLE_IMG = gameObject.transform.Find("POLE_BTN/POLE_IMG").GetComponent<Image>();
        CROSS_ARM_IMG = gameObject.transform.Find("CROSS_ARM_BTN/CROSS_ARM_IMG").GetComponent<Image>();
        VEGETATION_IMG = gameObject.transform.Find("VEGETATION_BTN/VEGETATION_IMG").GetComponent<Image>();
        CONDUCTOR_IMG = gameObject.transform.Find("CONDUCTOR_BTN/CONDUCTOR_IMG").GetComponent<Image>();
        OH_TRANSFORMER_IMG = gameObject.transform.Find("OH_TRANSFORMER_BTN/OH_TRANSFORMER_IMG").GetComponent<Image>();
        OH_FUSE_SWITCH_IMG = gameObject.transform.Find("OH_FUSE_SWITCH_BTN/OH_FUSE_SWITCH_IMG").GetComponent<Image>();
        CAPACITOR_IMG = gameObject.transform.Find("CAPACITOR_BTN/CAPACITOR_IMG").GetComponent<Image>();
        CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG = gameObject.transform.Find("CONNECTIONS_ON_FEEDER_CONDUCTOR_BTN/CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG").GetComponent<Image>();
        NEST_IMG = gameObject.transform.Find("NEST_BTN/NEST_IMG").GetComponent<Image>();
        DOWN_GUY_IMG = gameObject.transform.Find("DOWN_GUY_BTN/DOWN_GUY_IMG").GetComponent<Image>();
        RISER_SHIELD_IMG = gameObject.transform.Find("RISER_SHIELD_BTN/RISER_SHIELD_IMG").GetComponent<Image>();
        FOREIGN_OBJECT_IN_WIRE_IMG = gameObject.transform.Find("FOREIGN_OBJECT_IN_WIRE_BTN/FOREIGN_OBJECT_IN_WIRE_IMG").GetComponent<Image>();
        REGULATOR_IMG = gameObject.transform.Find("REGULATOR_BTN/REGULATOR_IMG").GetComponent<Image>();
        RECLOSER_IMG = gameObject.transform.Find("RECLOSER_BTN/RECLOSER_IMG").GetComponent<Image>();
        FAULT_CURRENT_INDICATOR_IMG = gameObject.transform.Find("FAULT_CURRENT_INDICATOR_BTN/FAULT_CURRENT_INDICATOR_IMG").GetComponent<Image>();
        #endregion
        resetToStart();

    }


    void Update()
    {
        if(gotdata && pole !=null)
        {
            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;
            print("SCENE: " + sceneName);

            if (sceneName == "SelectiveTraining" && pole != null)
                AnswerKeyTest = getDataFromSelectiveScence(pole);
            if (sceneName == "RandomizedTraining" || sceneName == "Quiz")
                AnswerKeyTest = getDataFromSelectiveScence(pole);

            gotdata = true;
        }
    }

    //Get Answer Array from Selective Training Scene
    public ArrayList getDataFromSelectiveScence(GameObject currentPole)
    {
        //List<Form> ret = new List<Form>();
        ArrayList ret = new ArrayList();
        Data[] pData = currentPole.GetComponent<PoleData>().getData();
        poleData = pData;
        //for each
        foreach (Data d in pData)
        {
            Form tempForm = new Form();

            switch (d.equipmentName)
            {

                #region NOT IMPLEMENTED
                //case "OH Pothead Switch":   //NOT IMPLEMENTED
                //    d.equipmentName = "Disconnect Switch";
                //    break;

                //case "LightningArrester":   //NOT IMPLEMENTED 
                //    d.equipmentName = "Polymer LA";
                //    break;

                //case "Polymer Insulator":     //NOT IMPLEMENTED
                //    d.equipmentName = "Polymer Insulator";
                //    break;

                //case "Deadend":           //NOT IMPLEMENTED
                //    d.equipmentName = "Deadend Insulator";
                //    break;

                //case "Vegetation":      //NOT IMPLEMENTED
                //    d.equipmentName = "Oak";
                //    break;
                #endregion


                case "OH Pothead Switch":   //WORKS
                    d.equipmentName = "Overhead Switch Pothead";
                    break;

                case "AFS": //UPDATE 
                    d.equipmentName = "AFS";
                    break;

                case "LightningArrester":   //UPDATE 
                    d.equipmentName = "Ceramic LA";
                    break;

                case "Insulator":   //WORKS
                    d.equipmentName = "Ceramic Insulator";
                    break;

                case "ConcretePole": //Works
                    d.equipmentName = "Concrete Pole";
                    break;

                case "WoodenPole":    //Works
                    d.equipmentName = "Wooden Pole";
                    break;

                case "Wooden Single":   //Works
                    d.equipmentName = "Wooden Single";
                    break;

                case "Wooden Double":   //Works
                    d.equipmentName = "Wooden Double";
                    break;

                case "Concrete Single":   //Works
                    d.equipmentName = "Concrete Single";
                    break;

                case "Concrete Double":   //Works
                    d.equipmentName = "Concrete Double";
                    break;

                case "Vegetation":   //Works
                    d.equipmentName = "Palm";
                    break;

                case "Transformer":   //UPDATE - test with OH Transformer
                    if (d.subName == "Transformer Single")
                        d.equipmentName = "Single Transformer";
                    else if (d.subName == "Transformer Double")
                        d.equipmentName = "Double Transformer";
                    else if (d.subName == "Transformer Triple")
                        d.equipmentName = "Triple Transformer";
                    break;

                case "FuseSwitch":  //UPDATE
                    d.equipmentName = "Fuse Switch";
                    break;

                case "OH Fuse Switch ALS":  //UPDATE- test with OH Fuse
                    d.equipmentName = "ALS";
                    break;

                case "ObjectsOnWire":   //UPDATE
                    //if (d.subName == "Kite")
                        d.equipmentName = "Kite";
                    //else if (d.subName == "Balloon")
                    //    d.equipmentName = "Balloon";
                    break;

                case "CapacitorBank":   //Works
                    d.equipmentName = "CAPACITOR";
                    break;

                case "Recloser":    //Works
                    d.equipmentName = "RECLOSER";
                    break;

                case "Splice":  //Works
                    d.equipmentName = "CONNECTIONS_ON_FEEDER_CONDUCTOR";
                    break;

                case "Nest":    //Works
                    d.equipmentName = "NEST";
                    break;

                case "DownGuy":    //UPDATE
                    d.equipmentName = "DOWN_GUY";
                    break;

                case "FCI":        //UPDATE
                    d.equipmentName = "FAULT_CURRENT_INDICATOR";
                    break;

                default:
                    print("Cuong to CAF Conversion incorrect");
                    break;
            }

            //get name
            tempForm.iconName = d.equipmentName;

            //getPhase
            if (d.phase == 'A')
            {
                tempForm.phaseA = true;
            }

            if (d.phase == 'B')
            {
                tempForm.phaseB = true;
            }

            if (d.phase == 'C')
            {
                tempForm.phaseC = true;
            }

            //getLevel
            if (d.level == 1)
            {
                tempForm.DL1 = true;
            }

            else if (d.level == 2)
            {
                tempForm.DL3 = true;
            }

            else if (d.level == 3)
            {
                tempForm.DL5 = true;
            }

            //if the equipment is not an Insulator, then set all phases to false
            if (d.equipmentName != "Insulator" && d.equipmentName != "Insulator Polymer" && d.equipmentName != "Insulator Ceramic")
            {
                tempForm.phaseA = false;
                tempForm.phaseB = false;
                tempForm.phaseC = false;
            }

            ret.Add(tempForm);
        }

        if (ret.Count == 0)
            return null;
        else
            return ret;
    }

    //Get Answer Array from Randomization Scene

    //Get the option the user selected in the dropdown and highlight (or don't hightlight) accordingly
    private void myDropdownValueChangedHandler(Dropdown target)
    {
        Image IMAGE = OH_SWITCH_IMG;
        currentEquipmentName = EQUIPMENT_DROPDWN.options[EQUIPMENT_DROPDWN.value].text;
        int flag = 0;
        //for each form in the answerkey, check to see if we have clicked an icon that was in the answer list
        foreach (Form la in AnswerKeyTest)
        {
            if (la.iconName == currentEquipmentName && HasBeenSubmitted)
            {
                print("got into has been submitted");
                print("currentIconName: " + currentIconName);
                if (currentIconName == "OH_SWITCH")
                    IMAGE = OH_SWITCH_IMG;
                if (currentIconName == "LIGHTNING_ARRESTER")
                    IMAGE = LIGHTNING_ARRESTER_IMG;
                if (currentIconName == "INSULATOR")
                    IMAGE = INSULATOR_IMG;
                if (currentIconName == "POLE")
                    IMAGE = POLE_IMG;
                if (currentIconName == "CROSS_ARM")
                    IMAGE = CROSS_ARM_IMG;
                if (currentIconName == "VEGETATION")
                    IMAGE = VEGETATION_IMG;
                if (currentIconName == "CONDUCTOR")
                    IMAGE = CONDUCTOR_IMG;
                if (currentIconName == "OH_TRANSFORMER")
                    IMAGE = OH_TRANSFORMER_IMG;
                if (currentIconName == "OH_FUSE_SWITCH")
                    IMAGE = OH_FUSE_SWITCH_IMG;
                if (currentIconName == "FOREIGN_OBJECT_IN_WIRE")
                    IMAGE = FOREIGN_OBJECT_IN_WIRE_IMG;

                if (currentEquipmentName == la.iconName)
                {
                    fillFormPostSub(currentEquipmentName, IMAGE);
                    flag = 1;
                }
            }
        }
        foreach (Form la in UserInputList)
        {
            if (la.iconName == currentEquipmentName && !HasBeenSubmitted && flag == 0)
            {
                fillForm(currentEquipmentName, "active");
            }
            else if (la.iconName != currentIconName && flag == 0)
            {
                highlight(LD_1_IMG, "removed");
                highlight(LD_3_IMG, "removed");
                highlight(LD_5_IMG, "removed");
                highlight(PHASE_A_IMG, "removed");
                highlight(PHASE_B_IMG, "removed");
                highlight(PHASE_C_IMG, "removed");
            }
        }
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
        EQUIPMENT_DROPDWN.value = 0;
        Image IMG;
        EQUIPMENT_DROPDWN.ClearOptions();
        hideDrop();
        showIconSelectedText();
        highlight(LD_1_IMG, "removed");
        highlight(LD_3_IMG, "removed");
        highlight(LD_5_IMG, "removed");
        highlight(PHASE_A_IMG, "removed");
        highlight(PHASE_B_IMG, "removed");
        highlight(PHASE_C_IMG, "removed");
        LD1 = false;
        LD3 = false;
        LD5 = false;
        PHA = false;
        PHB = false;
        PHC = false;

        if (currentImage != null)
        {
            if (currentImage.color == Color.grey)
                highlight(currentImage, "removed");
        }

        foreach (Form la in UserInputList)
        {
            if (la.iconName == iconName)
            {
                found = true;
                break;
            }
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
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, RECLOSER_IMG);
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
                highlight(currentImage, "active");
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, CAPACITOR_IMG);
                break;

            case "RECLOSER":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Recloser OCR";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = RECLOSER_IMG;
                highlight(currentImage, "active");
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, RECLOSER_IMG);
                break;

            case "CONNECTIONS_ON_FEEDER_CONDUCTOR":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Splice";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG;
                highlight(currentImage, "active");
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG);
                break;

            case "NEST":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Nest";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = NEST_IMG;
                highlight(currentImage, "active");
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, NEST_IMG);
                break;

            case "DOWN_GUY":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Down Guy";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = DOWN_GUY_IMG;
                highlight(currentImage, "active");
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, DOWN_GUY_IMG);
                break;

            case "RISER_SHIELD":
                currentIconName = iconName;
                ICON_SELECTED_TXT.text = "Riser Shield";
                showIconSelectedText();
                severityForm(iconName);
                currentImage = RISER_SHIELD_IMG;
                highlight(currentImage, "active");
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, RISER_SHIELD_IMG);
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
                if (found == true)
                    fillForm(currentIconName, "active");
                if (HasBeenSubmitted)
                    fillFormPostSub(currentIconName, FAULT_CURRENT_INDICATOR_IMG);
                break;

            default:
                print("ERROR: Icon not recognized.");
                break;
        }
    }

    //Highlight form buttons on click as active (grey)
    public void form_OnClick(string button)
    {
        switch (button)
        {
            case "1":
                highlight(LD_1_IMG, "active");
                LD1 = true;
                LD3 = false;
                highlight(LD_3_IMG, "removed");
                LD5 = false;
                highlight(LD_5_IMG, "removed");
                break;
            case "3":
                highlight(LD_3_IMG, "active");
                LD3 = true;
                LD1 = false;
                highlight(LD_1_IMG, "removed");
                LD5 = false;
                highlight(LD_5_IMG, "removed");
                break;
            case "5":
                highlight(LD_5_IMG, "active");
                LD5 = true;
                LD3 = false;
                highlight(LD_3_IMG, "removed");
                LD1 = false;
                highlight(LD_1_IMG, "removed");
                break;
            case "A":
                if (PHASE_A_IMG.color == Color.grey)
                {
                    highlight(PHASE_A_IMG, "removed");
                    PHA = false;
                }
                else
                {
                    highlight(PHASE_A_IMG, "active");
                    PHA = true;
                }
                break;
            case "B":
                if (PHASE_B_IMG.color == Color.grey)
                {
                    highlight(PHASE_B_IMG, "removed");
                    PHB = false;
                }
                else
                {
                    highlight(PHASE_B_IMG, "active");
                    PHB = true;
                }
                break;
            case "C":
                if (PHASE_C_IMG.color == Color.grey)
                {
                    highlight(PHASE_C_IMG, "removed");
                    PHC = false;
                }
                else
                {
                    highlight(PHASE_C_IMG, "active");
                    PHC = true;
                }
                break;
        }
    }

    //There are two different forms 
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
        //Highlight the equipment icon yellow
        highlight(currentImage, "included");

        //Fill out form struct
        if (currentIconName == "OH_SWITCH" ||
            currentIconName == "LIGHTNING_ARRESTER" ||
            currentIconName == "INSULATOR" ||
            currentIconName == "POLE" ||
            currentIconName == "CROSSARM" ||
            currentIconName == "VEGETATION" ||
            currentIconName == "CONDUCTOR" ||
            currentIconName == "OH_TRANSFORMER" ||
            currentIconName == "OH_FUSE_SWITCH" ||
            currentIconName == "FOREIGN_OBJECT_IN_WIRE")
        {
            form.iconName = EQUIPMENT_DROPDWN.options[EQUIPMENT_DROPDWN.value].text;
        }
        else
        {
            form.iconName = currentIconName;
        }

        if (PHA && currentIconName == "INSULATOR")
            form.phaseA = true;
        else
            form.phaseA = false;

        if (PHB && currentIconName == "INSULATOR")
            form.phaseB = true;
        else
            form.phaseB = false;

        if (PHC && currentIconName == "INSULATOR")
            form.phaseC = true;
        else
            form.phaseC = false;

        if (LD1)
        {
            form.DL1 = true;
            form.DL3 = false;
            form.DL5 = false;
        }

        if (LD3)
        {
            form.DL3 = true;
            form.DL1 = false;
            form.DL5 = false;
        }

        if (LD5)
        {
            form.DL5 = true;
            form.DL1 = false;
            form.DL3 = false;
        }

        foreach (Form la in UserInputList)
        {
            //if the form has already been filled out, remove the old version
            if (la.iconName == currentIconName)
            {
                UserInputList.Remove(la);
                break;
            }
        }

        //Add the new form 
        UserInputList.Add(form);
        resetToStart();
    }

    //Clear user's answers for that specific form
    public void discard_OnClick()
    {
        if (currentIconName == "OH_SWITCH" ||
            currentIconName == "LIGHTNING_ARRESTER" ||
            currentIconName == "INSULATOR" ||
            currentIconName == "POLE" ||
            currentIconName == "CROSSARM" ||
            currentIconName == "VEGETATION" ||
            currentIconName == "CONDUCTOR" ||
            currentIconName == "OH_TRANSFORMER" ||
            currentIconName == "OH_FUSE_SWITCH" ||
            currentIconName == "FOREIGN_OBJECT_IN_WIRE")
        {
            currentEquipmentName = EQUIPMENT_DROPDWN.options[EQUIPMENT_DROPDWN.value].text;
        }
        else
        {
            currentEquipmentName = currentIconName;
        }

        if (currentImage.color == Color.yellow)
        {
            //Remove yellow Highlight From icon
            highlight(currentImage, "removed");
            highlight(LD_1_IMG, "removed");
            highlight(LD_3_IMG, "removed");
            highlight(LD_5_IMG, "removed");
            highlight(PHASE_A_IMG, "removed");
            highlight(PHASE_B_IMG, "removed");
            highlight(PHASE_C_IMG, "removed");

            //Find appropriate struct in formArray and delete it
            foreach (Form la in UserInputList)
            {
                print("currently checking:" + la.iconName + currentEquipmentName);
                if (la.iconName == currentEquipmentName)
                {
                    print("found what we want to delete");
                    UserInputList.Remove(la);
                    break;
                }
            }
        }
        resetToStart();
    }

    //If the form for the selected icon has already been filled out, show the user what they have already inputted
    public void fillForm(string Equipment, string state)
    {
        foreach (Form la in UserInputList)
        {
            if (la.iconName == Equipment)
            {
                if (la.DL1)
                {
                    highlight(LD_1_IMG, state);
                    highlight(LD_3_IMG, "removed");
                    highlight(LD_5_IMG, "removed");
                }
                if (la.DL3)
                {
                    highlight(LD_1_IMG, "removed");
                    highlight(LD_3_IMG, state);
                    highlight(LD_5_IMG, "removed");
                }
                if (la.DL5)
                {
                    highlight(LD_1_IMG, "removed");
                    highlight(LD_3_IMG, "removed");
                    highlight(LD_5_IMG, state);
                }
                if (la.phaseA)
                    highlight(PHASE_A_IMG, state);
                if (la.phaseB)
                    highlight(PHASE_B_IMG, state);
                if (la.phaseC)
                    highlight(PHASE_C_IMG, state);
                break;
            }
        }
    }

    //If the form has been submitted, highlight the form buttons accordingly
    //grey for user selected (active)
    //red for correct answer that the user did not select
    //green for correct answer
    public void fillFormPostSub(string Equipment, Image IMG)
    {
        fillForm(Equipment, "active");

        foreach (Form la in AnswerKeyTest)
        {
            if (la.iconName == Equipment)
            {
                if (la.DL1)
                {
                    if (IMG.color == Color.green)
                        highlight(LD_1_IMG, "correct");
                    else
                        highlight(LD_1_IMG, "incorrect");
                }
                if (la.DL3)
                {
                    if (IMG.color == Color.green)
                        highlight(LD_3_IMG, "correct");
                    else
                        highlight(LD_3_IMG, "incorrect");
                }
                if (la.DL5)
                {
                    if (IMG.color == Color.green)
                        highlight(LD_5_IMG, "correct");
                    else
                        highlight(LD_5_IMG, "incorrect");
                }
                if (la.phaseA)
                {
                    if (IMG.color == Color.green)
                        highlight(PHASE_A_IMG, "correct");
                    else
                        highlight(PHASE_A_IMG, "incorrect");
                }
                if (la.phaseB)
                {
                    if (IMG.color == Color.green)
                        highlight(PHASE_B_IMG, "correct");
                    else
                        highlight(PHASE_B_IMG, "incorrect");
                }
                if (la.phaseC)
                {
                    if (IMG.color == Color.green)
                        highlight(PHASE_C_IMG, "correct");
                    else
                        highlight(PHASE_C_IMG, "incorrect");
                }
                break;
            }
        }
    }

    #region hide/show buttons
    public void hideSeverity()
    {
        LD_TXT.gameObject.SetActive(false);
        LD_1_BTN.gameObject.SetActive(false);
        LD_3_BTN.gameObject.SetActive(false);
        LD_5_BTN.gameObject.SetActive(false);
    }
    public void showSeverity()
    {
        LD_TXT.gameObject.SetActive(true);
        LD_1_BTN.gameObject.SetActive(true);
        LD_3_BTN.gameObject.SetActive(true);
        LD_5_BTN.gameObject.SetActive(true);
    }

    public void hidePhase()
    {
        PHASE_TXT.gameObject.SetActive(false);
        PHASE_A_BTN.gameObject.SetActive(false);
        PHASE_B_BTN.gameObject.SetActive(false);
        PHASE_C_BTN.gameObject.SetActive(false);
    }
    public void showPhase()
    {
        PHASE_TXT.gameObject.SetActive(true);
        PHASE_A_BTN.gameObject.SetActive(true);
        PHASE_B_BTN.gameObject.SetActive(true);
        PHASE_C_BTN.gameObject.SetActive(true);
    }

    public void hideDrop()
    {
        EQUIPMENT_DROPDWN.gameObject.SetActive(false);
    }
    public void showDrop()
    {
        EQUIPMENT_DROPDWN.gameObject.SetActive(true);
    }

    public void hideIncludeDiscard()
    {
        INCLUDE_BTN.gameObject.SetActive(false);
        DISCARD_BTN.gameObject.SetActive(false);
    }
    public void showIncludeDiscard()
    {
        INCLUDE_BTN.gameObject.SetActive(true);
        DISCARD_BTN.gameObject.SetActive(true);
    }

    public void hideDefaultText()
    {
        DEFAULT_TXT.gameObject.SetActive(false);
    }
    public void showDefaultText()
    {
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
        HasBeenSubmitted = true;
        resetToStart();
        hideDefaultText();

        foreach (Form la in UserInputList)
        {
            print("USER INPUT:\t" + la.iconName + " :" + " \t DL1 = " + la.DL1 + "\t DL3 = " + la.DL3 + "\t DL5 = " + la.DL5 + "\t PHA = " + la.phaseA + "\t PHB = " + la.phaseB + "\t PHC = " + la.phaseC);
        }
        if (AnswerKeyTest != null)
        {
            foreach (Form lo in AnswerKeyTest)
            {
                print("ANSWER KEY:\t" + lo.iconName + " :" + " \t DL1 = " + lo.DL1 + "\t DL3 = " + lo.DL3 + "\t DL5 = " + lo.DL5 + "\t PHA = " + lo.phaseA + "\t PHB = " + lo.phaseB + "\t PHC = " + lo.phaseC);
            }
        }

        foreach (Form la in UserInputList)
        {
            //Completely Correct
            if (AnswerKeyTest.Contains(la))
            {
                //Highlight icon in green
                highlightAfterSubmit(la.iconName, "correct");

                //Test print
                print(la.iconName + "has been checked as correct");

            }
            else
            {
                //Highlight icon in red
                highlightAfterSubmit(la.iconName, "incorrect");

                //points for quiz
                points4quiz = 0;

                //Test print
                print(la.iconName + "has been checked as incorrect");
            }
        }

        if (AnswerKeyTest != null)
        {
            foreach (Form lo in AnswerKeyTest)
            {
                if (!UserInputList.Contains(lo))
                {
                    //Highlight icon in red
                    highlightAfterSubmit(lo.iconName, "incorrect");

                    print(lo.iconName + "is in the answerkey but not in the userinput");

                    points4quiz = 0;
                }
            }
        }
        print("POINTS: " + points4quiz);
    }

    //Highlight icons red or green depending on if the forms were incorrect or correct
    public void highlightAfterSubmit(string eqName, string state)
    {
        switch (eqName)
        {
            case "Disconnect Switch":
                highlight(OH_SWITCH_IMG, state);
                break;

            case "Overhead Switch Pothead":
                highlight(OH_SWITCH_IMG, state);
                break;

            case "AFS":
                highlight(OH_SWITCH_IMG, state);
                break;

            case "Ceramic LA":
                highlight(LIGHTNING_ARRESTER_IMG, state);
                break;

            case "Polymer LA":
                highlight(LIGHTNING_ARRESTER_IMG, state);
                break;

            case "Ceramic Insulator":
                highlight(INSULATOR_IMG, state);
                break;

            case "Polymer Insulator":
                highlight(INSULATOR_IMG, state);
                break;

            case "Deadend Insulator":
                highlight(INSULATOR_IMG, state);
                break;

            case "Wooden Pole":
                highlight(POLE_IMG, state);
                break;

            case "Concrete Pole":
                highlight(POLE_IMG, state);
                break;

            case "Wooden Single":
                highlight(CROSS_ARM_IMG, state);
                break;

            case "Wooden Double":
                highlight(CROSS_ARM_IMG, state);
                break;

            case "Concrete Single":
                highlight(CROSS_ARM_IMG, state);
                break;

            case "Concrete Double":
                highlight(CROSS_ARM_IMG, state);
                break;

            case "REGULATOR":
                highlight(REGULATOR_IMG, state);
                break;

            case "Oak":
                highlight(VEGETATION_IMG, state);
                break;

            case "Palm":
                highlight(VEGETATION_IMG, state);
                break;

            case "Power line":
                highlight(CONDUCTOR_IMG, state);
                break;

            case "Jumper":
                highlight(CONDUCTOR_IMG, state);
                break;

            case "Stirrup":
                highlight(CONDUCTOR_IMG, state);
                break;

            case "Single Transformer":
                highlight(OH_TRANSFORMER_IMG, state);
                break;

            case "Double Transformer":
                highlight(OH_TRANSFORMER_IMG, state);
                break;

            case "Triple Transformer":
                highlight(OH_TRANSFORMER_IMG, state);
                break;

            case "Fuse Switch":
                highlight(OH_FUSE_SWITCH_IMG, state);
                break;

            case "ALS":
                highlight(OH_FUSE_SWITCH_IMG, state);
                break;

            case "CAPACITOR":
                highlight(CAPACITOR_IMG, state);
                break;

            case "RECLOSER":
                highlight(RECLOSER_IMG, state);
                break;

            case "CONNECTIONS_ON_FEEDER_CONDUCTOR":
                highlight(CONNECTIONS_ON_FEEDER_CONDUCTOR_IMG, state);
                break;

            case "NEST":
                highlight(NEST_IMG, state);
                break;

            case "DOWN_GUY":
                highlight(DOWN_GUY_IMG, state);
                break;

            case "RISER_SHIELD":
                highlight(RISER_SHIELD_IMG, state);
                break;

            case "Balloon":
                highlight(FOREIGN_OBJECT_IN_WIRE_IMG, state);
                break;

            case "Kite":
                highlight(FOREIGN_OBJECT_IN_WIRE_IMG, state);
                break;

            case "FAULT_CURRENT_INDICATOR":
                highlight(FAULT_CURRENT_INDICATOR_IMG, state);
                break;

            default:
                print("not icon not found in highlightAfterSubmit");
                break;
        }
    }
}