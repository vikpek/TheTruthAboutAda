using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour 
{

	// Callback Functions
	public void StartOnClick()
	{
		Application.LoadLevel(Constants.LEVEL_TUTORIAL);
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
