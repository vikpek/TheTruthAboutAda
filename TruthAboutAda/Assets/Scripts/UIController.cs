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

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			if( state == States.Pause )
				UnpuaseGame();
			else 
				PauseGame();
		}
	}

	void OnGUI()
	{
		Vector2 temp;
		switch( state )
		{
			case States.None :
				break;

			case States.Pause :
				temp = new Vector2( Screen.width / 2 - Buttons.WIDTH / 2, ( Screen.height / 2 ) - ( Buttons.HEIGHT * 3 + Buttons.GAP * 2 ) / 2 );
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Continue" ) ) UnpuaseGame();
				temp.y += Buttons.GAP + Buttons.HEIGHT;
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Restart Level" ) ) RestartLevel();
				temp.y += Buttons.GAP + Buttons.HEIGHT;
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Return to Menu" ) ) BackToMenu();
				break;
			case States.GameOver :
				temp = new Vector2( Screen.width / 2 - Buttons.WIDTH / 2, ( Screen.height / 2 ) - ( Buttons.HEIGHT * 2 + Buttons.GAP * 1 ) / 2 );
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Restart Level" ) ) RestartLevel();
				temp.y += Buttons.GAP + Buttons.HEIGHT;
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Return to Menu" ) ) BackToMenu();
				break;
			case States.Win :
				temp = new Vector2( Screen.width / 2 - Buttons.WIDTH / 2, ( Screen.height / 2 ) - ( Buttons.HEIGHT * 2 + Buttons.GAP * 1 ) / 2 );
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Next Level" ) ) NextLevel();
				temp.y += Buttons.GAP + Buttons.HEIGHT;
				if( GUI.Button( new Rect( temp.x, temp.y, Buttons.WIDTH, Buttons.HEIGHT ), "Return to Menu" ) ) BackToMenu();
				break;
		}
	}

	public void SetGameOver()
	{
		lastState = state;
		Time.timeScale = 0f;
		state = States.GameOver;
	}

	public void SetWin()
	{
		lastState = state;
		state = States.Win;
	}

	public void Hide()
	{
		lastState = state;
		state = States.None;
	}

	// UNDONE : Clean up

	void PauseGame()
	{
		lastState = state;
		Time.timeScale = 0f;
		state = States.Pause;
	}

	void UnpuaseGame()
	{
		state = lastState;
		Time.timeScale = 1f;
	}

	void RestartLevel()
	{
		lastState = state;
		Time.timeScale = 1f;
		Application.LoadLevel( Application.loadedLevel );
		state = States.None;
	}

	void NextLevel()
	{
		lastState = state;
		Time.timeScale = 1f;
		Application.LoadLevel( Application.loadedLevel + 1 );
		state = States.None;
	}

	void BackToMenu()
	{
		lastState = state;
		Time.timeScale = 1f;
		Application.LoadLevel( Constants.LEVEL_MENU );
		state = States.None;
	}
}
