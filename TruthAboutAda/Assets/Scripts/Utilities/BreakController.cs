using UnityEngine;

public class BreakController : MonoBehaviour
{
	void OnTriggerEnter( Collider col )
	{
		Destroy( col.gameObject );
	}
}
