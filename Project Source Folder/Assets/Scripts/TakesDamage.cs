using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour {
	public GameObject DeathClip;
	public float Health = 10.0f;
	public int Points = 0;
	public GameObject HitAnimation;

	void OnTriggerEnter2D(Collider2D other) {
		Projectile missile = other.GetComponent<Projectile> ();
		if (missile) {                                                  //if missile collides
			TakeDamage (missile.GetDamage ());                          //get damage
			missile.Hit ();                                             
		} else {
			//If hitting another solid object take full damage
			TakesDamage solidObject = other.GetComponent<TakesDamage>();    
			if (solidObject) {  
				TakeDamage(this.Health);                                        //subtract health
			}
		}
	}


	private void TakeDamage(float damage) {
		//Don't take damage if there is a shield attached
		if(GetComponentInChildren<Shield>() != null && !CompareTag ("Shield"))
			return;

		Debug.Log ("Taking Damage");
		this.Health -= damage;

		if (Health <= 0) {
			DestroyEntity();                                                                        //if health is 0, destroy entity
		}

		if (HitAnimation) {
			Instantiate(HitAnimation, gameObject.transform.position,Quaternion.identity);           //instantiate hit animation
		}
	}


	/// <summary>
	/// When an entity is destroyed because it's health is zero, execute relevant commands
	/// </summary>
	private void DestroyEntity() {
		//Create death clip object
		if (DeathClip) {
			GameObject clip = Instantiate (DeathClip, this.transform.position, Quaternion.identity) as GameObject;
			//Show points if available
			if (Points != 0) {
				clip.GetComponentInChildren<TextMesh> ().text = Points.ToString ();                        
			}
		}

		//Remove Game Object
		Destroy (this.gameObject);

		//Add Points for destroying it
		ScoreTracker.GetInstance ().ScorePoints (Points);
	}
}
