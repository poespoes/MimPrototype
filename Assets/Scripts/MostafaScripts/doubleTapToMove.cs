using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleTapToMove : MonoBehaviour {
    public Transform mimTransform;
    public Camera cam;
    public Rigidbody2D rb;
    public float runAmount;

    int TapCount;
    public float MaxDubbleTapTime;
    float NewTime;

    void Start() {
        TapCount = 0;

        rb = mimTransform.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 mimScreenPos = cam.WorldToScreenPoint(mimTransform.position);
        //Debug.Log("target is " + mimScreenPos.x + " pixels from the left");


        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended) {
                TapCount += 1;
            }

            if (TapCount == 1) {

                NewTime = Time.time + MaxDubbleTapTime;
            }
            else if (TapCount == 2 && Time.time <= NewTime) {

                //Whatever you want after a dubble tap    
                print("Dubble tap");
                //Debug.Log("touch is at " + touch.position.x + " pixels from the left");


                if (touch.position.x > mimScreenPos.x) {
                    rb.AddForce(transform.right * runAmount);
                    //Debug.Log(touch.position.x);
                    Debug.Log("Moved right");
                }
                else if (touch.position.x < mimScreenPos.x) {
                    rb.AddForce(transform.right * -runAmount);
                    //Debug.Log(touch.position.x);
                    Debug.Log("Moved left");
                }

                TapCount = 0;
            }

        }
        else{
           // rb.velocity = Vector3.zero;
        }
        if (Time.time > NewTime) {
            TapCount = 0;
        }
    }
}
