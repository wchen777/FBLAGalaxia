using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {
	public GameObject Player;
	LivesTracker tracker;

	// Use this for initialization
	void Start () {
		tracker = GameObject.FindObjectOfType<LivesTracker> ();     //find livestracker

	}

	void OnDestroy() {
		int lives = tracker.LoseLife ();                            //lose a life
		GameController.PlayerDied (lives);                          //call player died method
	}
}
