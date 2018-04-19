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
    private bool beenClicked = false;
    [SerializeField] private GameObject CAFs;
    // Use this for initialization
    void Start()
    {
        //Get Components on the Quiz Screen
        ScoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
        SubmitQuizBtn = GameObject.Find("SubmitQuizBtn").GetComponent<Button>();
    }

    public void SubmitQuizBtn_OnClick()
    {
        if (!beenClicked)
        {
            if (CAFs == null)
            {
                CAFs = GameObject.Find("CAFs");
            }

            foreach (Transform caf in CAFs.transform)
            {
                Transform form = transform.Find("CAF_CANVAS");

                ConditionAssessment f = null;
                foreach (Transform childInCAF in caf)
                {
                    if (childInCAF.GetComponent<ConditionAssessment>() != null)
                    {
                        f = childInCAF.GetComponent<ConditionAssessment>();
                        finalscoreInt += f.points4quiz;
                        print(caf.name + "/" + childInCAF.name + ": " + f.points4quiz);
                    }

                }

                if (f == null)
                {
                    Debug.LogError("Not found script");
                }

            }

            string finalscoreString = finalscoreInt.ToString();
            ScoreTxt.text = finalscoreString;
            beenClicked = true;
        }

    }
}
