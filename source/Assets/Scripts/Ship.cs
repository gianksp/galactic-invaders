﻿using UnityEngine;
using System.Collections;

public class Ship : SpaceObject {

	//Weapon system
	public Transform[] cannons;
	public GameObject bulletPrefab;
	public float reattack = 1.0f;
	public bool isShooting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		//Move forward
		transform.Translate (Vector3.forward*2, Space.Self);

		//Reset flares
		foreach (Transform cannon in cannons) {
			
			LensFlare flare = cannon.GetComponent<LensFlare>();
			if (flare.brightness >= 0) {
				flare.brightness = flare.brightness - 0.1f;
				Debug.Log(flare.brightness.ToString());
			}
		}
	}
	
	protected IEnumerator Shoot() {
		if (!isShooting) {
			isShooting = true;
			foreach (Transform cannon in cannons) {
				
				GameObject bullet = (GameObject)Instantiate(bulletPrefab, cannon.position, cannon.rotation);
				LensFlare flare = cannon.GetComponent<LensFlare>();
				flare.brightness = 1f;
				bullet.rigidbody.AddForce(transform.forward*20000f);
				
			}
			yield return new WaitForSeconds(reattack);
			isShooting = false;
		}

	}

}
