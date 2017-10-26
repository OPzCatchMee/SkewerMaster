using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

	int randomNum;			// Choose random objects being thrown
	int lane;				// Choose random lane

	public int minimum;
	public int maximum;
	public float spawnTime;
	public float repeatSpawn;
	public GameObject chicken;
	public GameObject onion;
	public GameObject pepper;
	public GameObject cow;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawningIngredients", spawnTime, repeatSpawn);
	}

	void SpawningIngredients() {
		randomNum = Random.Range (minimum, maximum);
		lane = Random.Range (-4, 1);

		switch (randomNum) {
		case 1:				// Chicken
			Instantiate (chicken, new Vector2 (40.0f, lane), Quaternion.identity);
			break;
		case 2:				// Onion
			Instantiate (onion, new Vector2 (40.0f, lane), Quaternion.identity);
			break;
		case 3:				// Pepper
			Instantiate (pepper, new Vector2 (40.0f, lane), Quaternion.identity);
			break;
		case 4:				// Cow
			Instantiate (cow, new Vector2 (40.0f, lane), Quaternion.identity);
			break;
		case 5:				// Pork
			
			break;
		case 6:				// Steak
			
			break;
		case 7:				//Mushroom
			
			break;
		default:
			break;
		}

	}
}
