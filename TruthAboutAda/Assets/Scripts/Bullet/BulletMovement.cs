using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	[SerializeField]
	float speed = 5f;

	void FixedUpdate () {
		transform.Translate( 0f, speed * Time.fixedDeltaTime, 0f );
	}
}   