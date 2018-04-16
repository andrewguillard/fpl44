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
        ScoreTxt = gameObject.transform.Find("ScoreTxt").GetComponent<Text>();
        SubmitQuizBtn = gameObject.transform.Find("SubmitQuizBtn").GetComponent<Button>();
    }

    public void SubmitQuizBtn_OnClick()
    {
        //foreach ()
        //{
        finalscoreInt += ConditionAssessment.points4quiz;
        //}

        print("clicked");
        string finalscoreString = finalscoreInt.ToString();
        ScoreTxt.text = finalscoreString;
    }
}
