using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {
	private OptionMenuManager optionMenu;

	public void ExitGame() {
		Application.Quit ();        //exit game
	}

	void Start() {
		optionMenu = FindObjectOfType<OptionMenuManager> ();        //set timescale 1 on initialization
        Time.timeScale = 1f; 
	}
	
	void Update() {
		if (optionMenu) {
			if (Input.GetKeyDown (optionMenu.keyCodeForOptionMenu)) {
				optionMenu.showOptionMenu ();
			}
		}
	}

	public void StartGame() {
		ScoreTracker.Reset ();              
		LoadNextLevel ();
	}

	public void LoadLevel(string levelName) {
		Debug.Log ("Load Level");
		Application.LoadLevel (levelName);                  //load level name
	}
    
    public void LoadGameOver()
    {
        Application.LoadLevel("GameOver");                  //method to load game over
    }

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public static SceneManager GetInstance() {              //get instance of scenemanager
		return FindObjectOfType<SceneManager> ();
	}

}
