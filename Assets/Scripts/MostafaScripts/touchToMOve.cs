using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchToMOve : MonoBehaviour {
    private GameObject mim;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        mim = this.gameObject;
        rb = mim.GetComponent<Rigidbody2D>();
       
	}

    // Update is called once per frame
    void Update() {
        float mimX = mim.transform.position.x;

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touched");
            //print(touch.position.x);

            Vector3 pos = touch.position;

            Vector3 cameraPos = Camera.main.ScreenToWorldPoint(pos);


            if (cameraPos.x > mimX) {
                rb.AddForce(transform.right * 10f);
                Debug.Log(touch.position.x);
                Debug.Log("Moved right");
            }
            else if (cameraPos.x < mimX) {
                rb.AddForce(transform.right * -10f);
                Debug.Log(touch.position.x);
                Debug.Log("Moved left");
            }

        }
        else {
            rb.velocity = Vector3.zero;
            
        }
    }
}
