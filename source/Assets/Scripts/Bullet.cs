using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start (){
		Destroy (gameObject, 10);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Destroy bullet on collision
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter(Collision collision) {
		Destroy (gameObject);
	}
}
