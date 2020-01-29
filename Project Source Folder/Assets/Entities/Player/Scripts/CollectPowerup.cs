using UnityEngine;
using System.Collections;

public class CollectPowerup : MonoBehaviour {
	private ShootBasicGun shoot;
	public AudioClip CaughtSound;
	public float volume = 0.5f;
	public GameObject ShieldPrefab;

	// Use this for initialization
	void Start () {
		shoot = GetComponentInChildren<ShootBasicGun> ();
	}

	void OnTriggerEnter2D(Collider2D other) {               //hitbox collides
		if (other.CompareTag ("PowerUp")) {                 //if tag is PowerUp
			Debug.Log ("Caught Powerup");
			shoot.UpgradeWeapon();                          //upgrade weapon
			Destroy (other.gameObject);                     //destroy powerup entity
			AudioSource.PlayClipAtPoint(CaughtSound, gameObject.transform.position);            //plays sound
		} else if (other.CompareTag("PowerUp_Shield")) {    //if tag is shield
			if (GetComponentInChildren<Shield>() == null) { //player does not have shield    
				GameObject shield = Instantiate(ShieldPrefab, Vector3.zero, Quaternion.identity) as GameObject;    //instantiate shield prefab around player
				shield.transform.SetParent (transform, false);          //attach to player
				Destroy (other.gameObject);                             //destroy shield powerup entity
				AudioSource.PlayClipAtPoint(CaughtSound, gameObject.transform.position);        //play sound
			}
		}
	}
}
