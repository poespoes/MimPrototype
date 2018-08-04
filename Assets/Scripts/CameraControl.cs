using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class CameraControl : MonoBehaviour {

    public Transform target;
    public float cameraFollowSpeed = 1.0f;
    public float cameraRotationSpeed = 1.0f;

    private Vector3 cameraOffset;
    private RotateGestureRecognizer rotateGesture;

	// Use this for initialization
	void Start () {
        SetCamera();
        SetupGesture();
	}
	
	void SetCamera() {
        transform.LookAt(target.position);
        cameraOffset = transform.position - target.position;
    }

    void SetupGesture() {
        rotateGesture = new RotateGestureRecognizer();
        rotateGesture.Updated += RotateGestureCallBack;
        //rotateGesture.Updated += RotateGestureCallBack;
        FingersScript.Instance.AddGesture(rotateGesture);
    }

    void RotateGestureCallBack (GestureRecognizer gesture, ICollection<GestureTouch> touches) {
        if(gesture.State == GestureRecognizerState.Executing) {
            transform.RotateAround(target.position, Vector3.up, rotateGesture.RotationDegreesDelta * cameraRotationSpeed);
        }
        SetCamera();
    }

	void LateUpdate () {
        Vector3 targetCamPos = target.position + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, cameraFollowSpeed * Time.deltaTime);
	}
}
