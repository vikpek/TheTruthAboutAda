using UnityEngine;
using System.Collections;

public class MovementVerticalController : MonoBehaviour {

	bool moving;

	[SerializeField]
	float minY = 45; 

	public float smooth = 5f;

	Vector3 move;
	Vector3 startPosition;

	void Awake()
	{
		move = transform.position;
		startPosition = transform.position;
	}

	void FixedUpdate()
	{
		move.y = minY;
		transform.position = Vector3.MoveTowards(transform.position, move, smooth * Time.fixedDeltaTime);
	}
}