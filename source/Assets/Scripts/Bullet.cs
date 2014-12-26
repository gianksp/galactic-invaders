using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	public Material color;

	public string ownerTag;

	// Use this for initialization
	void Start (){
		Destroy (gameObject, 10);
		transform.renderer.material = color;
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
