using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject asteroidPrefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating("GenerateDebris", 1, 0.3F);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void GenerateDebris () {

		GameObject asteroid = (GameObject)Instantiate (asteroidPrefab, new Vector3 (Random.Range (-30, 30), Random.Range (-15, 15), Random.Range (300, 550)), asteroidPrefab.transform.rotation);
		asteroid.rigidbody.AddForce (new Vector3 (0, 0, -Random.Range (200, 300)),ForceMode.Impulse);
	}

}
