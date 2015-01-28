using UnityEngine;
using System.Collections;

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
	}

	public void addCreeps( int numb )
	{
		creepCounter += numb;
		winScreen = true;
	}
 
	public void creepKilled()
	{
		currentMultiplier += 1;
		currentHighscore += ( CREEP_POINTS * currentMultiplier );
		creepCounter--;
		Debug.Log("Creep was killed, " + creepCounter + " left in this Level" );
		if( winScreen && creepCounter == 0 ) StartCoroutine( waitAndWin( 2f ) );
	}

	IEnumerator waitAndWin( float time )
	{
		yield return new WaitForSeconds( time );
		GameObject.FindWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>().SetWin();
	}

	public void resetCreepCounter()
	{
		creepCounter = 0;
		winScreen = false;
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
