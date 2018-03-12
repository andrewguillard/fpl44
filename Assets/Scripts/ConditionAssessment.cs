using UnityEngine;
using System.Collections;

public class ConditionAssessment : MonoBehaviour
{
    //This array holds all the "included" Form structs the user has filled out
    ArrayList FormList = new ArrayList();

    public string currentIconName;

    //One individual Form
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

    //TODO: Make "DEFAULT_TXT" visible
    //TODO: Make"ICON_SELECTED_TXT" invisible
    //TODO: Make Level of Damage buttons invisible
    //TODO: Make Phase buttons invisible
    //TODO: Make Discard and Include buttons invisible

    //Depending on the icon that was clicked, call the appropriate form generator
    public void icon_OnClick(string iconName)
    {
        switch (iconName)
        {
            case "OH_SWITCH":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "LIGHTNING_ARRESTER":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "INSULATOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                phaseSeverityForm(iconName);
                break;

            case "POLE":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "CROSSARM":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;
           
            case "REGULATOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "VEGETATION":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "CONDUCTOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;          

            case "OH_TRANSFORMER":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "OH_FUSE_SWITCH":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "CAPACITOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "RECLOSER":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "CONNECTIONS_ON_FEEDER_CONDUCTOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "NEST":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "DOWN_GUY":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "RISER_SHIELD":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            case "FOREIGN_OBJECT_IN_WIRE":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                trueFalseForm(iconName);
                break;

            case "FAULT_CURRENT_INDICATOR":
                currentIconName = iconName;
                print(iconName + " icon clicked");
                severityForm(iconName);
                break;

            default:
                print("ERROR: Icon not recognized.");
                break;
        }
    }

    #region Forms
    public void severityForm(string iconName)
    {
        print("severityForm method fired");
        //TODO: Make "DEFAULT_TXT" invisible
        //TODO: Generate appropriate equipment name in "ICON_SELECTED_TXT"
        //TODO: Make Level of Damage buttons visible
        //TODO: Make Phase buttons invisible
        //TODO: Make Discard and Include buttons visible
    }

    public void phaseSeverityForm(string iconName)
    {
        print("phaseSeverityForm method fired");

        //TODO: Make "DEFAULT_TXT" invisible
        //DEFAULT_TXT.SetActive(false);

        //TODO: Generate appropriate equipment name in "ICON_SELECTED_TXT"
        //ICON_SELECTED_TXT.Text = iconName;

        //TODO: Make Level of Damage buttons visible
        //LD_1_BTN.SetActive(true);
        //LD_3_BTN.SetActive(true);
        //LD_5_BTN.SetActive(true);

        //TODO: Make Phase buttons visible
        //PHASE_A_BTN.SetActive(true);
        //PHASE_B_BTN.SetActive(true);
        //PHASE_C_BTN.SetActive(true);

        //TODO: Make Discard and Include buttons visible
        //DISCARD_BTN.SetActive(true);
        //INCLUDE_BTN.SetActive(true);
    }

    public void trueFalseForm(string iconName)
    {
        print("trueFalseForm method fired");
        //TODO: Make "DEFAULT_TXT" invisible
        //TODO: Generate appropriate equipment name in "ICON_SELECTED_TXT"
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

        //Add Form struct to formList

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

    }

    //Check user's answers
    public void submit_OnClick()
    {
        print("submit_OnClick method fired");

    }

}
