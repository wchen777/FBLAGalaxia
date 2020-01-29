using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script to limit how many projectiles are on a screen at a time
/// </summary>
public class MaxProjectiles : MonoBehaviour {
	public int maximum = 100;
	public AudioClip Sound;
	public float volume;
    public bool ignoremax;

	// Use this for initialization
	void Start () {
		int currentCount = FindObjectsOfType<MaxProjectiles> ().Length;         //finds all projectiles
		if (currentCount > maximum && !ignoremax)                               //if current count is greater than max and projectile is not set to ignore maximum
			Destroy (this.gameObject);                                          //destroy projectile
		else
			AudioSource.PlayClipAtPoint (Sound, this.transform.position, volume);   //else play laser sound
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
