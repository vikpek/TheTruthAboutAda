using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	[SerializeField]
	float speed = 5f;

	[SerializeField]
	float topBorder = 60;

	void FixedUpdate()
	{
		if( transform.position.y > topBorder )
		{
			Destroy( GetComponent<BoxCollider>() );
			Destroy( this );
		}
		transform.Translate( 0f, speed * Time.fixedDeltaTime, 0f );
	}
}   