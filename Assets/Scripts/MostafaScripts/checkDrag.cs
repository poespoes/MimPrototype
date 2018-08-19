using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class checkDrag : MonoBehaviour {
    public GameObject gameData;
    public bool drag;

	// Use this for initialization
	void Start () {
        gameData = GameObject.Find("GameData");
        //canDrag = false;
        drag = gameData.GetComponent<sceneData>().canDrag;
    }
	
	// Update is called once per frame
	void Update () {
        drag = gameData.GetComponent<sceneData>().canDrag;

        if (drag == true) {

            this.gameObject.GetComponent<FingersPanOrbitComponentScript>().enabled = true;

        }

        else if (drag == false) {

            this.gameObject.GetComponent<FingersPanOrbitComponentScript>().enabled = false;
        }
	}
}
