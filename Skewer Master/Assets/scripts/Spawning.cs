using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Spawning : MonoBehaviour {

	int randomNum;			// Choose random objects being thrown
	int randomLane;				// Choose random lane
	float lane;
	int minimum;
	int maximum;

	private AudioSource audio;

	public AudioClip audioGrandmaPower;
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
	public GameObject soysauce;
	public GameObject grandma;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
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
			maximum = 8;
		} else if(scene.name == "Level4") {
			minimum = 1;
			maximum = 11;
		}
	}

	void SpawningIngredients() {
		randomNum = Random.Range (minimum, maximum);
		randomLane = Random.Range (1, 6);
		lane = getLane (randomLane);

		switch (randomNum) {
		case 1:				// Chicken
			GameObject ingredientChicken = Instantiate (chicken, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientChicken.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 2:				// Onion
			GameObject ingredientOnion = Instantiate (onion, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientOnion.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 3:				// Pepper
			GameObject ingredientPepper = Instantiate (pepper, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientPepper.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 4:				// Cow
			GameObject ingredientCow = Instantiate (cow, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientCow.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 5:				// Bacon
			GameObject ingredientBacon = Instantiate (bacon, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientBacon.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 6:				// Steak
			GameObject ingredientSteak = Instantiate (steak, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientSteak.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 7:				//Soy Sauce
			GameObject ingredientSoySauce = Instantiate (soysauce, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientSoySauce.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 8:				//Mushroom
			GameObject ingredientMushroom = Instantiate (mushroom, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientMushroom.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 9:				//Sheep
			GameObject ingredientSheep = Instantiate (sheep, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientSheep.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		case 10:				//Old lady
			audio.PlayOneShot(audioGrandmaPower);
			GameObject ingredientOldLady = Instantiate (grandma, new Vector2 (Screen.width, lane), Quaternion.identity) as GameObject;
			ingredientOldLady.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			break;
		default:
			break;
		}

	}

	float getLane(int randomLane) {
		float tempLane;

		switch(randomLane) {
		case 1:  // 206.25 differences for each lane   825
			tempLane = 175f;
			break;
		case 2:
			tempLane = -31.25f;
			break;
		case 3:
			tempLane = -237.5f;
			break;
		case 4:
			tempLane = -443.75f;
			break;
		case 5:
			tempLane = -650f;
			break;
		default:
			tempLane = -650f;
			break;
		}
		return tempLane;
	}
}
