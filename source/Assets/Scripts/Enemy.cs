using UnityEngine;
using System.Collections;

public class Enemy : Ship {

	// Use this for initialization
	void Start (){
		Destroy (gameObject, 20);
	}

	// Update is called once per frame
	void Update () {
	
		StartCoroutine("Shoot");
	}
}
