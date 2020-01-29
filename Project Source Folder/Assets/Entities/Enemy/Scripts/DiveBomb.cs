using UnityEngine;
using System.Collections;
using System.Linq;

public class DiveBomb : MonoBehaviour {
	public float diveBombFrequency;
	public AudioClip diveBombSound;
	public float diveBombVolume = 0.5f;
	public static int MaximumDivers = 3;
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();	        //get animation
	}

	void Update() {
		if (IsIdle ()) {
			//Make sure this is false when we are idle
			_animator.SetBool("DiveBombAttack", false);
			//Dive bomb?
			if (Random.value < Time.deltaTime * diveBombFrequency       //chance increases as time passes and
			    && DivingCount () < MaximumDivers) {                    //current amount dive bombing less than max
				LaunchDiveBomb();                                       //initiate dive bomb behavior
			}
		}
	}

	bool IsIdle() {
		return _animator.GetCurrentAnimatorStateInfo(0).IsName ("Idle");        //If animator is idle
	}

	bool IsDiving() {
		return _animator.GetBool ("DiveBombAttack");
	}

	void LaunchDiveBomb() {
		_animator.SetBool ("DiveBombAttack", true);                             //set to diving
		_animator.SetFloat ("AttackMethod", Random.value);                      //random pattern
		AudioSource.PlayClipAtPoint (diveBombSound, this.transform.position, diveBombVolume);   //play sound
	}

    //count number diving, return count
	static int DivingCount() {
		DiveBomb[] dbs = GameObject.FindObjectsOfType<DiveBomb> ();
		return dbs.Count (db => db.IsDiving());
	}
}
