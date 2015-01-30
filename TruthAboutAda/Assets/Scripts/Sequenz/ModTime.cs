using UnityEngine;

public class ModTime : MonoBehaviour
{
	[SerializeField]
	bool disableTime;

	[SerializeField]
	float waitTime = 1f;

	float lastTime;
	float time;

	void Start()
	{
		lastTime = Time.realtimeSinceStartup;
	}

	void Update()
	{
		if( waitTime >= 0 )
		{
			time = Time.realtimeSinceStartup - lastTime;
			if( time > 0.1f ) time = 0.1f;
			lastTime = Time.realtimeSinceStartup;
			waitTime -= time;
			if( waitTime <= 0f )
			{
				Time.timeScale = ( disableTime )?( 0f ):( 1f );
				gameObject.SetActive( false );
			}

		}
	}
}