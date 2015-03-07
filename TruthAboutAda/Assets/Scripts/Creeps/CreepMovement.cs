using UnityEngine;

public class CreepMovement : MonoBehaviour
{

	[SerializeField]
	float horizontalMovementStepSize = 1.0f;
	[SerializeField]
	float verticalMovementStepSize = 1.0f;
	[SerializeField]
	float horizontalStepTime = 1f;
	[SerializeField]
	float verticalStepTime = 1f;

	[SerializeField]
	int maxStepsToSide = 3;

	bool creep = true;

	float nextMoveTime;
	int currentStep;
	bool moveRight;

	bool moving = false;
	
	void Awake()
	{
		if( name == Constants.HORIZONTALRAIL ) creep = false;
	}

	void Update()
	{

		if( nextMoveTime > 0f ) nextMoveTime -= Time.fixedDeltaTime;
		if (nextMoveTime <= 0f) {
				if (!moving) {
						moveStep ();
				}
		}
	}

	void moveStep(){
		moving = true;

		Vector3 move = new Vector3();
		if( Mathf.Abs( currentStep ) >= maxStepsToSide )
		{
			currentStep = 0;
			moveRight = !moveRight;
			nextMoveTime += verticalStepTime;
			move.y -= verticalMovementStepSize;
		} else
		{
			currentStep++;
			if( creep ) move.x += ( moveRight )?( horizontalMovementStepSize ):( -horizontalMovementStepSize );
			nextMoveTime += horizontalStepTime;
		}
		GetComponent<Rigidbody>().position = Vector3.Lerp(GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().position + move, 10000);
		moving = false;
	}
}
