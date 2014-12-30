using UnityEngine;
using System.Collections;

public class Cooler : MonoBehaviour
{

	public Player player;
	public GUIText text;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update() {
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, 10, 10-player.cdKills));
	}
}