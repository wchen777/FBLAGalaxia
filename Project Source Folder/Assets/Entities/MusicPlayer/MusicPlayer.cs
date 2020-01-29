using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	private static GameObject instance;
	public AudioClip[] songList;
	private AudioSource _player;
	private int _currentSong;
    public string deleteatlevel;

	// Use this for initialization
	void Awake () {
			GameObject.DontDestroyOnLoad (gameObject);              //dont destory on scene load

	}

	void Start() {
		_player = GetComponent<AudioSource> ();                     //intialization
		_currentSong = -1;
	}
	
	// Update is called once per frame
	void Update () {                                                //delete at certain scenes to change music
        if (Application.loadedLevelName == deleteatlevel || Application.loadedLevelName=="GameOver")           //gameover scene under control of seperate audio source
            GameObject.Destroy(gameObject);
		if (!_player.isPlaying) {                                   //if track ends play next
			playNextSong();
		}
	}

	private void playNextSong() {
		if (songList.Length == 0)                                   
			return;

		_currentSong++;
		if (_currentSong >= songList.Length) {                      //loop back to start of playlist
			_currentSong = 0;
		}

		_player.clip = songList [_currentSong];                     //play track
		_player.Play ();
	}
}
