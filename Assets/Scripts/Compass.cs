using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    public Vector3 northDirection;
    public Transform player;

    public RectTransform northlayer;

	// Update is called once per frame
	void Update () {
        changeNorthDirection();
    }

    public void changeNorthDirection()
    {
        northDirection.z = player.eulerAngles.y + 90;
        northlayer.localEulerAngles = northDirection;
    }
}
