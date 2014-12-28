using UnityEngine;
using System.Collections;

public class NavigationManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		if (Application.loadedLevel == 0) {

			//Display latest score
			float score = PlayerPrefs.GetFloat("score");

			GUI.Label(new Rect(Screen.width/2-80,Screen.height/2-100,160,60),"Best score: "+score);
			//Go to game
			if (GUI.Button(new Rect(Screen.width/2-100,Screen.height-100,200,90),"Start")) {
				Application.LoadLevel("Main");
			}

		} else if (Application.loadedLevel == 2) {

			if (GUI.Button(new Rect(Screen.width/2-100,Screen.height-100,200,90),"Intro")) {
				Application.LoadLevel("Welcome");
			}

		} else {
				
		}
 	}
}
