using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	[SerializeField]
	float speed = 5f;

	[SerializeField]
	float topBorder = 60;

	bool up = true;

	void FixedUpdate () {
		if(transform.position.y > topBorder) up = false;
		if(up) transform.Translate( 0f, speed * Time.fixedDeltaTime, 0f );
	}
}   