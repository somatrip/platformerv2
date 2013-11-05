using UnityEngine;
using System.Collections;

public class waterscroll: MonoBehaviour {
	
	public float scrollSpeed = 0.01f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(-offset, Mathf.Sin (Time.time) );
	
	}
}
