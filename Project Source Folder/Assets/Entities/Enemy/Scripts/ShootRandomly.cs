using UnityEngine;
using System.Collections;

public class ShootRandomly : MonoBehaviour {
	public float shootChance = 0.2f;
	public float shootDelay = 0.5f;
	public GameObject ProjectileBase;
	private float shotCooldown = 0f;
	public float minYToShoot = 0;

	// Update is called once per frame
	void Update () {
		shotCooldown -= Time.deltaTime;             //cooldown between each shot
		if (IsShooting ()) {                        //check if should fire shot
			FireShot();                             //fire shot
		}
	}

	private void FireShot() {
		Instantiate (ProjectileBase, this.transform.position, Quaternion.identity);     //instantiate projectile, reset cooldown
		shotCooldown = shootDelay;
	}

	private bool IsShooting() {
		return Random.value < shootChance * Time.deltaTime && shotCooldown <=0 &&       //if random number in range and above min y and game is ready
			transform.position.y >= minYToShoot &&
				GameController.GameReady();
	}
}
