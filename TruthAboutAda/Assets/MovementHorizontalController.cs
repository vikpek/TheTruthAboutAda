using UnityEngine;
using System.Collections;

public class MovementHorizontalController : MonoBehaviour {

	bool moving = false;

	float minX = -10; 
	float maxX = 7;

	[SerializeField]
	float smooth = 0.1f;

	[SerializeField]
	bool lerp = true;


	
	Vector3 move;
	Vector3 startPosition;

	[SerializeField]
	bool directionRight = true;
	
	void Awake()
	{
		move = transform.localPosition;
//		startPosition = transform.localPosition;

		minX = transform.parent.FindChild("HorizontalRail").FindChild("right_border").transform.position.x;
		maxX = transform.parent.FindChild("HorizontalRail").FindChild("left_border").transform.position.x;



	}

	void Update()
	{	
		if (!(transform.localPosition.x > minX && transform.localPosition.x < maxX)) directionRight = !directionRight;
	
		if (directionRight) 
		{
			move.x = maxX;
		} else if (!directionRight) 
		{
			move.x = minX;
		}

		if (lerp) {
				transform.localPosition = Vector3.Lerp (transform.localPosition, move, smooth * Time.deltaTime);
		} else {
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, move, smooth * Time.deltaTime);
		}

	}

	void OnTriggerEnter( Collider col )
	{
		directionRight = !directionRight;
	}
}
