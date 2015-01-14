using UnityEngine;
using System.Collections;

public class MovementVerticalController : MonoBehaviour {

	bool moving = false;

	[SerializeField]
	float minY = 45; 

	[SerializeField]
	float smooth = 5f;

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
		//FIXME Rows holen sich ein
		transform.position = Vector3.MoveTowards(transform.position, move, smooth * Time.deltaTime);
	}
}
