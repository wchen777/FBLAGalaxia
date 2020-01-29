using UnityEngine;
using System.Collections;

//largley obselete class
public class OptionMenuManager : MonoBehaviour {
	public bool pauseWhenOptionIsOpen = true;                       //
	public KeyCode keyCodeForOptionMenu = KeyCode.Escape;

	private bool optionMenuVisible;
	private float oldTimeScale;
	private SceneManager sceneManager;

	// Use this for initialization
	void Start () {
		sceneManager = GameObject.FindObjectOfType<SceneManager> ();        
		optionMenuVisible = false;  
		gameObject.SetActive (false);

	}

	public void showOptionMenu() {  
		Debug.Log ("Showing Option Menu");
		if (optionMenuVisible)                      
			return;
		
		if (pauseWhenOptionIsOpen) {                    //pauses game
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		gameObject.SetActive (true);                    //open menu
		optionMenuVisible = true;                       
	}

	public void ResumeGame() {
		if (pauseWhenOptionIsOpen) {                    //reset timescale 
			Time.timeScale = oldTimeScale;
		}
		gameObject.SetActive (false);                   //close menus
		optionMenuVisible = false;
	}

	public void LoadLevel(string levelName) {           //load level name
		sceneManager.LoadLevel (levelName);

	}
	
	public void ExitGame() {                            //exit game
		sceneManager.ExitGame ();
	}
}
