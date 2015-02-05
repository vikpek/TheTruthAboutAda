using UnityEngine;

public class DestroyOn : MonoBehaviour 
{
	[SerializeField]
	float y = -10f;

	void Update()
	{
		if( transform.position.y <= y ) Destroy( gameObject );
	}
}
