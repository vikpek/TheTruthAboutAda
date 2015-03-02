using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour 
{
	[SerializeField]
	GameObject risingText;

	public const float CREEP_POINTS = 10;
	public const float DAMAGE_POINTS = 5;

	float currentHighscore;
	float currentMultiplier;

	static HighScoreManager _instance;
	
	public static HighScoreManager Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<HighScoreManager>();
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
			DontDestroyOnLoad( this );
		} else if( _instance != this ) Destroy( gameObject );
	}
 
	public void creepKilled(Vector3 position)
	{
		showScoreText (position, CREEP_POINTS);
	}

	public void creepDamaged(Vector3 position)
	{
		showScoreText (position, DAMAGE_POINTS);
	}

	void showScoreText (Vector3 position, float score)
	{
		currentMultiplier += 1;
		currentHighscore += (score * currentMultiplier);
//		powerBarController.FillUpValue((int) 2);
		risingText.GetComponent<RisingText> ().setup ("" + score + " x" + currentMultiplier, 5f, 1f, currentMultiplier);
		Instantiate (risingText, position + Vector3.down + Vector3.right * 2, Quaternion.identity);
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

	public void printHighScore()
	{
		addHighscore("FFF", getCurrentHighScore());

		Text highScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<Text>();

		string output = "";
		int i;
		for(i=0;i<10;i++){
			output = output + PlayerPrefs.GetInt(i+"HScore");
			output = output + PlayerPrefs.GetString(i+"HScoreName");
			output = output + "\n";
		}

		highScoreText.text = output;
		highScoreText.enabled = true;
	}


	public void addHighscore(string name, int score)
	{
		int newScore;
		string newName;
		int oldScore;
		string oldName;

		newScore = score;
		newName = name;

		int i;

		for(i=0;i<10;i++){
			if(PlayerPrefs.HasKey(i+"HScore")){
				if(PlayerPrefs.GetInt(i+"HScore")<newScore){ 
					// new score is higher than the stored score
					oldScore = PlayerPrefs.GetInt(i+"HScore");
					oldName = PlayerPrefs.GetString(i+"HScoreName");
					PlayerPrefs.SetInt(i+"HScore",newScore);
					PlayerPrefs.SetString(i+"HScoreName",newName);
					newScore = oldScore;
					newName = oldName;
				}
			}else{
				PlayerPrefs.SetInt(i+"HScore",newScore);
				PlayerPrefs.SetString(i+"HScoreName",newName);
				newScore = 0;
				newName = "";
			}
		}

	}
}