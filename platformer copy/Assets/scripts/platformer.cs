using UnityEngine;
using System.Collections;

public class platformer : MonoBehaviour {

	Vector3 moveVector;
	public float speed = .1f;
	public float turnSpeed = 10f;
	public float jumpSpeed = 1f;
	public float fallSpeed = 10f;
	public float range;
    public GUIText textOutput;
	
	bool grounded = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = Vector3.zero;
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			moveVector += transform.forward ;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			moveVector -= transform.forward ;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (0f, -turnSpeed * Time.deltaTime, 0f) ;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0f, turnSpeed * Time.deltaTime, 0f) ;
		}
		if (Physics.Raycast (transform.position, - transform.up, 1f)) {
			grounded = true;
			if (Input.GetKey (KeyCode.Space)) {
				moveVector += Vector3.up * jumpSpeed;
			}
		}
		else {
			grounded = false;
		}
	
	}
	
	void FixedUpdate () {
		if (moveVector != Vector3.zero) {
			rigidbody.AddForce (moveVector * speed, ForceMode.VelocityChange);
		}
		else {
			rigidbody.AddForce (-rigidbody.velocity + Physics.gravity * fallSpeed, ForceMode.Acceleration);
		}
	}
}
