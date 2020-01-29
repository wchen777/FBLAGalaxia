using UnityEngine;
using System.Collections;

public class LoadNextDelay : MonoBehaviour {
	public float loadDelay;

	void Start () {
		Invoke ("LoadLevel", loadDelay);        //load next scene in build after a delay
	}

	void LoadLevel() {
		SceneManager.GetInstance ().LoadNextLevel ();
	}
}
