using UnityEngine;

public class HighScoreManager : MonoBehaviour 
{
	public const float CREEP_POINTS = 10;

	float currentHighscore;
	float currentMultiplier;

	int creepCounter;
	bool winScreen;

	static HighScoreManager _instance;
	
	public static HighScoreManager Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<HighScoreManager>();
				DontDestroyOnLoad (_instance);
			}
			return _instance;
		}
	}

	void Awake()
	{
		if( _instance == null )
		{
			_instance = this;
			DontDestroyOnLoad( this );
		} else if( _instance != this ) Destroy( gameObject );
		OnLevelWasLoaded ();
	}

	void OnLevelWasLoaded()
	{
		creepCounter = GameObject.FindGameObjectsWithTag( Tags.CREEP ).Length;
		Debug.Log("New Scene loaded with " + creepCounter );
		if( creepCounter != 0 ) winScreen = true; 
	}
 
	public void creepKilled()
	{
		currentMultiplier += 1;
		currentHighscore += ( CREEP_POINTS * currentMultiplier );
		creepCounter--;
		Debug.Log("Creep was killed");
		if( winScreen && creepCounter == 0 ) GameObject.FindWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>().SetWin();
	}

	public void shotFailed()
	{
		currentMultiplier = 0;
	}

	public int getCurrentHighScore()
	{
		return (int) currentHighscore;
	}

	public int getCurrentMultiplier()
	{
		return (int) currentMultiplier;
	}

}
