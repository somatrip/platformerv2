using UnityEngine;
using System.Collections;

public class waterdeform : MonoBehaviour {
	
	MeshFilter mf;
	Vector3[] baseVertices;
	Vector3[] workingCopy;
	public float waveHeight = .003f;
	public float waveSize = .6f;
	
	// Use this for initialization
	void Start () {
		mf = GetComponent<MeshFilter>();
		baseVertices = mf.mesh.vertices;
	
	}
	
	// Update is called once per frame
	void Update () {
		//every frame, start with a fresh copy of the untouched plane
		workingCopy = baseVertices;
		
		for (int i = 0; i < workingCopy.Length; i++) {
			// go through every vertex in this model
			// and move it either up or down accordign to the sine wave
			workingCopy[i] = baseVertices[i] + Vector3.up * Mathf.Sin( (Time.time + i) * waveSize ) * waveHeight;
		}
		
		// stuff data back in meshFilter
		mf.mesh.vertices = workingCopy;
		
		//recalculate normals
		mf.mesh.RecalculateNormals();
		
		//visualize normals
		for (int i = 0; i < workingCopy.Length; i++) {
			Debug.DrawRay (mf.mesh.vertices[i], mf.mesh.normals[i] );
		}	
	
	}
}
