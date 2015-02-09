using UnityEngine;

public class MalusShooting : MonoBehaviour 
{
	public GameObject Malus;
	
	[SerializeField]
	float minTime = 0.5f;
	
	[SerializeField]
	float maxTime = 3f;
	
	float shootWaiter;

	ParticleSystem pS;
	
	void Awake()
	{
		pS = transform.FindChild( Constants.PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();
	}

	void Update()
	{
		if( shootWaiter <= 0f ) 
		{
			pS.Play();
			Instantiate( Malus, transform.position, Quaternion.identity );
			shootWaiter += Random.Range( minTime, maxTime );
		}
	}
	
	void FixedUpdate()
	{
		if( shootWaiter > 0f ) shootWaiter -= Time.fixedDeltaTime;
	}
}
