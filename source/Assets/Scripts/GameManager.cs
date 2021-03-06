﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject asteroidPrefab;
	public GameObject enemyPrefab;

	public GameObject player;

	public bool gameOver;
	public bool scoresRecorded;

	public float recordedScore;
	public float recordedKills;

	public Material[] skyboxes;

	// Use this for initialization
	void Start () {

		//Change skybox
		RenderSettings.skybox=skyboxes[Random.Range(0,skyboxes.Length-1)];
		Time.timeScale =1f;
		InvokeRepeating("GenerateDebris", 1, 0.3F);
		InvokeRepeating("GenerateEnemies", 1, 1F);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (player) {
			player.gameObject.GetComponent<Player> ().score += 0.01f;
			gameObject.GetComponent<GUIText> ().text = "Score: " + player.gameObject.GetComponent<Player> ().score.ToString("0.0");
			recordedScore = player.gameObject.GetComponent<Player> ().score;
			recordedKills = player.gameObject.GetComponent<Player>().totalKills;
		}

		Time.timeScale += 0.0001F;

	}

	/// <summary>
	/// Generate asteroids
	/// </summary>
	void GenerateDebris () {

		if (player) {
			float z = Camera.main.transform.position.z;
			GameObject asteroid = (GameObject)Instantiate (asteroidPrefab, new Vector3 (Random.Range (-70, 70), Random.Range (-35, 35), Random.Range (z + 400, z + 800)), Quaternion.Euler (new Vector3 (0, 180, 0)));
			int size = Random.Range (1, 5);
			asteroid.transform.localScale = new Vector3 (size, size, size);
			asteroid.rigidbody.AddForce (new Vector3 (0, 0, -Random.Range (300, 600)), ForceMode.Impulse);
			asteroid.transform.rotation = Quaternion.Euler (new Vector3 (Random.Range (0, 180), Random.Range (0, 180), Random.Range (0, 180)));
			asteroid.rigidbody.AddTorque (new Vector3 (Random.Range (-500, 500), Random.Range (-500, 500), Random.Range (-500, 500)));
		} else {
			StartCoroutine ("Score");
		}
	}

	/// <summary>
	/// Score this instance.
	/// </summary>
	protected IEnumerator Score() {
		if (!gameOver) {
			gameOver = true;
			yield return new WaitForSeconds(2);
			//Application.LoadLevel("Main");
		}
		
	}

	/// <summary>
	/// Geneate enemies
	/// </summary>
	void GenerateEnemies () {

		if (player) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, new Vector3 (Random.Range (-20, 20), player.transform.position.y, Random.Range (player.transform.position.z + 400, player.transform.position.z + 600)), Quaternion.Euler (new Vector3 (0, 180, 0)));
			enemy.rigidbody.AddForce (new Vector3 (0, 0, -Random.Range (100, 200)),ForceMode.Impulse);
		}
	}

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI () {

		if (!player) {

			if (!scoresRecorded) {
			scoresRecorded = true;
			float lastScore  = PlayerPrefs.GetFloat("score");
			float totalScore = PlayerPrefs.GetFloat("total_score");
			float totalKills = PlayerPrefs.GetFloat("total_kills");
			float totalDaths = PlayerPrefs.GetFloat("total_deaths");

			PlayerPrefs.SetFloat("total_score",totalScore+recordedScore);
			PlayerPrefs.SetFloat("total_kills",totalKills+recordedKills);
			PlayerPrefs.SetFloat("total_deaths",totalDaths+1);

			if (recordedScore > lastScore) {
				PlayerPrefs.SetFloat("score",recordedScore);
			}
			}

						if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 50), "Try again")) {
								Application.LoadLevel ("Main");
						}

			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 50), "Main Menu")) {
				Application.LoadLevel ("Welcome");
			}
				}
	}

}
