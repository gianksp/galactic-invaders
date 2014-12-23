using UnityEngine;
using System.Collections;

public class Player : Ship {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.left * -Input.acceleration.x * 100 * Time.deltaTime,Space.World);
		transform.Rotate(Vector3.forward * -Input.acceleration.x * 200 * Time.deltaTime);

		if (Input.touchCount > 0) {
			StartCoroutine("Shoot");
		}
	}
}
