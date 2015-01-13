using UnityEngine;

public class Scalation : MonoBehaviour
{
	[SerializeField]
	GameObject baseLayer;

	float scale;

	void Awake()
	{
		Vector2 temp = baseLayer.GetComponent<RectTransform>().sizeDelta;
		float scaleX = temp.x / (float)Screen.width;
		float scaleY = temp.y / (float)Screen.height;
		scale = ( scaleX >= scaleY )?( scaleX ):( scaleY );
		foreach( Transform child in transform ) child.localScale = new Vector3( 1 / scale, 1 / scale );
	}
}
