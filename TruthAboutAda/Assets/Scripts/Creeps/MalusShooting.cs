﻿using UnityEngine;

public class MalusShooting : MonoBehaviour 
{
	public GameObject Malus;
	
	[SerializeField]
	float minTime = 0.5f;
	
	[SerializeField]
	float maxTime = 3f;
	
	SoundManager soundManager;
	
	float shootWaiter;

	ParticleSystem particleSystem;
	
	void Awake()
	{
		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		particleSystem = transform.FindChild (Constants.PARTICLE_SYSTEM).GetComponent<ParticleSystem> ();

	}

	void Update()
	{
		if( shootWaiter <= 0f ) 
		{
			particleSystem.Play();
			Instantiate( Malus, transform.position, Quaternion.identity );
			shootWaiter += Random.Range( minTime, maxTime );
		}
	}
	
	void FixedUpdate()
	{
		if( shootWaiter > 0f ) shootWaiter -= Time.fixedDeltaTime;
	}
}
