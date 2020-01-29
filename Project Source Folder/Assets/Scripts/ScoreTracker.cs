using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
	private static int score = 0;
	private const string SCORE_FORMAT = "{0}";
	private Text label;
    private static int[] highscorearray;
    private static int[] defaultscores = { 0, 0, 0, 0, 0 };

    void Start() {
        highscorearray = PlayerPrefsX.GetIntArray("highscores", 0, 5);      //gets a temporary array
        label = GetComponent<Text> ();
		UpdateDisplay ();
	}

	public static void Reset() {                                            //reset score to 0 
		score = 0;
	}

    public void ScorePoints(int points) {                                   //add points to score
		score += points;
		UpdateDisplay ();
	}

	private void UpdateDisplay() {                                          //refresh score display
		label.text = string.Format (SCORE_FORMAT, GetScoreString());
	}

	public static ScoreTracker GetInstance() {                              //grab instance of scoretracker, allows access to score variable
		return FindObjectOfType<ScoreTracker> ();
	}

	public static string GetScoreString() {                                 //returns score in form of string 
		return score.ToString ("D7");
	}

	public static int GetScore() {
		return score;                                                       //return int score
	}

    public static void SetHighScore()
    {
        if (score > highscorearray[4])          //if score > last term in array
        {
            highscorearray[4] = ScoreTracker.GetScore();                    //replace last term with new high score
            Array.Sort(highscorearray);                                     //sort array again, low to high
            Array.Reverse(highscorearray);                                  //reverse it so it is high to low
            PlayerPrefsX.SetIntArray("highscores", highscorearray);         //set the playerpref array to the new highscore array
        }
    }

    public static string GetHighScore(int location)
    {
        int[] temp = PlayerPrefsX.GetIntArray("highscores", 0, 5);          //grab a copy of playerpref array
        return temp[location].ToString("D7");                               //return the score at some location in the array, in form of string
    }

    public static void ResetHighScore()
    {
        PlayerPrefsX.SetIntArray("highscores", defaultscores);              //sets playerpref highscore array to all zereos, effectivley reseting the highscores
    }

}
