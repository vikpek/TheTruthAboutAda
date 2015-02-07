using UnityEngine;

public class WinOnDestroy : MonoBehaviour
{
	[SerializeField]
	int setLevelOnWin = -1; // -1 for disable

	void OnDestroy()
	{
		GameObject temp = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER );
		if( temp != null )temp.GetComponent<UIController>().SetWin();
		if( setLevelOnWin != -1 ) LevelProgress.Get.SetLevel( setLevelOnWin );
	}
}

