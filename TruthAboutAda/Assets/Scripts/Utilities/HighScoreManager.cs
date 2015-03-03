using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour 
{
	[SerializeField]
	GameObject risingText;

	public const float CREEP_POINTS = 10;
	public const float DAMAGE_POINTS = 5;

	string playerName = "";

	float currentHighscore;
	float currentMultiplier;

	GameObject highScoreObject;

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
			highScoreObject = GameObject.FindGameObjectWithTag ("HighScoreText");
			DontDestroyOnLoad( this );
		} else if( _instance != this ) Destroy( gameObject );
	}
 
	public void creepKilled(Vector3 position)
	{
		ShowScoreText (position, CREEP_POINTS);
	}

	public void creepDamaged(Vector3 position)
	{
		ShowScoreText (position, DAMAGE_POINTS);
	}

	void ShowScoreText (Vector3 position, float score)
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

	public void prepareHighScore()
	{
		if(highScoreObject){
			StartCoroutine(PrintDelayed());
		}


	}

	IEnumerator PrintDelayed()
	{
		yield return new WaitForSeconds(2f);
		PrintScore();
		ShowSubmissionInterface();
	}

	void ShowSubmissionInterface ()
	{
		if(highScoreObject)
		{
			Transform[] transforms = highScoreObject.gameObject.GetComponentsInChildren<Transform>();
			foreach(Transform t in transform)
			{
				t.gameObject.SetActive(true);
			}

			Button submitButton = highScoreObject.gameObject.GetComponentsInChildren<Button>()[0];
			Text playerNameTextField = highScoreObject.gameObject.GetComponentsInChildren<Text>()[0];

			playerName = playerNameTextField.text;

			submitButton.onClick.AddListener(processNewHighScore);
		}
	}

	void processNewHighScore ()
	{
		addHighscore(playerName, getCurrentHighScore());
		StartCoroutine(PrintDelayed());
	}
	

	private void PrintScore ()
	{
		if(highScoreObject)
		{
			 Text highScoreText = highScoreObject.GetComponent<Text>();
		
			string output = "";
			int i;
			for (i = 0; i < 10; i++) {
				output = output + PlayerPrefs.GetInt (i + "HScore");
				output = output + PlayerPrefs.GetString (i + "HScoreName");
				output = output + "\n";
			}
			highScoreText.text = output;
			highScoreText.enabled = true;
		}
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