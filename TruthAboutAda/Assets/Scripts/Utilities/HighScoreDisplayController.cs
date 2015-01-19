using UnityEngine;
using System.Collections;

public class HighScoreDisplayController : MonoBehaviour 
{
	const int DIGIT_COUNT = 6;

	Transform[] cylinders = new Transform[DIGIT_COUNT];


	void Awake()
	{
		for (int i = 0; i < DIGIT_COUNT; i++) {
			cylinders[i] = transform.FindChild ("animation_holder").FindChild ("cylinder_" + i).FindChild("animation_holder_cylinder").transform;
		}
		setHighScoreDisplayTo (876543);
	}	


	public void setHighScoreDisplayTo(int highScore)
	{
		int tmp = highScore;
		for (int i = 0; i < DIGIT_COUNT; i++) {
			cylinders [i].rotation = CylinderUtility.Get.rotateCylinder (new Vector3 (0, 0, 0), tmp % 10);
			tmp = tmp / 10;
		}
	}

	void Update()
	{
		setHighScoreDisplayTo( HighScoreManager.Get.getCurrentHighScore() );
	}
}
