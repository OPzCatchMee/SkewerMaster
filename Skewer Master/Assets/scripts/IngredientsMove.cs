using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IngredientsMove : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Awake () {
		Scene scene = SceneManager.GetActiveScene ();
		if(scene.name == "Level1") {
			speed = 200;
		} else if(scene.name == "Level2") {
			speed = 250;
		} else if(scene.name == "Level3") {
			speed = 300;
		} else if(scene.name == "Level4") {
			speed = 500;
		}
	}

	void FixedUpdate () {
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;
	}
}
