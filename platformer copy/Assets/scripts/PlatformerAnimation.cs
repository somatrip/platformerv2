using UnityEngine;
using System.Collections;

public class PlatformerAnimation : MonoBehaviour {

    public Rigidbody myRigidbody;

	void Start () {
        
	}
        
	void Update () {
            
        if ( Input.GetAxis( "Vertical" ) != 0f ) {
            animation["walking"].speed = myRigidbody.velocity.magnitude * 0.1f;
            animation.CrossFade( "walking" );
        } 
		
		else {
		}
	}
}