using UnityEngine;
using System.Collections;

public class NavigationManager : MonoBehaviour {

	public GUIText text;

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
			float lastScore  = PlayerPrefs.GetFloat("score");
			float totalScore = PlayerPrefs.GetFloat("total_score");
			float totalKills = PlayerPrefs.GetFloat("total_kills");
			float totalDaths = PlayerPrefs.GetFloat("total_deaths");


			if (text)
				text.text = "Best score: "+lastScore.ToString("0,0")+"\n"+"Total score: "+totalScore.ToString("0,0")+"\n"+"Total kills: "+totalKills.ToString("0,0")+"\n"+"Total deaths: "+totalDaths.ToString("0,0")+"\n"+"TOP GUN SCORE: "+(totalKills/totalDaths).ToString("0,0");
//
//			GUI.Label(new Rect(Screen.width/2-80,10,160,60),"Best score: "+lastScore);
//			GUI.Label(new Rect(Screen.width/2-80,30,160,60),"Total score: "+totalScore);
//			GUI.Label(new Rect(Screen.width/2-80,50,160,60),"Total kills: "+totalKills);
//			GUI.Label(new Rect(Screen.width/2-80,70,160,60),"Total deaths: "+totalDaths);
//			GUI.Label(new Rect(Screen.width/2-80,900,160,60),"TOP GUN SCORE: "+totalKills/totalDaths);

			//Go to game
			if (GUI.Button(new Rect(Screen.width/2-100,Screen.height-90,200,80),"Start")) {
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
