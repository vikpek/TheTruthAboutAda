using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

	public const float CREEP_POINTS = 10;

	float currentHighscore = 0;
	float currentMultiplier = 0;

	static HighScoreManager _instance;
	
	public static HighScoreManager Get {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<HighScoreManager> ();
				DontDestroyOnLoad (_instance);
				_instance.init ();
			}
			return _instance;
		}
	}

	void init()
	{
		
	}
 
	public void creepKilled()
	{
		currentMultiplier += 1;
		currentHighscore += (CREEP_POINTS * currentMultiplier);
		Debug.Log ("Highscore: " + currentHighscore + " Multiplayer: " + currentMultiplier);
	}

	public void shotFailed()
	{
		currentMultiplier = 0;
	}

	void railCleaned()
	{

	}

	//TODO new level
}
