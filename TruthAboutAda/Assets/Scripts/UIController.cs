using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
	private enum States
	{
		None,
		Pause,
		GameOver,
		Win
	}

	States state = States.None;
	States lastState = States.None;

	[SerializeField]
	GameObject Menu;
	GameObject ContinueB;
	GameObject RestartB;
	GameObject NextLevelB;
	UnityEngine.EventSystems.EventSystem ev;

	[SerializeField]
	float waitTillTimeStop = 1.5f;

	void Awake()
	{
		if( Menu == null ) Menu = GameObject.Find("EscapeMenu");
		ContinueB = Menu.transform.Find("Canvas/ContinueButton").gameObject;
		RestartB = Menu.transform.Find("Canvas/RestartButton").gameObject;
		NextLevelB = Menu.transform.Find("Canvas/NextLevelButton").gameObject;
		ev = Menu.GetComponentInChildren<UnityEngine.EventSystems.EventSystem>();
		Menu.SetActive( false );
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Escape ) || Input.GetKeyDown( KeyCode.JoystickButton9 ) )
		{
			if( state == States.Pause ) UnpauseGame();
			else PauseGame();
		}
	}

	public void SetGameOver()
	{
		if( state != States.GameOver )
		{
			ContinueB.SetActive( false );
			RestartB.SetActive( true );
			NextLevelB.SetActive( false );
			ev.SetSelectedGameObject( RestartB );
			Camera.main.GetComponent<BlurEffect>().enabled = true;
			Menu.SetActive( true );
			Screen.showCursor = true;
			lastState = state;
			state = States.GameOver;
			GameObject[] list = GameObject.FindGameObjectsWithTag( Tags.CREEP );
			foreach( GameObject obj in list ) obj.GetComponent<CreepController3D>().explodeMe();
			Debug.Log("Lose Game");
			StartCoroutine( WaitAndStopTime( waitTillTimeStop ) );
		}
	}

	public void SetWin()
	{
		if( state != States.Win )
		{
			Screen.showCursor = true;
			ContinueB.SetActive( false );
			NextLevelB.SetActive( true );
			RestartB.SetActive( false );
			ev.SetSelectedGameObject( ContinueB );
			Menu.SetActive( true );
			lastState = state;
			state = States.Win;
			Debug.Log("Win Game");
			StartCoroutine( WaitAndStopTime( waitTillTimeStop ) );
		}
	}

	void PauseGame()
	{
		Camera.main.GetComponent<BlurEffect>().enabled = true;
		ContinueB.SetActive( true );
		NextLevelB.SetActive( false );
		RestartB.SetActive( true );
		ev.SetSelectedGameObject( ContinueB );
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

	IEnumerator WaitAndStopTime( float wait )
	{
		yield return new WaitForSeconds( wait );
		if( state == States.GameOver || state == States.Win ) Time.timeScale = 0f;
	}
}
