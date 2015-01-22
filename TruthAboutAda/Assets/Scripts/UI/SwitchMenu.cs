using UnityEngine;

public class SwitchMenu : MonoBehaviour
{
	[SerializeField]
	float time = 1f;

	void Update()
	{
		time -= Time.deltaTime;
		if( time <= 0f ) Application.LoadLevel( Constants.LEVEL_MENU );
	}
}