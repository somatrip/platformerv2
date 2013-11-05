using UnityEngine;
using System.Collections;

public class alternateplatformer : MonoBehaviour {
	
	public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
	Vector3 moveVector;
	public float jumpSpeed = 10f;
	public float fallSpeed = .1f;
	
	bool grounded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		moveVector = Vector3.zero;
		
		float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
		
		if (Physics.Raycast (transform.position, - transform.up, 1.1f)) {
			grounded = true;
			if (Input.GetKey (KeyCode.Space)) {
				moveVector += Vector3.up * jumpSpeed;
				audio.Play ();
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
