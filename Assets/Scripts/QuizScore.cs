using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScore : MonoBehaviour
{
    
    public static Button SubmitQuizBtn;
    public static Text ScoreTxt;
    public int finalscoreInt = 0;

    // Use this for initialization
    void Start()
    {
        //Get Components on the Quiz Screen
        ScoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
        SubmitQuizBtn = GameObject.Find("SubmitQuizBtn").GetComponent<Button>();
    }

    public void SubmitQuizBtn_OnClick()
    {
        GameObject CAFs = GameObject.Find("CAFs");

        foreach(Transform caf in CAFs.transform)
        {
            Transform form = transform.Find("CAF_CANVAS");

            ConditionAssessment f = form.GetComponent<ConditionAssessment>() ;
            finalscoreInt +=  f.points4quiz;
        }

        print("clicked");
        string finalscoreString = finalscoreInt.ToString();
        ScoreTxt.text = finalscoreString;
    }
}
