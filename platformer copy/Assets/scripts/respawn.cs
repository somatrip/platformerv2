﻿using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() {
		var player = GameObject.Find("player");
		player.transform.position = new Vector3 (45,10,10);
	}
}
