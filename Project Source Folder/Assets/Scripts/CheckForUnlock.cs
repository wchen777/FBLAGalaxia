using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckForUnlock : MonoBehaviour {

    public Button btn;
    public string level;    //complete is entire game, level1 is level 1, etc.
	
	void Start () {
        btn.interactable = false;               //disabled by default
        if (PlayerPrefs.GetInt(level, 0) == 1)  //if player has completed requirement, enable button
        {
            btn.interactable = true;            //set button to pressable
        }
	}
}
