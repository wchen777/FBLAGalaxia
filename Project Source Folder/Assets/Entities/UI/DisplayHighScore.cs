using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHighScore : MonoBehaviour {
    public int scorelocation = 0;                       //array index of highscore 
    public string ScoreNumber;
	// Use this for initialization
	void Start () {
        Text text = GetComponent<Text>();               //gets text component
        text.text = string.Format(ScoreNumber +": {0}", ScoreTracker.GetHighScore(scorelocation));       //displays the highscore at some location in the high score array
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
