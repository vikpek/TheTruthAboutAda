using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerBarController : MonoBehaviour {

	public const float MAX_FILLSTATE = 10;

	Image bar;

	float fillState = 0f;

	bool _lock;

	public void FillUpValue(int value)
	{
		if((value + fillState) < MAX_FILLSTATE)
		{
			fillState += value;
		} else {
			fillState = MAX_FILLSTATE;
		}

		syncFillState ();
	}

	void syncFillState ()
	{
		Quaternion newRotation = transform.rotation;
		//HACK no idea why 0.09f works... but it does.
		newRotation.z = 0.09f * fillState;
		transform.rotation = newRotation;
	}

	public void ResetFillState()
	{
		fillState = 0f;
		syncFillState();
	}

	public bool Filled()
	{
		if(fillState == MAX_FILLSTATE)
		{
			ResetFillState();
			return true;
		} else {
			return false;
		}
	}
}
