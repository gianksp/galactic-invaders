using UnityEngine;
using System.Collections;

public class Ship : SpaceObject {

	//Weapon system
	public Transform[] cannons;
	public GameObject bulletPrefab;
	public float reattack = 1.0f;
	public bool isShooting;
	public float overheat = 0;

	public float speed;

	public AudioClip shootSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		//Move forward
		transform.Translate (Vector3.forward*speed, Space.Self);

		//Reset flares
		foreach (Transform cannon in cannons) {
			
			LensFlare flare = cannon.GetComponent<LensFlare>();
			if (flare.brightness >= 0) {
				flare.brightness = flare.brightness - 0.1f;
				Debug.Log(flare.brightness.ToString());
			}
		}

		if (overheat >= 100) {
			overheat = 100;
			DestroyAt(transform.position);
		}

		if (overheat > 0f) {
			overheat -=0.1f;
			if (overheat < 0f) {
				overheat = 0f;
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
				bullet.tag = transform.root.transform.tag;
				bullet.rigidbody.AddForce(transform.forward*9000f*speed);
				audio.PlayOneShot(shootSound);
				overheat+=3;
				yield return new WaitForSeconds(reattack/2);
				
			}
			isShooting = false;
		}

	}

}
