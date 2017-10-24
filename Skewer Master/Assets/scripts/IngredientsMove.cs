using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsMove : MonoBehaviour {

	public float speed; 		// Speed of the ingredients

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;

		if (GameObject.FindWithTag ("Cow"))
			pos.x -= 5.0f * Time.deltaTime;

		transform.position = pos;
	}
}
