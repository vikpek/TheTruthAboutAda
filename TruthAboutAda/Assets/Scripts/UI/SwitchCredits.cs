using UnityEngine;

public class SwitchCredits : MonoBehaviour
{
	[SerializeField]
	float time = 1f;
	
	void Update()
	{
		time -= Time.deltaTime;
		if( time <= 0f ) Application.LoadLevel( "Credits" );
	}
}