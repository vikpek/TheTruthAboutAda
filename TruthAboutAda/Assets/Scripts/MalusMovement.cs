using UnityEngine;

public class MalusMovement : MonoBehaviour
{

	[SerializeField]
	float maxX = 14f;

	[SerializeField]
	float minX = -14f;

	[SerializeField]
	float speed = 5f;
	
	bool right;

	void FixedUpdate()
	{
		float move = Time.fixedDeltaTime * speed;
		Vector3 pos = transform.position;
		if( right )
		{
			if( pos.x + move >= maxX )
			{
				pos.x = maxX;
				right = false;
			} else pos.x += move;
		} else
		{
			if( pos.x - move <= minX )
			{
				pos.x = minX;
				right = true;
			} else pos.x -= move;
		}
		transform.position = pos;
	}
}