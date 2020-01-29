using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script that moves straight line along some direction
/// </summary>
public class MoveStraight : MonoBehaviour {
	public Vector3 moveDirection;
	public float moveSpeed;

	void Start() {
		float angle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;            //gets angle of movement, converts to degrees
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);                      //rotates entity by that angle
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += moveDirection * moveSpeed * Time.deltaTime;                       //transform position down after rotation
	}
}
