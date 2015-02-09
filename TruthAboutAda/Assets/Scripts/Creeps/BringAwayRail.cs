using UnityEngine;

public class BringAwayRail : MonoBehaviour
{
	float speed = 5f;

	float yBoarder = 51.55f;
	float zBoarder = 9.51f;
	float xBoarder = 16.5f;

	Vector3 target;

	int mode = 0; // 0 - Z/X, 1 - Y, 2 - X

	void Awake()
	{
		target = new Vector3( 0f, transform.localPosition.y, zBoarder );
	}
		
	void FixedUpdate()
	{
		transform.localPosition = Vector3.MoveTowards( transform.localPosition, target, Time.fixedDeltaTime * speed );
		if( Mathf.Abs( Vector3.Distance( transform.localPosition, target ) ) <= 0.1f )
		{
			if( mode == 0 ) target = new Vector3( 0f, yBoarder, zBoarder );
			else if( mode == 1 ) target = new Vector3( ( Random.Range( 0, 1 ) == 1 )?( xBoarder ):( -xBoarder ), yBoarder, zBoarder );
			else Destroy( gameObject );
			mode++;
		}
	}
}