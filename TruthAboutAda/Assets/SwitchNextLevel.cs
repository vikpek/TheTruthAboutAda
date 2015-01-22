using UnityEngine;
using System.Collections;

public class SwitchNextLevel : MonoBehaviour {

	float time = 1f;

	void Update()
	{
		time -= Time.deltaTime;
		if(time <= 0)
		{
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
