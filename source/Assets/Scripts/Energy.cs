using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour
{

	public Player player;
	public GUIText text;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update() {
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, 101, 101-player.overheat));
		text.text = player.overheat.ToString("0")+"%";
	}
}