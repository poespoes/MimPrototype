using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

    public float moveSpeed;
    public float jumpSpeed;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(rightKey)) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            Debug.Log("moving");
        }
    }
}
