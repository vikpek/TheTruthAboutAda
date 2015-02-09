using UnityEngine;

public class ModPanelShooting : MonoBehaviour
{
	[SerializeField]
	bool disablePanelShooting;
	
	[SerializeField]
	float waitTime = 1f;
	
	float lastTime;
	float time;

	PanelShooting _ref;

	void Awake()
	{
		_ref = GameObject.Find("Panel2.0").GetComponent<PanelShooting>();
	}
	
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
				_ref.SetShootDisable( disablePanelShooting );
				enabled = false;
			}
		}
	}
}