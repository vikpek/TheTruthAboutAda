using UnityEngine;

public class ThreatingLevel : MonoBehaviour 
{
	float maxDistance = 17f;
	
	float _rumbleActive = 7f;

	GameObject[] _creeps;

	float _distance;

	PowerBarController _ref;

	float yPos;

	void Awake()
	{
		_ref = GameObject.FindGameObjectWithTag( Tags.POWERBAR ).GetComponent<PowerBarController>();
		yPos = transform.position.y;
	}

	void Start()
	{
		InvokeRepeating("calculateDistance", 0f, 0.5f);
	}


	void calculateDistance() 
	{
		_creeps = GameObject.FindGameObjectsWithTag( Tags.CREEP );
		_distance = maxDistance;
		if( _creeps.Length > 0 )
		{
			foreach( GameObject creep in _creeps )
			{
				float temp = creep.transform.position.y - yPos;
				if( temp < _distance ) _distance = temp;
			}
		}
		Debug.Log( _distance );
		if( _distance < _rumbleActive ) GenericFXController.Get.rumbleCamera( 1f, 0.7f / _distance );
		_ref.SetFill( 10f / maxDistance * ( maxDistance - _distance ) );
	}
}