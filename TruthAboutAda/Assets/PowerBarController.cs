using UnityEngine;

public class PowerBarController : MonoBehaviour
{
	const float MAX_FILLSTATE = 10f;

	const float STEP = 21.5f;

	float fillState;

	public void SetFill( float value )
	{
		if( value < 0 ) fillState = 0f;
		else if( value > MAX_FILLSTATE ) fillState = MAX_FILLSTATE;
		else fillState = value;
		syncFillState();
	}

	void syncFillState()
	{
		transform.rotation = Quaternion.Euler( 0, 0, 252f + STEP * fillState );
	}
}