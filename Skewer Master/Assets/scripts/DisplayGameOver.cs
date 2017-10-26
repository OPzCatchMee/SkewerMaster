using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayGameOver : MonoBehaviour {

	private bool timesUp;				// Times is over
	private bool overScore;				// Score is below or equal -500

	public PlayerController player;
	public Text gameOverText;			// This displays the "Game Over"
	public Text gameOverTimeUp;			// Will displays timesup or
	public Text gameOverScore;			// below score text

	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.Find("Player");
		PlayerController player = playerObject.GetComponent<PlayerController>();
		gameOverText.gameObject.SetActive (false);
		gameOverTimeUp.gameObject.SetActive (false);
		gameOverScore.gameObject.SetActive (false);
		timesUp = false;
		overScore = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetScore () <= -500) {
			GameOverScore ();
		}
	}

	void GameOverScore() {
		gameOverText.gameObject.SetActive (true);
		gameOverScore.gameObject.SetActive (true);
	}
}
