﻿using UnityEngine;
using System.Collections;

public class TriggerOnDestroy : MonoBehaviour
{
	Transform _ref;

	[SerializeField]
	GameObject target;

	[SerializeField]
	GameObject hide;

	[SerializeField]
	float waitTime = 0f;

	bool trigger;

	void Awake()
	{
		_ref = transform.Find( Constants.ANIMATION_HOLDER );
	}

	void Update()
	{
		if( !trigger )
		{
			if( _ref == null ) StartCoroutine( Trigger() );
			else if( _ref.parent != transform ) StartCoroutine( Trigger () );
		}
	}

	IEnumerator Trigger()
	{
		trigger = true;
		if( waitTime > 0f ) yield return StartCoroutine( CoroutinesUtilities.WaitForRealSeconds( waitTime ) );
		if( target != null ) target.SetActive( true );
		if( hide != null ) hide.BroadcastMessage( "Disappear", SendMessageOptions.DontRequireReceiver );
		this.enabled = false;
	}	

	void OnDestroy()
	{
		StartCoroutine( Trigger() );
	}
}