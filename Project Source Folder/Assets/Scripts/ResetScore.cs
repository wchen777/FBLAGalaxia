using UnityEngine;
using System.Collections;

public class ResetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {                                     //loads on title start, resets score and weapon level
        ScoreTracker.Reset();
        PlayerPrefs.SetInt("weapon", 0);
        PlayerPrefs.Save();
    }

    public void ResetAllPrefData()                      //method used during making of game to reset all player prefs
    {
        PlayerPrefs.SetInt("weapon", 0);
        PlayerPrefs.SetInt("complete", 0);
        ScoreTracker.ResetHighScore();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))                                //not part of game experience, simply here for ease of access/judging
            if (PlayerPrefs.GetInt("complete", 0) == 0)
                PlayerPrefs.SetInt("complete", 1);                      //press i to toggle infinite mode unlocked/locked
            else
                PlayerPrefs.SetInt("complete", 0);
    }
}
