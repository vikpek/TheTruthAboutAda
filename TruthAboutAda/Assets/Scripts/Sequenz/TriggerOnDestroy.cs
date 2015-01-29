using UnityEngine;

public class TriggerOnDestroy : MonoBehaviour
{
	Transform _ref;

	[SerializeField]
	GameObject target;

	[SerializeField]
	float waitTime = 0f;

	float lastTime;
	float time;

	bool trigger;

	void Awake()
	{
		_ref = transform.Find( Constants.ANIMATION_HOLDER );
	}

	void Start()
	{
		lastTime = Time.realtimeSinceStartup;
	}

	void Update()
	{
		if( trigger )
		{
			time = Time.realtimeSinceStartup - lastTime;
			if( time > 0.1f ) time = 0.1f;
			lastTime = Time.realtimeSinceStartup;
			waitTime -= time;
			if( time <= 0f ) Trigger();
		} else {
			if( _ref == null ) trigger = true;
			else if( _ref.parent != transform ) trigger = true;
		}
	}

	void Trigger()
	{
		Debug.Log("Trigger");
		target.SetActive( true );
		this.enabled = false;
	}
}