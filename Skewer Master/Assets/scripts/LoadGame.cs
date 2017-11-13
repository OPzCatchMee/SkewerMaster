using System.Collections;
using UnityEngine;

public class LoadGame : MonoBehaviour {

	// Click the start button
	public void startGame(string level) {
		Application.LoadLevel (level);
	}
}
