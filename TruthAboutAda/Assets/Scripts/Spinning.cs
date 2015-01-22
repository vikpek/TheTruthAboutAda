using UnityEngine;

public class Spinning : MonoBehaviour
{

	[SerializeField]
	float speed = 10f;

	[SerializeField]
	bool direction;

	[SerializeField]
	bool twoD;


	void Update()
	{
		if( !twoD )
		{
			if( direction ) transform.Rotate( Vector3.right, speed * Time.deltaTime );
			else transform.Rotate( Vector3.left, speed * Time.deltaTime );
		} else 
		{
			if( direction ) transform.Rotate( Vector3.back, speed * Time.deltaTime );
			else transform.Rotate( Vector3.forward, speed * Time.deltaTime );
		}
	}
}