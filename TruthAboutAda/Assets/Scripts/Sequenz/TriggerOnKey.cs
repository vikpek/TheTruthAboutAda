using UnityEngine;
using System.Collections;

public class TriggerOnKey : MonoBehaviour 
{
	[SerializeField]
	KeyCode key;

	[SerializeField]
	GameObject target;

	[SerializeField]
	GameObject hide;
	
	[SerializeField]
	float waitTime = 0f;
	
	bool trigger;

	void Update() 
	{
		if( !trigger ) 
			if( Input.GetKeyDown( key ) ) StartCoroutine( Trigger() );
	}

	IEnumerator Trigger()
	{
		trigger = true;
		if( waitTime > 0f ) yield return StartCoroutine( CoroutinesUtilities.WaitForRealSeconds( waitTime ) );
		if( target != null ) target.SetActive( true );
		if( hide != null ) hide.BroadcastMessage( "Disappear", SendMessageOptions.DontRequireReceiver );
		this.enabled = false;
	}
}