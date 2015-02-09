using UnityEngine;

public class Scalation : MonoBehaviour
{
	[SerializeField]
	GameObject baseLayer;

	[SerializeField]
	GameObject background;

	float scale;

	void Awake()
	{
		Vector2 temp = baseLayer.GetComponent<RectTransform>().sizeDelta;
		float scaleX = temp.x / (float)Screen.width;
		float scaleY = temp.y / (float)Screen.height;
		scale = ( scaleX >= scaleY )?( scaleX ):( scaleY );
		foreach( Transform child in transform ) child.localScale = new Vector3( 1 / scale, 1 / scale, 1 / scale );

		if( background != null )
		{
			RectTransform rt;
			Vector2 v2;
			float v3;
			if( scaleX >= scaleY )
			{
				Destroy( background.transform.Find("Left").gameObject );
				Destroy( background.transform.Find("Right").gameObject );
				float height = ( Screen.height * scaleX - temp.y ) / 2;
				v2 = new Vector2( temp.x, height );
				v3 = ( Screen.height * scaleX )  / 2 - height / 2;
				rt = background.transform.Find("Top").GetComponent<RectTransform>();
				rt.sizeDelta = v2;
				rt.localPosition = new Vector3( 0, v3, 0 );
				rt = background.transform.Find("Bottom").GetComponent<RectTransform>();
				rt.sizeDelta = v2;
				rt.localPosition = new Vector3( 0, -v3, 0 );
			} else
			{
				Destroy( background.transform.Find("Top").gameObject );
				Destroy( background.transform.Find("Bottom").gameObject );
				float width = ( Screen.width * scaleY - temp.x ) / 2;
				v2 = new Vector2( width, temp.y );
				v3 = ( Screen.width * scaleY )  / 2 - width / 2;
				rt = background.transform.Find("Left").GetComponent<RectTransform>();
				rt.sizeDelta = v2;
				rt.localPosition = new Vector3( v3, 0, 0 );
				rt = background.transform.Find("Right").GetComponent<RectTransform>();
				rt.sizeDelta = v2;
				rt.localPosition = new Vector3( -v3, 0, 0 );
			}
		}
	}
}
