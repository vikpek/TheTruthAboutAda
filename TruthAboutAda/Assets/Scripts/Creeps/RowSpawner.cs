﻿using UnityEngine;

public class RowSpawner : MonoBehaviour 
{
	[SerializeField]
	float spawnTimer = 1.5f;

	Animator animator;

	[SerializeField]
	bool incomingAnimation = true;

	[SerializeField]
	float movementStartDelay = 3;

	void Awake()
	{
		movementStartDelay += spawnTimer;
		animator = transform.GetComponent<Animator>();
		foreach( Transform child in transform ) child.gameObject.SetActive( false );
	}

	void FixedUpdate()
	{
		if( spawnTimer > 0f ) spawnTimer -= Time.fixedDeltaTime;
		if( incomingAnimation && spawnTimer <= 0f )
		{
			animator.enabled = true;
			animator.Play( "RowAnimation" );
			foreach( Transform child in transform ) child.gameObject.SetActive( true );
		}
		if( movementStartDelay > 0f ) movementStartDelay -= Time.fixedDeltaTime;
		if( movementStartDelay <= 0f )
		{
			foreach( Transform child in transform )
			{
				child.gameObject.SetActive( true );
				child.GetComponent<CreepMovement>().enabled = true;
			}
			animator.enabled = false;
		}
	}
}