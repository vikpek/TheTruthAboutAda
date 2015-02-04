using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour 
{

	// Callback Functions
	public void StartOnClick()
	{
		Application.LoadLevel("Level_01");
	}

	public void TutorialOnClick()
	{
		Application.LoadLevel(Constants.LEVEL_TUTORIAL);
	}

	public void MenuOnClick()
	{
		Application.LoadLevel(Constants.LEVEL_MENU);
	}


	public void StartArcadeOnClick()
	{
		Application.LoadLevel(Constants.LEVEL_INFINITY);
	}

	public void CreditsOnClick()
	{
		Application.LoadLevel( Constants.LEVEL_CREDITS );
	}

	public void QuitOnClick()
	{
		Application.Quit();
	}
}
