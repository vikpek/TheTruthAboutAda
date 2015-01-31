﻿using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour 
{
	[SerializeField]
	GameObject risingText;

	public const float CREEP_POINTS = 10;

	float currentHighscore;
	float currentMultiplier;
	PowerBarController powerBarController;

	int creepCounter;
	bool winScreen;
	bool block;

	static HighScoreManager _instance;
	
	public static HighScoreManager Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<HighScoreManager>();
				_instance.powerBarController = GameObject.FindWithTag( Tags.POWERBAR ).GetComponent<PowerBarController>();
				DontDestroyOnLoad( _instance );
			}
			return _instance;
		}
	}

	void Awake()
	{
		if( _instance == null )
		{
			_instance = this;
			powerBarController = GameObject.FindWithTag( Tags.POWERBAR ).GetComponent<PowerBarController>();
			DontDestroyOnLoad( this );
		} else if( _instance != this ) Destroy( gameObject );
	}

	public void addCreeps( int numb )
	{
		creepCounter += numb;
		if( !block ) winScreen = true;
	}
 
	public void creepKilled(Vector3 position)
	{
		currentMultiplier += 1;
		currentHighscore += ( CREEP_POINTS * currentMultiplier );
//		powerBarController.FillUpValue((int) 2);
		risingText.GetComponent<RisingText>().setup("" + CREEP_POINTS + " x" + currentMultiplier, 0.1f, 0.1f);
		Instantiate(risingText, position + Vector3.down + Vector3.right * 2, Quaternion.identity);
		creepCounter--;
		Debug.Log("Creep was killed, " + creepCounter + " left in this Level" );
		if( winScreen && creepCounter == 0 ) StartCoroutine( waitAndWin( 2f ) );
	}

	IEnumerator waitAndWin( float time )
	{
		yield return new WaitForSeconds( time );
		transform.GetComponent<TheEventNoTime>().enabled = true;
	}

	public void resetCreepCounter()
	{
		creepCounter = 0;
		if( !block ) winScreen = false;
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

	public void setBlock( bool value )
	{
		block = value;
	}

}
