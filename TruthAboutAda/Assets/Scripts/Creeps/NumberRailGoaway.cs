using UnityEngine;

public class NumberRailGoaway : MonoBehaviour 
{
	[SerializeField]
	float zMoveSpeed = 5f;
	[SerializeField]
	float zMoveRange = 5f;

	[SerializeField]
	float horizontalMoveSpeed = 5f;

	bool disappearLeft = true;

	bool moveBack = true;
	float zMoveDistance;

	void Start()
	{
		disappearLeft = (Random.value > 0.5f)?(true):(false);
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
	}

	public void AddObj( GameObject obj )
	{
		obj.transform.parent = transform;
	}
}
