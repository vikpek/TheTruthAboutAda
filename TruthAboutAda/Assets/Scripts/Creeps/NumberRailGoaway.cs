using UnityEngine;

public class NumberRailGoaway : MonoBehaviour 
{
	float zMoveSpeed = 5f;
	float zMoveRange = 8f;

	float yMoveSpeed = 3f;
	float verticalBorder = 51.51f;

	float horizontalMoveSpeed = 5f;

	bool disappearLeft = true;

	bool moveBack = true;

	float zMoveDistance;

	float yMoveDistance;
	
	bool lock0 = false;
	bool lock1 = false;

	void Start()
	{
		if( Random.value > .5f ) disappearLeft = false;
	}

	void FixedUpdate()
	{
		if( moveBack )
		{
			float move = Time.fixedDeltaTime * zMoveSpeed;
			if( zMoveDistance + move > zMoveRange )
			{
				moveBack = false;
				move = zMoveRange - zMoveDistance;
			} else zMoveDistance += move;
			transform.Translate( 0f, 0f, -move, Space.World );
		} else if( transform.position.x > -14f && transform.position.x < 14f )
		{
			float move = Time.fixedDeltaTime * horizontalMoveSpeed;
			if( !disappearLeft ) move *= -1;
			transform.Translate( move, 0f, 0f, Space.World );
		} else Destroy( gameObject );

		if( !(lock0 && lock1))
		{
			float move = Time.fixedDeltaTime * yMoveSpeed;
			
			if(verticalBorder > transform.position.y)
			{
				transform.Translate( 0f, move, 0f, Space.World );
				lock0 = true;
			}else if(verticalBorder < transform.position.y)
			{
				transform.Translate( 0f, -move, 0f, Space.World );
				lock1 = true;
			}

		}
	}
}
