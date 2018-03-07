using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    //Functions need to be public so they can be addressed on the onclick event
    //platform specific compilation: code will run differently depending on if it's being run on Unity or not
    public void quit()
    {
        //if we are running on the editor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        
        //if we are not running in the editor (like the build)
        #else
                Application.Quit();
        
        #endif
    }
}
