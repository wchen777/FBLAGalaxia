using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTracker : MonoBehaviour {
	public int Lives = 3;
	public Text LivesText;
	public int increment = 10000;
    public int livescap = 3;
	public AudioClip ExtraLife;

	private int nextLife = 0;

	void Start () {
		Lives = 3;                                  //initialzation 
		LivesText = GetComponent<Text> ();          //gets lives text
		nextLife = increment;                       
	}

	void Update() {
		if (ScoreTracker.GetScore () > nextLife) {          //if score greater than amount needed for extra life
            if (Lives < livescap)                           //if lives below lives cap
            {
                Lives++;                                                                    //increase lives
                RefreshText();                                                              //refresh lives text
                AudioSource.PlayClipAtPoint(ExtraLife, Vector3.zero, 0.4f);                 //play sfx
            }   
                
			nextLife += increment;          //increase score needed for extra life

		}
	}

	public int LoseLife() {
		Lives--;                    //lose a life
		RefreshText ();             //refresh display
		return Lives;               //return new life value
	}

	private void RefreshText() {
		LivesText.text = string.Format ("LIVES: {0}", Lives);           //display current lives
	}
}
