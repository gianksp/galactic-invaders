using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	//Weapon system
	public Transform[] cannons;
	public GameObject bulletPrefab;
	public float reattack = 1.0f;
	public bool isShooting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected IEnumerator Shoot() {


		if (!isShooting) {
			isShooting = true;
			foreach (Transform cannon in cannons) {
				
				GameObject bullet = (GameObject)Instantiate(bulletPrefab, cannon.position, cannon.rotation);
				bullet.rigidbody.AddForce(Vector3.forward*6000f);
				
			}
			yield return new WaitForSeconds(reattack);
			isShooting = false;
		}

	}


}
