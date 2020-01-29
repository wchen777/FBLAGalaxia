using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text> ();                                              //get text component
		text.text = string.Format ("SCORE: {0}", ScoreTracker.GetScoreString ());       //display score 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
