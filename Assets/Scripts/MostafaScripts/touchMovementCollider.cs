using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMovementCollider : MonoBehaviour {
    private GameObject mim;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        mim = this.gameObject;
        rb = mim.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount > 0)) {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit)) {
                Debug.Log("Something Hit");
                if (raycastHit.collider.name == "right") {
                    Debug.Log("moving right");
                    rb.AddForce(transform.right * 10f);
                }
                else if (raycastHit.collider.name == "left") {
                    Debug.Log("moving left");
                    rb.AddForce(transform.right * -10f);
                }

                //OR with Tag
            }
        }
        else {
            rb.velocity = Vector3.zero;

        }
    }
}
