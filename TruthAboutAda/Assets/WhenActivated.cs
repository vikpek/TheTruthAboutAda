using UnityEngine;
using System.Collections;

public class WhenActivated : MonoBehaviour {

	// Use this for initialization
	void OnEnable() {
		Debug.Log ("Highscore enabled");
		HighScoreManager.Get.prepareHighScore();
	}
}
