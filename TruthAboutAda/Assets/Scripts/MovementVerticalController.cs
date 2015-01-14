using UnityEngine;
using System.Collections;

public class MovementVerticalController : MonoBehaviour {

	bool moving = false;

	[SerializeField]
	float minY = 45; 

	[SerializeField]
	float smooth = 0.1f;

	Vector3 move;
	Vector3 startPosition;

	void Awake()
	{
		move = transform.position;
		startPosition = transform.position;
	}

	void Update()
	{
		move.y = minY;
		transform.position = Vector3.MoveTowards(transform.position, move, smooth * Time.deltaTime);
	}
}
