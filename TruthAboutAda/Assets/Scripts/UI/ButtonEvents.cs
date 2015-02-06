using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour 
{
	GameObject[] buttons;

	LevelProgress progress;

	UnityEngine.EventSystems.EventSystem ev;

	void Awake()
	{
		progress = LevelProgress.Get;
		ev = GameObject.FindObjectOfType<UnityEngine.EventSystems.EventSystem>();
		buttons = new GameObject[13];
		buttons[0] = GameObject.Find( "TutorialButton" );
		buttons[1] = GameObject.Find( "StartButton" );
		buttons[2] = GameObject.Find( "LevelButton" );
		buttons[3] = GameObject.Find( "ArcadeButton" );
		buttons[4] = GameObject.Find( "CreditsButton" );
		buttons[5] = GameObject.Find( "EndButton" );
		buttons[6] = GameObject.Find( "Level01Button" );
		buttons[7] = GameObject.Find( "Level02Button" );
		buttons[8] = GameObject.Find( "Level03Button" );
		buttons[9] = GameObject.Find( "Level04Button" );
		buttons[10] = GameObject.Find( "Level05Button" );
		buttons[11] = GameObject.Find( "Level06Button" );
		buttons[12] = GameObject.Find( "BackButton" );
		BackToMainMenu();
	}

	// Callback Functions
	public void LoadLevel1()
	{
		Application.LoadLevel( "Level_01" );
	}

	public void LoadLevel2()
	{
		Application.LoadLevel( "Level_02" );
	}

	public void LoadLevel3()
	{
		Application.LoadLevel( "Level_03" );
	}

	public void LoadLevel4()
	{
		Application.LoadLevel( "Level_04" );
	}

	public void LoadLevel5()
	{
		Application.LoadLevel( "Level_05" );
	}

	public void LoadLevel6()
	{
		Application.LoadLevel( "Level_06" );
	}

	public void TutorialOnClick()
	{
		Application.LoadLevel( Constants.LEVEL_TUTORIAL );
	}

	public void MenuOnClick()
	{
		Application.LoadLevel( Constants.LEVEL_MENU );
	}

	public void StoryOnClick()
	{
		Application.LoadLevel( Constants.LEVEL_LEVEL01 );
	}

	public void StartArcadeOnClick()
	{
		Application.LoadLevel( Constants.LEVEL_INFINITY );
	}

	public void CreditsOnClick()
	{
		Application.LoadLevel( Constants.LEVEL_CREDITS );
	}

	public void QuitOnClick()
	{
		Application.Quit();
	}

	public void BackToMainMenu()
	{
		buttons[0].SetActive( true );
		buttons[1].SetActive( true );
		buttons[2].SetActive( true );
		buttons[3].SetActive( true );
		buttons[4].SetActive( true );
		buttons[5].SetActive( true );
		buttons[6].SetActive( false );
		buttons[7].SetActive( false );
		buttons[8].SetActive( false );
		buttons[9].SetActive( false );
		buttons[10].SetActive( false );
		buttons[11].SetActive( false );
		buttons[12].SetActive( false );
		ev.SetSelectedGameObject( buttons[0] );
	}

	public void ShowLevelMenu()
	{
		buttons[0].SetActive( false );
		buttons[1].SetActive( false );
		buttons[2].SetActive( false );
		buttons[3].SetActive( false );
		buttons[4].SetActive( false );
		buttons[5].SetActive( false );
		buttons[6].SetActive( true ); // lv1
		buttons[7].SetActive( true ); // lv2
		buttons[7].GetComponent<Button>().interactable = progress.GetLevel( 1 );
		buttons[7].GetComponentInChildren<Text>().color = new Color( 89f / 255f, 50f / 255f, 27f / 255f, ( progress.GetLevel( 1 ) )?( 1f ):( 0.5f ) );
		buttons[8].SetActive( true ); // lv3
		buttons[8].GetComponent<Button>().interactable = progress.GetLevel( 2 );
		buttons[8].GetComponentInChildren<Text>().color = new Color( 89f / 255f, 50f / 255f, 27f / 255f, ( progress.GetLevel( 2 ) )?( 1f ):( 0.5f ) );
		buttons[9].SetActive( true ); // lv4
		buttons[9].GetComponent<Button>().interactable = progress.GetLevel( 3 );
		buttons[9].GetComponentInChildren<Text>().color = new Color( 89f / 255f, 50f / 255f, 27f / 255f, ( progress.GetLevel( 3 ) )?( 1f ):( 0.5f ) );
		buttons[10].SetActive( true ); // lv5
		buttons[10].GetComponent<Button>().interactable = progress.GetLevel( 4 );
		buttons[10].GetComponentInChildren<Text>().color = new Color( 89f / 255f, 50f / 255f, 27f / 255f, ( progress.GetLevel( 4 ) )?( 1f ):( 0.5f ) );
		buttons[11].SetActive( true ); // lv6
		buttons[11].GetComponent<Button>().interactable = progress.GetLevel( 5 );
		buttons[11].GetComponentInChildren<Text>().color = new Color( 89f / 255f, 50f / 255f, 27f / 255f, ( progress.GetLevel( 5 ) )?( 1f ):( 0.5f ) );
		buttons[12].SetActive( true );
		ev.SetSelectedGameObject( buttons[6] );
	}
}
