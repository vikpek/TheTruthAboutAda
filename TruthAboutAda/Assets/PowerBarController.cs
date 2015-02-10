using UnityEngine;

public class PowerBarController : MonoBehaviour
{
	const float MAX_FILLSTATE = 10f;

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
		transform.rotation = Quaternion.Euler( 0, 0, 250 + 21.5f * fillState );
	}
}