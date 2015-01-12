using UnityEngine;

public class Scalation : MonoBehaviour
{
	[SerializeField]
	int baseX = 1920;

	[SerializeField]
	int baseY = 1080;

	float scale;

	void Awake()
	{
		float scaleX = (float)baseX / (float)Screen.width;
		float scaleY = (float)baseY / (float)Screen.height;
		scale = ( scaleX > scaleY )?( scaleX ):( scaleY );
		foreach( Transform child in transform ) child.localScale = new Vector3( 1 / scale, 1 / scale );
	}
}
