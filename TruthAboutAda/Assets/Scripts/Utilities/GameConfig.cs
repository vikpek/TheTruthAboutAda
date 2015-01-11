using UnityEngine;

public class GameConfig : MonoBehaviour {

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
			DontDestroyOnLoad( this );
		} else if( this != _instance ) Destroy( gameObject );
	}

	// CONFIG
	public bool ShowEnemyCollisionPoints;

	public bool DebugPannelShooting;
}