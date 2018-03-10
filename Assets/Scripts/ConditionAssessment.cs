using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ConditionAssessment : MonoBehaviour
{

    public void iconClicked(int iconNumber)
    {
        switch (iconNumber)
        {
            case 1://OH Switch
                severityForm(iconNumber);
                break;
            case 2://Lightning Arrester
                severityForm(iconNumber);
                break;
            case 3://Insulator
                phaseSeverityForm(iconNumber);
                break;
            case 4://Pole
                severityForm(iconNumber);
                break;
            case 5://Crossarm
                severityForm(iconNumber);
                break;
            case 6://Vegetation
                trueFalseForm(iconNumber);
                break;
            case 7://Capacitor
                severityForm(iconNumber);
                break;
            case 8://OH Tranformer
                severityForm(iconNumber);
                break;
            case 9://OH Fuse Switch
                severityForm(iconNumber);
                break;
            case 10://Capacitor
                severityForm(iconNumber);
                break;
            case 11://Connections On Feeder Conductor
                trueFalseForm(iconNumber);
                break;
            case 12://Nest
                trueFalseForm(iconNumber);
                break;
            case 13://Down Guy
                trueFalseForm(iconNumber);
                break;
            case 14://Riser Shield
                severityForm(iconNumber);
                break;
            case 15://Foreign Object in Wire
                trueFalseForm(iconNumber);
                break;
            default:
                System.Diagnostics.Debug.WriteLine("Icon not recognized.");
                break;
        }
    }

    public void severityForm(int iconNumber)
    {

    }

    public void phaseSeverityForm(int iconNumber)
    {

    }

    public void trueFalseForm(int iconNumber)
    {

    }
}
