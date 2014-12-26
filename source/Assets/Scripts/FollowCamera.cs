using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = new Vector3 (transform.position.x,transform.position.y,player.transform.position.z-20);
		transform.position = Vector3.Slerp(transform.position, pos, 0.5f);
	}
}
