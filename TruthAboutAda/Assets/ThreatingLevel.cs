using UnityEngine;
using System.Collections;

public class ThreatingLevel : MonoBehaviour 
{
	[SerializeField]
	float maxDistance = 25f;

	[SerializeField]
	float _rumbleActive = 7f;

	GameObject[] _creeps;

	float _distance;

	PowerBarController _ref;

	float xPos;

	void Awake()
	{
		_ref = GameObject.FindGameObjectWithTag( Tags.POWERBAR ).GetComponent<PowerBarController>();
		xPos = transform.position.x;
	}

	void Start()
	{
		InvokeRepeating("calculateDistance", 0f, 0.6f);
		_distance = 100f;
	}


	void calculateDistance() 
	{
		_creeps = GameObject.FindGameObjectsWithTag( Tags.CREEP );

		if( _creeps.Length > 0 )
		{
			foreach( GameObject creep in _creeps )
			{
				float temp = xPos - creep.transform.position.x;
				if( temp < _distance ) _distance = temp;
			}
		}

		if( _distance < _rumbleActive ) GenericFXController.Get.rumbleCamera( 1f, 1f / _distance );
		_ref.SetFill( 10f / maxDistance * _distance );
	}
}
