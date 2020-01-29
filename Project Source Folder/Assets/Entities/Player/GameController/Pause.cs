using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public bool isPause = false;                                    //not paused by default
    public GameObject PauseMenu;
    public Button btn;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))                       //if player presses escape
        {
            isPause = !isPause;                                     //flip pause status
            if (isPause)                                            //not paused
            {
                    
                PauseMenu.SetActive(true);                          //pause the game and show pause menu
                Time.timeScale = 0;
                btn.Select();
                
            }
            else
            {
                PauseMenu.SetActive(false);                         //game was aleady paused, unpause
                Time.timeScale = 1;
            }
        }

    }
    public void resumeAtEnd()
    {                                                               //script for button to resume game and hide menu
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }


}