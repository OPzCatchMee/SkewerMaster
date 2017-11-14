using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Spawning : MonoBehaviour {

	int randomNum;			// Choose random objects being thrown
	int randomLane;				// Choose random lane
	float lane;
	int minimum;
	int maximum;

	public float spawnTime;
	public float repeatSpawn;
	public GameObject chicken;
	public GameObject onion;
	public GameObject pepper;
	public GameObject cow;
	public GameObject bacon;
	public GameObject steak;
	public GameObject mushroom;
	public GameObject sheep;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawningIngredients", spawnTime, repeatSpawn);

		Scene scene = SceneManager.GetActiveScene ();
		if(scene.name == "Level1") {
			minimum = 1;
			maximum = 5;
		} else if(scene.name == "Level2") {
			minimum = 1;
			maximum = 6;
		} else if(scene.name == "Level3") {
			minimum = 1;
			maximum = 7;
		} else if(scene.name == "Level4") {
			minimum = 1;
			maximum = 9;
		}
	}

	void SpawningIngredients() {
		randomNum = Random.Range (minimum, maximum);
		randomLane = Random.Range (1, 6);
		lane = getLane (randomLane);

		switch (randomNum) {
		case 1:				// Chicken
			Instantiate (chicken, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 2:				// Onion
			Instantiate (onion, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 3:				// Pepper
			Instantiate (pepper, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 4:				// Cow
			Instantiate (cow, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 5:				// Bacon
			Instantiate (bacon, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 6:				// Steak
			Instantiate (steak, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 7:				//Mushroom
			Instantiate (mushroom, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		case 8:				//Sheep
			Instantiate (sheep, new Vector2 (Screen.width, lane), Quaternion.identity);
			break;
		default:
			break;
		}

	}

	float getLane(int randomLane) {
		switch(randomLane) {
		case 1:
			return Screen.height / 1.6f;
			break;
		case 2:
			return Screen.height / 2.6f;
			break;
		case 3:
			return Screen.height / 3.6f;
			break;
		case 4:
			return Screen.height / 4.6f;
			break;
		case 5:
			return Screen.height / 5.6f;
			break;
		default:
			return Screen.height / 5.6f;
			break;
		}
	}
}
