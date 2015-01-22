using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour 
{

	// Callback Functions
	public void StartOnClick()
	{
		Debug.LogWarning( "First Level not set - see Constants.cs & ButtonEvents.cs" );
		//Application.LoadLevel( Constants.LEVEL_LEVEL01 );
	}

	public void CreditsOnClick()
	{
		Debug.LogWarning( "Credits Level not set - see Constants.cs & ButtonEvents.cs" );
		//Application.LoadLevel( Constants.LEVEL_CREDITS );
	}

	public void QuitOnClick()
	{
		Application.Quit();
	}
}
