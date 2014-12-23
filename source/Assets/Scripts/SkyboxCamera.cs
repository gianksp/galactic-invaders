using UnityEngine;
using System.Collections;

public class SkyboxCamera : MonoBehaviour {

	
	// Update is called once per frame
	void Update()
	{
		
		transform.Rotate (Vector3.left*0.05f);
	}
}