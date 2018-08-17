using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class actiateScroll : MonoBehaviour {
    public GameObject gameData;

	// Use this for initialization
	void Start () {
        gameData = GameObject.Find("GameData");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag=="seedPod") {
                Debug.Log("Scrolling activated");
                //gameData.GetComponent<sceneData>().canDrag = true;
                gameData.GetComponent<sceneData>().canDrag = true;
            }
        }
    }
}
