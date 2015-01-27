using UnityEngine;

public class Shaking : MonoBehaviour 
{
	[SerializeField]
	int repeatSpeed = 10; // Change State every XX fixedUpdate (50/s)
	int repearCounter;
	bool swap;

	[SerializeField]
	float shakeStrength = 2.5f; // multiply by 0.01

	[SerializeField]
	bool useRotation = true;

	Transform _ref;

	void Awake()
	{
		_ref = transform.Find( Constants.ANIMATION_HOLDER );
	}


	void FixedUpdate() 
	{
		repearCounter++;
		if( repearCounter >= repeatSpeed )
		{
			if( useRotation ) _ref.localRotation = Quaternion.Euler( ( swap )?( shakeStrength ):( -shakeStrength ), 0f, 0f );
			else _ref.localPosition = new Vector3( ( swap )?( shakeStrength * 0.01f ):( -shakeStrength * 0.01f ), 0f, 0f ) ;
			repearCounter -= repeatSpeed;
			swap = !swap;
		}
	}
}
