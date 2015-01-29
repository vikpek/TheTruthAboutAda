using UnityEngine;
using System.Collections;

public class HighScoreDisplayController : MonoBehaviour 
{
	const int DIGIT_COUNT = 6;

	Transform[] cylinders = new Transform[DIGIT_COUNT];


	void Awake()
	{
		for (int i = 0; i < DIGIT_COUNT; i++) {
			cylinders[i] = transform.Find("animation_holder/cylinder_" + i + "/animation_holder_cylinder").transform;
		}

	}	


	public void setHighScoreDisplayTo(int highScore)
	{
		int tmp = highScore;
		for (int i = 0; i < DIGIT_COUNT; i++) {
			cylinders [i].rotation = CylinderUtility.Get.setCylinderToValue(tmp % 10);

			tmp = tmp / 10;
		}
	}

	void Update()
	{
		setHighScoreDisplayTo( HighScoreManager.Get.getCurrentHighScore() );
	}
}
