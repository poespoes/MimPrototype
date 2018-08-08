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
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touched");

            if (touch.position.x > mim.transform.position.x) {
                rb.AddForce(transform.right * 10f);
                Debug.Log(touch.position);
            }
            else if (touch.position.y < mim.transform.position.y) {
                rb.AddForce(transform.right * -10f);
                Debug.Log(touch.position);
            }

        }
    }
}
