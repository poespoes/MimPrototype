using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchToMove2D : MonoBehaviour {

    private GameObject mim;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start() {
        mim = this.gameObject;
        rb = mim.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if ((Input.touchCount > 0)) {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            Debug.Log(hitInfo.transform.gameObject.name);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo) {
                Debug.Log(hitInfo.transform.gameObject.name);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }

        }
        else {
            rb.velocity = Vector3.zero;

        }
    }
}
