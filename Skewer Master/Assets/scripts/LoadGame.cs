using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour {

	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// Click the start button
	void TaskOnClick() {
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene ("Level1");
	}
}
