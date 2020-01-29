using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float Damage = 175.0f;

	public float GetDamage() {
		return Damage;              //return bullets damage
	}

	public void Hit() {
		Destroy (gameObject);       //destroys projectile on collision with other entity
	}

}
