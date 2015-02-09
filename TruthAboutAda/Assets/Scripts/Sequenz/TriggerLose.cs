using UnityEngine;

public class TriggerLose : MonoBehaviour 
{
	UIController _ref;
	
	[SerializeField]
	float waitTime = 1f;
	
	float lastTime;
	float time;
	
	void Start()
	{
		lastTime = Time.realtimeSinceStartup;
	}
	
	void Awake()
	{
		_ref = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>();
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
				_ref.SetGameOver();
				enabled = false;
			}
		}
	}
}
