using UnityEngine;

public class UIController : MonoBehaviour
{
	private enum States
	{
		None,
		Pause,
		GameOver,
		Win
	}

	private struct Buttons
	{
		public const int HEIGHT = 50;
		public const int WIDTH = 130;
		public const int GAP = 30;
	}

	States state = States.None;
	States lastState = States.None;

	[SerializeField]
	GameObject Menu;
	GameObject ContinueB;
	GameObject RestartB;
	GameObject NextLevelB;

	void Awake()
	{
		if( Menu == null ) Menu = GameObject.Find("EscapeMenu");
		ContinueB = Menu.transform.Find("Canvas/ContinueButton").gameObject;
		RestartB = Menu.transform.Find("Canvas/RestartButton").gameObject;
		NextLevelB = Menu.transform.Find("Canvas/NextLevelButton").gameObject;
		Menu.SetActive( false );
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			if( state == States.Pause ) UnpauseGame();
			else PauseGame();
		}
	}

	public void SetGameOver()
	{
		ContinueB.SetActive( false );
		RestartB.SetActive( true );
		NextLevelB.SetActive( false );
		Camera.main.GetComponent<BlurEffect>().enabled = true;
		Menu.SetActive( true );
		Screen.showCursor = true;
		lastState = state;
		Time.timeScale = 1f; // stop game (or) run in background
		state = States.GameOver;
		HighScoreManager.Get.resetCreepCounter();
		GameObject[] list = GameObject.FindGameObjectsWithTag( Tags.CREEP );
		foreach( GameObject obj in list ) obj.GetComponent<CreepController3D>().explodeMe();
	}

	public void SetWin()
	{
		Screen.showCursor = true;
		// TODO : remove presentation hack
		SetGameOver();
		/*
		ContinueB.SetActive( false );
		NextLevelB.SetActive( true );
		RestartB.SetActive( false );
		Menu.SetActive( true );
		lastState = state;
		state = States.Win;
		*/
	}

	void PauseGame()
	{
		Camera.main.GetComponent<BlurEffect>().enabled = true;
		ContinueB.SetActive( true );
		NextLevelB.SetActive( false );
		RestartB.SetActive( true );
		Menu.SetActive( true );
		lastState = state;
		Time.timeScale = 0f;
		state = States.Pause;
		Screen.showCursor = true;
	}

	public void UnpauseGame()
	{
		Camera.main.GetComponent<BlurEffect>().enabled = false;
		Menu.SetActive( false );
		state = lastState;
		Time.timeScale = 1f;
		Screen.showCursor = false;
	}

	public void RestartLevel()
	{
		Camera.main.GetComponent<BlurEffect>().enabled = false;
		lastState = state;
		Time.timeScale = 1f;
		HighScoreManager.Get.resetCreepCounter();
		Application.LoadLevel( Application.loadedLevel );
		state = States.None;
		Screen.showCursor = false;
		Menu.SetActive( false );
	}

	public void NextLevel()
	{
		Camera.main.GetComponent<BlurEffect>().enabled = false;
		lastState = state;
		Time.timeScale = 1f;
		HighScoreManager.Get.resetCreepCounter();
		Application.LoadLevel( Application.loadedLevel + 1 );
		state = States.None;
		Screen.showCursor = false;
		Menu.SetActive( false );
	}

	public void BackToMenu()
	{
		Camera.main.GetComponent<BlurEffect>().enabled = false;
		lastState = state;
		Time.timeScale = 1f;
		Application.LoadLevel( Constants.LEVEL_MENU );
		state = States.None;
		Screen.showCursor = true;
		Menu.SetActive( false );
	}
}
