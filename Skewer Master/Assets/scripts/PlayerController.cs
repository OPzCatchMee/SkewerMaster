using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Vector3 move = Vector3.zero;
	float duration;					// duration of the effect
	static float score;

	bool cowEffect;					// make the key reverse

	string []combinationLevel1;			// Determines if the player has all the food for level 1
	string []combinationLevel2;			// Determines if the player has all the food for level 2
	string []combinationLevel3;			// Determines if the player has all the food for level 3

	public Text scoreText;				// Displays the score
	public float offsetY;			// How much space player is moving

	// Use this for initialization
	void Start () {
		cowEffect = false;
		SetScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		duration += Time.deltaTime;
		if (cowEffect) {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (transform.position.y >= 0) {
					move.y = 0;
					transform.position = move;
				} else {
					move.y = offsetY;
					transform.position += move;
				}
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (transform.position.y <= -4) {
					move.y = -4;
					transform.position = move;
				} else {
					move.y = offsetY;
					transform.position -= move;
				}
			}
			if (duration >= 5) {		// Stop the cow effect
				cowEffect = false;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (transform.position.y >= 0) {
					move.y = 0;
					transform.position = move;
				} else {
					move.y = offsetY;
					transform.position += move;
				}
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (transform.position.y <= -4) {
					move.y = -4;
					transform.position = move;
				} else {
					move.y = offsetY;
					transform.position -= move;
				}
			}
		}
			
	}

	// Collision detected - Update score/ trigger object effects
	void OnTriggerEnter2D(Collider2D collider) {
		switch (collider.gameObject.tag) {
		case "Chicken":
			score += 100;
			Destroy (collider.gameObject);
			break;
		case "Onion":
			score += 50;
			Destroy (collider.gameObject);
			break;
		case "Pepper":
			score += 25;
			Destroy (collider.gameObject);
			break;
		case "Cow":
			score -= 100;
			cowEffect = true;
			duration = 0;
			Destroy (collider.gameObject);
			break;
		case "Pork":
			Destroy (collider.gameObject);
			break;
		case "Steak":
			Destroy (collider.gameObject);
			break;
		case "Mushroom":
			Destroy (collider.gameObject);
			break;
		default: // Do nothing
			break;
		}
			
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString ();
	}

}
