using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
    private static string framing;

    public void setFraming(string f) {
        print("set framing" + f);
        framing = f;
    }

    public string getFraming() {
        return framing;
    }
}
