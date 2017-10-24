using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIngredients : MonoBehaviour {

	// Collision detected
	void OnTriggerEnter2D(Collider2D collider) {
		Destroy (collider.gameObject);
	}
}
