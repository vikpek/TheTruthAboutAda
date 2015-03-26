using UnityEngine;
using System.Collections;


//this is really necessary because the eventcallback script is dependent to the secene. which sucks :)
public class BackToMainMenu : MonoBehaviour {


	public void BackToMainMenuOnClick()
	{
		Application.LoadLevel("Menu");
	}
}
