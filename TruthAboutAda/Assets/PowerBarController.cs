using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerBarController : MonoBehaviour {

	public const float MAX_FILLSTATE = 10;
	Image bar;

	float fillState = 0f;

	public void Start()
	{
		bar = GameObject.FindWithTag(Tags.POWERBAR).GetComponent<Image>();
	}

	public void FillUpValue(int value)
	{
		if((value + fillState) < MAX_FILLSTATE)
		{
			fillState += value;
		} else {
			fillState = MAX_FILLSTATE;
		}

		//HACK will only work for MAX_FILLSTATE == 10. 
		bar.fillAmount = fillState * 0.1f;
	}

	void resetFillState()
	{
		fillState = 0f;
	}

	public void Filled()
	{
		if(fillState == MAX_FILLSTATE)
		{
			resetFillState();
			return true;
		} else {
			return false;
		}
	}
}
