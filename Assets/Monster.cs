using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public List<Sprite> spriteList;
    public float frameDuration;
    public float frameReverseDuration;
    bool isLightened = false;
    float timer = 0;
    int currentIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (isLightened == false) {
            if (timer >= frameDuration) {
                timer -= frameDuration;
                if (currentIndex + 1 < spriteList.Count) {
                    currentIndex++;
                }
                GetComponent<SpriteRenderer>().sprite = spriteList[currentIndex];
            }
        } else {
            if (timer >= frameReverseDuration) {
                timer -= frameReverseDuration;
                if (currentIndex - 1 >= 0) {
                    currentIndex--;
                }
                GetComponent<SpriteRenderer>().sprite = spriteList[currentIndex];
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        isLightened = true;
        timer = 0;
    }

    void OnTriggerExit(Collider other) {
        isLightened = false;
        timer = 0;
    }
}
