using UnityEngine;

public class WinOnDestroy : MonoBehaviour
{

	void OnDestroy()
	{
		GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>().SetWin();
	}
}

