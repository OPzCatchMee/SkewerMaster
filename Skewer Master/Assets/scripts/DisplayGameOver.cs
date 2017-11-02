using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayGameOver : MonoBehaviour {
	
	private GameObject playerObject;

	[HideInInspector] public PlayerController player;
	public Text gameOverText;			// This displays the "Game Over"
	public Text gameOverTimeUp;			// Will displays timesup or
	public Text gameOverScore;			// below score text

	// Use this for initialization
	void Awake () {
		playerObject = GameObject.Find("Player");
		player = playerObject.GetComponent<PlayerController>();
		gameOverText.gameObject.SetActive (false);
		gameOverTimeUp.gameObject.SetActive (false);
		gameOverScore.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetScore () <= -500) {
			GameOverByScore ();
			Time.timeScale = 0;
		}
		if(player.GetTimerLevel1 () <= 0) {
			GameOverByTime ();
			Time.timeScale = 0;
		}

	}

	void GameOverByScore() {
		player.scoreText.text = "Score: -500";
		gameOverText.gameObject.SetActive (true);
		gameOverScore.gameObject.SetActive (true);
	}

	void GameOverByTime () {
		gameOverText.gameObject.SetActive (true);
		gameOverTimeUp.gameObject.SetActive (true);
		player.timer.text = "Timer: 0";
	}
}
