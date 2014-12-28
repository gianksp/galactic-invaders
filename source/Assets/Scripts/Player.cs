using UnityEngine;
using System.Collections;

public class Player : Ship {

	public float score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 destination = new Vector3 (Input.acceleration.x * 150, 0, 0); //Input.acceleration.z * 20,0);
		transform.Translate(destination * Time.deltaTime,Space.World);
		transform.Rotate(Vector3.forward * -Input.acceleration.x * 70 * Time.deltaTime);
		//Debug.Log (Input.acceleration);
		if (Input.touchCount > 0) {
			StartCoroutine("Shoot");
		}

		PlayerMovementClamping ();

	}

	/// <summary>
	/// Dont let player get out of the screen
	/// </summary>
	void PlayerMovementClamping() {
		var viewpointCoord = Camera.main.WorldToViewportPoint(transform.position);
		
		if (viewpointCoord.x < 0.0f)
		{
			viewpointCoord.x = 0.0f;
			transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
		}
		else if (viewpointCoord.x > 1.0f)
		{
			viewpointCoord.x = 1.0f;
			transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
		}
	}

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI(){

		GUI.Label (new Rect (Screen.width - 100, 10, 100, 20), "Overheat: "+overheat+"%");
	}
}
