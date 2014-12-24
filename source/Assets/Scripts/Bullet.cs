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

	void OnCollisionEnter(Collision collision) {

		Instantiate (explosion, collision.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
