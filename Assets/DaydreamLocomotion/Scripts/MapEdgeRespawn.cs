using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEdgeRespawn : MonoBehaviour {

	private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
		spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -100)
			transform.position = spawnPoint;
	}
}
