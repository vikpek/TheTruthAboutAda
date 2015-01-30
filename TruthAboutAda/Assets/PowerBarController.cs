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
		if(!_lock){
			if((value + fillState) < MAX_FILLSTATE)
			{
				fillState += value;
			} else {
				fillState = MAX_FILLSTATE;
			}

			Quaternion newRotation = transform.rotation;
			newRotation.z = fillState;
			transform.rotation = newRotation;
		}
	}

	public void ResetFillState()
	{
		fillState = 0f;
		// TODO tbi
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
