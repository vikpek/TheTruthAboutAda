using UnityEngine;

public class Scalation : MonoBehaviour
{
	[SerializeField]
	int baseX = 1971;

	[SerializeField]
	int baseY = 1181;

	float scale;

	void Awake()
	{
		scale = (float)Screen.height / (float)baseY;
		Debug.Log( scale );
		FindLayers( transform );
	}

	void FindLayers( Transform parent )
	{
		foreach( Transform child in parent )
		{
			RectTransform temp = child.GetComponent<RectTransform>();
			if( temp != null )
			{
				temp.sizeDelta = new Vector2( temp.sizeDelta.x * scale, temp.sizeDelta.y * scale );
				temp.position = new Vector3( temp.position.x * scale, temp.position.y * scale, temp.position.z * scale );
			}
			if( child.childCount > 0 ) FindLayers( child );
		}
	}
}
