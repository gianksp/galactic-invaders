using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject asteroidPrefab;
	public GameObject enemyPrefab;

	public GameObject player;
	public float score = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating("GenerateDebris", 1, 0.3F);
		InvokeRepeating("GenerateEnemies", 1, 1F);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (player) {
			score += 0.1f;
		}
	}

	/// <summary>
	/// Generate asteroids
	/// </summary>
	void GenerateDebris () {

		GameObject asteroid = (GameObject)Instantiate (asteroidPrefab, new Vector3 (Random.Range (-30, 30), Random.Range (-15, 15), Random.Range (player.transform.position.z + 300, player.transform.position.z +  550)), Quaternion.Euler(new Vector3(0,180,0)));
		int size = Random.Range (1, 5);
		asteroid.transform.localScale = new Vector3 (size,size,size);
		asteroid.rigidbody.AddForce (new Vector3 (0, 0, -Random.Range (100, 200)),ForceMode.Impulse);
		asteroid.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0,180), Random.Range(0,180), Random.Range(0,180)));
		//asteroid.rigidbody.AddTorque (new Vector3 (Random.Range (-500, 500), Random.Range (-500, 500), Random.Range (-500, 500)));
	}

	/// <summary>
	/// Geneate enemies
	/// </summary>
	void GenerateEnemies () {
		
		GameObject enemy = (GameObject)Instantiate (enemyPrefab, new Vector3 (Random.Range (-10, 10), Random.Range (-2, 2), Random.Range (player.transform.position.z + 300, player.transform.position.z +  550)), Quaternion.Euler(new Vector3(0,180,0)));
		//enemy.rigidbody.AddForce (new Vector3 (0, 0, -Random.Range (100, 200)),ForceMode.Impulse);
	}

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI () {

		if (player) {
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height - 90, 200, 50), score.ToString ());
		} else {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height/2 - 90, 200, 50), "Try again")) {
				Application.LoadLevel("Main");
			}
		}
	}

}
