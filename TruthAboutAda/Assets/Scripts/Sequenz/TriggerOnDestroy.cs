using UnityEngine;
using System.Collections;

public class TriggerOnDestroy : MonoBehaviour
{
	[SerializeField]
	bool disableRefCheck = false;

	Transform _ref;

	[SerializeField]
	GameObject target;

	[SerializeField]
	GameObject hide;

	void Awake()
	{
		_ref = transform.Find( Constants.ANIMATION_HOLDER );
	}

	void Update()
	{
		if (!disableRefCheck)
		{
			if (_ref == null) Trigger ();
			else if (_ref.parent != transform)Trigger ();
		}
	}

	void Trigger()
	{
		if( target != null ) target.SetActive( true );
		if( hide != null ) hide.BroadcastMessage( "Disappear", SendMessageOptions.DontRequireReceiver );
		this.enabled = false;
	}	

	void OnDestroy()
	{
		Trigger();
	}
}