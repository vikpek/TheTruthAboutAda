using UnityEngine;

public class TriggerOnDestroy : MonoBehaviour
{
	CreepController3D _ref;

	[SerializeField]
	GameObject target;

	void Awake()
	{
		_ref = GetComponent<CreepController3D>();
	}

	void Update()
	{
		if( _ref == null )
		{
			Debug.Log("Trigger");
			target.SetActive( true );
			this.enabled = false;
		}
	}
}