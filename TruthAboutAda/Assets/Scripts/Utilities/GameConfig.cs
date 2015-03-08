using UnityEngine;

public class GameConfig : MonoBehaviour {

	float brightnessValue;
	float arcadeDifficulty;

	// singleton
	static GameConfig _instance;
	
	public static GameConfig Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<GameConfig>();
				DontDestroyOnLoad( _instance );
			}
			return _instance;
		}
	}
	
	void Awake()
	{
		if( _instance == null ) // First Instance
		{
			_instance = this;
			brightnessValue = 0.5f;
			arcadeDifficulty = 1;
			DontDestroyOnLoad( this );
		} else if( this != _instance ) Destroy( gameObject );
	}

	// CONFIG
	public bool ShowEnemyCollisionPoints;

	public bool DebugPannelShooting;

	public void SetBrightnessTo(float brightness)
	{
		brightnessValue = brightness;
	}

	public float BrightnessValue()
	{
		return brightnessValue;
	}

	public float ArcadeDifficulty()
	{
		return arcadeDifficulty;
	}

	public void SetArcadeDifficulty(float difficulty)
	{
		arcadeDifficulty = difficulty;
	}
}