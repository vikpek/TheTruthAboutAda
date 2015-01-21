using UnityEngine;
using System.Collections;

public class StartOnClick : MonoBehaviour {

	void OnMouseUpAsButton()
	{
		Application.LoadLevel( Constants.LEVEL_CUTSCENE );
	}
}
