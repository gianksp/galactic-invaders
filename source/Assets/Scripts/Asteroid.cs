using UnityEngine;
using System.Collections;

public class Asteroid : SpaceObject {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
