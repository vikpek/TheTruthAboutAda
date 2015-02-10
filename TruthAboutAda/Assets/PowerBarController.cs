using UnityEngine;
using UnityEngine.UI;

public class PowerBarController : MonoBehaviour
{
	public const float MAX_FILLSTATE = 10f;

	float fillState;

	public void AddFill( float value )
	{
		if( ( value + fillState ) > MAX_FILLSTATE ) fillState = MAX_FILLSTATE;
		else if( ( value + fillState ) < 0f ) fillState = 0f;
		else fillState += value;
		syncFillState();
	}

	public void SetFill( float value )
	{
		if( value < 0 ) fillState = 0f;
		else if( value > MAX_FILLSTATE ) fillState = MAX_FILLSTATE;
		else fillState = value;
		syncFillState();
	}

	void syncFillState()
	{
		Quaternion newRotation = transform.rotation;
		//HACK no idea why 0.09f works... but it does.
		newRotation.z = 0.09f * fillState;
		transform.rotation = newRotation;
	}
}