using UnityEngine;
using System.Collections;

public class UIScale : MonoBehaviour
{
	[SerializeField]
	GameObject baseLayer;
	
	float scale;
	
	void Awake()
	{
		Vector2 temp = baseLayer.GetComponent<RectTransform>().sizeDelta;
		GetComponent<UnityEngine.UI.CanvasScaler>().matchWidthOrHeight = ( temp.x / (float)Screen.width >= temp.y / (float)Screen.height )?( 0f ):( 1f );
	}
}