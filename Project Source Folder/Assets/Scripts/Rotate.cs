using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public Vector3 rotateSpeed = Vector3.zero;                      //speed of rotation

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (rotateSpeed * Time.deltaTime);       //rotates game object over delta time
	}
}
