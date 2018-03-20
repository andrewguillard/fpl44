using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnIndex : MonoBehaviour
{
    /*
    Scene Index key:
        0: Main Menu
        1: Randomized Training
        2: Selective Training
        3: Quiz
        4: Quit
    */
    public void LoadBy(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
