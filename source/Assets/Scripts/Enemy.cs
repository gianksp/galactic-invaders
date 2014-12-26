using UnityEngine;
using System.Collections;

public class Enemy : Ship {

	// Update is called once per frame
	void Update () {
	
		StartCoroutine("Shoot");
	}
}
