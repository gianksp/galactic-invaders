using UnityEngine;
using System.Collections;

public class SpaceObject : MonoBehaviour {

	public GameObject explosion;
	public EffectCamera effectCamera;
	public Transform player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		effectCamera = GameObject.FindGameObjectWithTag ("EffectCamera").GetComponent<EffectCamera> ();
	}

	void FixedUpdate() {

		if (transform.position.z < Camera.main.transform.position.z) {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Explosion when collides against anything else
	/// </summary>
	/// <param name="collision">Collision.</param>
	protected void OnCollisionEnter(Collision collision) {

		if (collision.transform.tag != transform.tag) {
			DestroyAt(collision.transform.position);
		}
	}

	/// <summary>
	/// Destroies at pos.
	/// </summary>
	/// <param name="pos">Position.</param>
	protected void DestroyAt(Vector3 pos) {

		Instantiate (explosion, pos, Quaternion.identity);
		
		if (transform.tag != "Player") {
			if (player) {
				player.gameObject.GetComponent<Player> ().score += 5;
				float norm = player ? player.transform.position.z : 0;
				float val = transform.position.z - norm;
				double shakePower = val > 600 ? 0 : val > 400 ? 0.5 : val > 200 ? 1 : val < 750 ? 2 : 0;
				effectCamera.shakeAmount = (float)shakePower;
				effectCamera.shake = 0.5f;
			}
		}
		Destroy (gameObject);
	}
}
