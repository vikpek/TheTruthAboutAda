using UnityEngine;

public class GameConfig : MonoBehaviour
{
		// singleton
		static GameConfig _instance;
	
		public static GameConfig Get {
				get {
						if (_instance == null) {
								_instance = GameObject.FindObjectOfType<GameConfig> ();
								DontDestroyOnLoad (_instance);
						}
						return _instance;
				}
		}
	
		void Awake ()
		{
				if (_instance == null) {
						_instance = this;
						DontDestroyOnLoad (this);
				} else if (this != _instance)
						Destroy (gameObject);
		}

		void OnLevelWasLoaded (int level)
		{
				if (GameObject.FindWithTag ("GammaLight")) {
						Light gammaLight = GameObject.FindWithTag ("GammaLight").GetComponent<Light> ();
						if (gammaLight) {
								gammaLight.intensity = BrightnessValue ();
								Debug.Log ("starting with gamma: " + gammaLight.intensity);
						}
				}
		}

		// CONFIG
		public bool ShowEnemyCollisionPoints;
		public bool DebugPannelShooting;

		public void SetBrightnessTo (float brightness)
		{
//				Debug.Log ("brightness " + brightness);
				PlayerPrefs.SetFloat ("brightness_value", brightness);
		}

		public float BrightnessValue ()
		{
				return PlayerPrefs.GetFloat ("brightness_value");
		}

		public float ArcadeDifficulty ()
		{
				return PlayerPrefs.GetFloat ("difficulty_value");
		}

		public void SetArcadeDifficulty (float difficulty)
		{
				Debug.Log ("difficulty " + difficulty);
				PlayerPrefs.SetFloat ("difficulty_value", difficulty);
		}
}