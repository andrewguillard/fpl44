using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {
    public Image logo;
    Color logoColor;


	// Use this for initialization
	void Start() {
        logoColor = new Color(1, 1, 1, 0);
        logo.color = logoColor;

        StartCoroutine(GotoMainMenu());
    }


	
	// Update is called once per frame
	void Update () {
        logoColor = Color.Lerp(logoColor, new Color(1, 1, 1, 1),
        Time.time * 0.02f);
        logo.color = logoColor;
	}

    IEnumerator GotoMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
