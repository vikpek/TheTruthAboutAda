using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{

	[SerializeField]
	MovieTexture movieTexture;


	void Start () 
	{
		gameObject.renderer.material.mainTexture = movieTexture;
		movieTexture.Play ();
	}

	void Update()
	{
		if( !movieTexture.isPlaying )
		{
			Application.LoadLevel(Constants.LEVEL_LEVEL01);
		}

	}
}
