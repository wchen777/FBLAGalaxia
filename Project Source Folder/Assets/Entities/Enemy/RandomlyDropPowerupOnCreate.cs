using UnityEngine;
using System.Collections;
using FBLAStudios;

public class RandomlyDropPowerupOnCreate : MonoBehaviour {
	public GameObject[] powerUps;
	public float chance = 0.1f;

	void Start() {
		if (Random.value < chance) {                                                            //chance met
			Instantiate(powerUps.ChooseOne(), transform.position, Quaternion.identity);         //instantiate powerup
		}
	}
}
