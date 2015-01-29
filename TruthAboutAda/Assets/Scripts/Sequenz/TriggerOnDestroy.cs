using UnityEngine;

public class TriggerOnDestroy : MonoBehaviour
{
	Transform _ref;

	[SerializeField]
	GameObject target;

	void Awake()
	{
		_ref = transform.Find( Constants.ANIMATION_HOLDER );
	}

	void Update()
	{
		if( _ref == null ) Trigger();
		else if( _ref.parent != transform ) Trigger();
	}

	void Trigger()
	{
		Debug.Log("Trigger");
		target.SetActive( true );
		this.enabled = false;
	}
}