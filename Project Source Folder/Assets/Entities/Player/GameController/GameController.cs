using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public Text ReadyPlayerOneText;
    public Text FoundJornal;
    public Text CautionText;
    public bool ShowCaution = false;
	public float MessageDelay;
	public Text WaveText;
	public bool GameIsReady = false;
	public int WaveNumber = 0;
	public float volume = 0.5f;
	public GameObject player;
    public GameObject InfoPanel1;
    public GameObject InfoPanel2;
    public Button btn1;
    public Button btn2;
    public int nextPanelIncrement;                  //increase scorecap by this number for panel 2
    public int WaveNumberModifer;                   //for displaying wave correctly on differnt levels
    public  int WaveCap = -1;                       //set a wave cap to change levels
    public string LevelToLoad;      
	public AudioClip WaveSpawned;
    public int ScoreCap = -1;
    private bool hasShownInfo1 = false;
    private bool hasShownInfo2 = false;
    private bool ShowJ1 = false;
    private bool ShowJ2 = false;
	private float LastWaveCheck = 0;
	private float MinTimeBetweenCheck = 1f;


	public static GameController GetInstance() {
		return GameObject.FindObjectOfType<GameController> ();          //Allows getting an instance of class Gamecontroller
	}

	public static void PlayerOneSpawning() {
		GameController instance = GetInstance ();                       //show ready text
		if (instance)                                                    
			instance.ShowPlayerOneText ();
		//NextWave ();
	}

	public static void NextWave() {
		GameController instance = GetInstance ();                       //proceed to next wave
		if (instance)
			instance.ShowWaveText ();
	}

	public static void PlayerDied(int lives) {  
		if (lives <= 0) {                                               //no lives left
            ScoreTracker.SetHighScore();                                //check if score is new highscore
            PlayerPrefs.SetInt("weapon", 0);                            //reset weapon level, is obselete in current game version (you do not keep powerups throughout scenes as of right now)
            PlayerPrefs.Save();                                         //save pref to registry
            SceneManager.GetInstance ().Invoke ("LoadGameOver", 3);     //load game over scene
		}
        else {
            PlayerPrefs.SetInt("weapon", 0);                            //reset weapon
            GetInstance().Invoke ("SpawnPlayer", 3);                    //spawn player again
		}
	}

	void Start() {
		NextWave ();
        hasShownInfo1 = false;                      //initializaztion
        hasShownInfo2 = false;
	}

	void Update() {
		if (GameIsReady && GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {               //game is ready and no enemies left
			LastWaveCheck += Time.deltaTime;                                                        
			if (LastWaveCheck > MinTimeBetweenCheck) {                                              //last wave check more than 1 s ago
				NextWave ();                                                                        //spawns next wave
			}   
		} else {
			LastWaveCheck = 0;                                                                      //enemies alive, reset to 0
		}
        if (ScoreCap <= ScoreTracker.GetScore() && !hasShownInfo1 && ScoreCap>=0 && !ShowJ1)                        //if score cap met, has not shown 1, and score cap exists
        {
            ShowJ1 = true;          //show 1 at end of wave
            ShowJournalText();
        }
        if(ScoreCap <= ScoreTracker.GetScore() && hasShownInfo1 && !hasShownInfo2 && ScoreCap >= 0 && !ShowJ2)      //if score cap met, has show 1 already, has not shown 2, and score cap exists
        {
            ShowJ2 = true;         //show 2 at end of wave
            ShowJournalText();     
        }
	}

	void SpawnPlayer() {
		//Check if there are still projectiles, if so don't spawn the enemy just yet
		if (GameObject.FindObjectsOfType<Projectile> ().Length > 0) {
			Invoke ("SpawnPlayer", 1);                                      //recursion until no projectiles
		} else {    
			Instantiate (player);                                           //spawn player
		}
	}

    public void ShowInfo()
    {
        Time.timeScale = 0f;
        ScoreCap += nextPanelIncrement;
        InfoPanel1.SetActive(true);                 //show panel 1, set new score cap for panel 2
        btn1.Select();      
        hasShownInfo1 = true;
    }

    public void ShowInfo2()
    {
        Time.timeScale = 0f;
        InfoPanel2.SetActive(true);                //show panel 2
        btn2.Select();
        hasShownInfo2 = true;
    }

    void ShowJournalText()
    {
        FoundJornal.enabled = true;             //Show recieved journal text
        Invoke("HideJournalText", 2);           //hide after 2 s
    }

    void HideJournalText()                  
    {                           
        FoundJornal.enabled = false;            //hide text
    }

    void ShowWaveText() {
        if (ShowJ1 && !hasShownInfo1)           //if player collected info during wave show it at end
            ShowInfo();
        if (ShowJ2 && !hasShownInfo2)
            ShowInfo2();
        WaveNumber++;                           //increases wave
        if (ShowCaution && WaveNumber == 29)    //if boss wave
        {
            ShowCautionText();                  //show caution
        }
        if (WaveNumber == WaveCap)              //checks if cap is reached
        {
            Time.timeScale = 0f;                //load different scene
            Application.LoadLevel(LevelToLoad);
        }
        else
        {                                                                           //keep going if not
            WaveText.text = "Wave " + (WaveNumber - WaveNumberModifer);             //displays wave
            WaveText.enabled = true;                                
            Invoke("HideWaveText", MessageDelay);                                   //hide it after some time
            GameIsReady = false;
        }
	}

	void HideWaveText() {
		WaveText.enabled = false;                                                       //hide wave text
		GameIsReady = true;
		AudioSource.PlayClipAtPoint (WaveSpawned, this.transform.position, volume);     //play new wave sound
	}

	void ShowPlayerOneText() {
		ReadyPlayerOneText.enabled = true;
		Invoke ("HidePlayerOneText", MessageDelay);                         //show ready text
		GameIsReady = false;
	}

	void HidePlayerOneText() {
		ReadyPlayerOneText.enabled = false;                                 //hide ready text
		GameIsReady = true;
	}

    void ShowCautionText()
    {
        CautionText.enabled = true;
        Invoke("HideCautionText", MessageDelay);                         //show caution
        GameIsReady = false;
    }

    void HideCautionText()
    {
        CautionText.enabled = false;                                 //hide caution
        GameIsReady = true;
    }

    public void DonePanelOne()
    {
        InfoPanel1.SetActive(false);                             //close info panels
        Time.timeScale = 1;
    }
    public void DonePanelTwo()
    {
        InfoPanel2.SetActive(false);
        Time.timeScale = 1;
    }

	public static bool GameReady() {
		return GetInstance().GameIsReady && GameObject.FindObjectOfType<PlayerController>();                //game ready if all criteria met (text gone, player spawned)
	}
}
