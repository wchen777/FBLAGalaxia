using UnityEngine;
using System.Collections;

public class endgame : MonoBehaviour {

    //beat game, use in victory screen
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MainMenu()
    {
        ScoreTracker.SetHighScore();                    //check score against highscore
        PlayerPrefs.SetInt("complete", 1);              //set complete to 1, enable infinite mode
        PlayerPrefs.Save();                             //save prefs
    }
}
