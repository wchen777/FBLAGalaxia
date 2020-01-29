using UnityEngine;
using System.Collections;
using FBLAStudios;

public class FormationController : MonoBehaviour {
	public float formationSpeed = 10.0f;
	public float height;
	public float width;

	private Vector3 direction = Vector3.left;
	private float minX;
	private float maxX;
    public bool moveopposite = false;

	// Use this for initialization
	void Start () {
        if (moveopposite)               //use to make formation move right to left vs left to right
            direction = Vector3.right;
		minX = ViewportHelpers.GetBottomLeftBoundary (transform.position).x + width / 2;            //minx and maxx of formation movement
		maxX = ViewportHelpers.GetTopRightBoundary (transform.position).x - width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		moveFormation ();               //constantly move
	}

	private void moveFormation() {                                              
		Vector3 movement = direction * formationSpeed * Time.deltaTime;         //direction*speed*time, used to move formation
        transform.position += movement;                                         //transform it by that number                        

		//Validate position, reverse if invalid
		if (transform.position.x < minX)                                        //move right if minx reached
			direction = Vector3.right;

		if (transform.position.x > maxX)                                        //move left if maxx reached
			direction = Vector3.left;
	}


	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));           //draw wire box of formation in scene view
	}
}
