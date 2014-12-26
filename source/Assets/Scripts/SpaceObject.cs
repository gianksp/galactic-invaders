using UnityEngine;
using System.Collections;

public class SpaceObject : MonoBehaviour {

	public GameObject explosion;

	void FixedUpdate() {

		if (transform.position.z < Camera.main.transform.position.z) {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Explosion when collides against anything else
	/// </summary>
	/// <param name="collision">Collision.</param>
	protected void OnCollisionEnter(Collision collision) {

		Instantiate (explosion, collision.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
