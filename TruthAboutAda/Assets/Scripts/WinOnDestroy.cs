using UnityEngine;

public class WinOnDestroy : MonoBehaviour
{
	[SerializeField]
	int setLevelOnWin = -1; // -1 for disable

	[SerializeField]
	GameObject target;

	void OnDestroy()
	{
		if( target != null ) target.SetActive( true );
		if( setLevelOnWin != -1 ) LevelProgress.Get.SetLevel( setLevelOnWin );
	}
}

