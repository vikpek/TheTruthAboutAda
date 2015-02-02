using UnityEngine;

public class TriggerWin : MonoBehaviour
{
	[SerializeField]
	bool activate;

	void Start()
	{
		HighScoreManager.Get.setBlock( activate );
	}
}