using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 move;
	private float cowDuration;					// duration of the cow effect
	private float sheepDuration;				// duration of the sheep effect
	private static int score;
	[HideInInspector]public float maxHeight;					// Max player can go
	[HideInInspector]public float minHeight;					// Min player can go
	[HideInInspector]public float lane_1;
	[HideInInspector]public float lane_2;
	[HideInInspector]public float lane_3;
	[HideInInspector]public float lane_4;
	[HideInInspector]public float lane_5;

	private bool cowEffect;					// Stuns the player
	private bool sheepEffect;				// Reverse the key

	private int combinationTracker;

	public Text scoreText;				// Displays the score
	public Text timer;					// Displays the count down
	public float offsetY;			// How much space player is moving
	public float timerLevel_1;
	public GameObject chickenAcquired;
	public GameObject onionAcquired;
	public GameObject pepperAcquired;
	public GameObject baconAcquired;
	public GameObject steakAcquired;
	public GameObject mushroomAcquired;

	// Use this for initialization
	void Awake () {
		cowEffect = false;
		sheepEffect = false;
		SetText ();
		combinationTracker = 0;
		chickenAcquired.SetActive (false);
		onionAcquired.SetActive (false);
		pepperAcquired.SetActive (false);
		baconAcquired.SetActive (false);
		steakAcquired.SetActive (false);
		mushroomAcquired.SetActive (false);


	}

	void Start() {
		// Calculate the position
		maxHeight = 800f;
		minHeight = 300f;
	}
	
	// Update is called once per frame
	void Update () {
		sheepDuration += Time.deltaTime;
		cowDuration += Time.deltaTime;
		timerLevel_1 -= Time.deltaTime;
		timer.text = "Timer: " + timerLevel_1.ToString ();

		if (sheepEffect) {
			if (!cowEffect) {
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					if (transform.position.y >= maxHeight) {
						// do nothing...
					} else {
						move.y = offsetY;
						transform.position += move;
					}
					cowEffect = false;
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					if (transform.position.y <= minHeight) {
						// do nothing...
					} else {
						move.y = offsetY;
						transform.position -= move;
					}
					cowEffect = false;
				}
			}
			if (sheepDuration >= 5) {		// Stop the sheep effect
				sheepEffect = false;
			}
			if (cowDuration >= 2) {		// Stop the cow effect
				cowEffect = false;
			}
		} else {
			if (!cowEffect) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					if (transform.position.y >= maxHeight) {
						// do nothing...
					} else {
						move.y = offsetY;
						transform.position += move;
					}
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					if (transform.position.y <= minHeight) {
						// do nothing...
					} else {
						move.y = offsetY;
						transform.position -= move;
					}
				}
			}
			if (cowDuration >= 2) {		// Stop the cow effect
				cowEffect = false;
			}
		}
	}

	// Collision detected - Update score/ trigger object effects
	void OnTriggerEnter2D(Collider2D collider) {
		scoreText.text = "Score: " + score.ToString ();		// Displays the score
		Scene scene = SceneManager.GetActiveScene ();

		switch (collider.gameObject.tag) {
		case "Chicken":
			if (combinationTracker == 0) {
				score += 100;
				chickenAcquired.SetActive (true);
				combinationTracker++;
			} else {
				score -= 100;
			}
			Destroy (collider.gameObject);
			break;
		case "Onion":
			if (combinationTracker == 1) {
				score += 100;
				onionAcquired.SetActive (true);
				combinationTracker++;
			} else {
				score -= 100;
			}
			Destroy (collider.gameObject);
			break;
		case "Pepper":
			if (combinationTracker == 2) {
				score += 100;
				pepperAcquired.SetActive (true);
				combinationTracker++;
				if (scene.name == "Level1") {
					combinationTracker = 0;
					SceneManager.LoadScene ("Level2");
					chickenAcquired.SetActive (false);
					onionAcquired.SetActive (false);
					pepperAcquired.SetActive (false);
				}
			} else {
				score -= 100;
			}
			Destroy (collider.gameObject);
			break;
		case "Cow":
			score -= 100;
			cowEffect = true;
			cowDuration = 0;
			Destroy (collider.gameObject);
			break;
		case "Bacon":
			if (combinationTracker == 3) {
				score += 100;
				baconAcquired.SetActive (true);
				combinationTracker++;
				if (scene.name == "Level2") {
					combinationTracker = 0;
					SceneManager.LoadScene ("Level3");
					chickenAcquired.SetActive (false);
					onionAcquired.SetActive (false);
					pepperAcquired.SetActive (false);
					baconAcquired.SetActive (false);
				}
			} else {
				score -= 100;
			}
			Destroy (collider.gameObject);
			break;
		case "Steak":
			if (combinationTracker == 4) {
				score += 100;
				steakAcquired.SetActive (true);
				combinationTracker++;
				if(scene.name == "Level3") {
					combinationTracker = 0;
					SceneManager.LoadScene ("Level4");
					chickenAcquired.SetActive (false);
					onionAcquired.SetActive (false);
					pepperAcquired.SetActive (false);
					baconAcquired.SetActive (false);
					steakAcquired.SetActive (false);
				}
			} else {
				score -= 100;
			}
			Destroy (collider.gameObject);
			break;
		case "Mushroom":
			if (combinationTracker == 5) {
				score += 100;
				mushroomAcquired.SetActive (true);
				combinationTracker++;
				if(scene.name == "Level4") {
					combinationTracker = 0;
					SceneManager.LoadScene ("WinningScene");
					chickenAcquired.SetActive (false);
					onionAcquired.SetActive (false);
					pepperAcquired.SetActive (false);
					baconAcquired.SetActive (false);
					steakAcquired.SetActive (false);
					mushroomAcquired.SetActive (false);
				}
			} else {
				score -= 100;
			}
			Destroy (collider.gameObject);
			break;
		case "Sheep":
			score -= 100;
			sheepEffect = true;
			sheepDuration = 0;
			Destroy (collider.gameObject);
			break;
		default: // Do nothing
			break;
		}
			
	}

	public void SetText() {
		scoreText.text = "Score: " + score.ToString ();
		timer.text = "Timer: " + timerLevel_1.ToString ();
	}

	public int GetScore() {
		return score;
	}

	public float GetTimerLevel1() {
		return timerLevel_1;
	}

}
