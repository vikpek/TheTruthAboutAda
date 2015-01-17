using UnityEngine;

public class CreepController3D : MonoBehaviour 
{
	[SerializeField]
	bool randomized = true;
	
	[SerializeField]
	int cylinderValue;

	[SerializeField]
	float beginRotationAfter = 2;
	
	[SerializeField]
	float animationDuration = 2;

	[SerializeField]
	float explosionRaidus = 6;
	

	SoundManager soundManager;
	ParticleSystem particleSystem;
	ParticleSystem particleSystemExplosion;
	CameraRumbler cameraRumbler;

	Transform cylinderTransform;

	float rotationTime;
	float rotationDuration;

	AudioSource audioSource;

	bool creepBlack = false;
	bool creepSilver = false;

	//TODO hp organisation...
	int blackCreepLifeCount = 1;
	int silverCreepLifeCount = 2;
	int creepHP = 0;

	float shakingTime = 0f;

	void Awake()
	{		
		creepBlack = (transform.name == Constants.CREEP_BLACK)?(true):(false);
		creepSilver = (transform.name == Constants.CREEP_SILVER)?(true):(false);

		cylinderTransform = transform.FindChild (Constants.ANIMATION_HOLDER).FindChild (Constants.CYLINDER).FindChild( "animation_holder_cylinder" ).transform;

		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		particleSystem = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();
		particleSystemExplosion = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM_EXPLOSION ).GetComponent<ParticleSystem>();

		audioSource = transform.GetComponent<AudioSource>();

		rotationTime = beginRotationAfter;
		reinitializeCylinder (-1);
	}

	void FixedUpdate()
	{
		if( rotationTime > 0f ) rotationTime -= Time.fixedDeltaTime;
		if (rotationTime <= 0f && rotationDuration > 0) {
			rotationDuration -= Time.fixedDeltaTime;
			rotateCylinder ();
			shakeIt(0.5f);

			if (!audioSource.isPlaying){
					audioSource.Play ();
			}
		} else {
				audioSource.Stop ();
		}

		if (rotationDuration <= 0) {
			cylinderTransform.rotation = CylinderUtility.Get.setCylinderToValue(cylinderValue);
		}

		if (shakingTime > 0f && rotationTime <= 0f) {
			transform.rotation = CylinderUtility.Get.shakeCylinder(5f);
			shakingTime -= Time.fixedDeltaTime;
		}


	}
	
	void OnTriggerEnter( Collider col )
	{
		shakeIt(0.5f);
		if( col.gameObject.tag == Tags.BULLET )
		{
			particleSystem.Play();
			GenericFXController.Get.rumbleCamera( 0.3f, 0.03f );
		
			if( col.GetComponent<BulletController>().getBulletValue() == cylinderValue )
			{
				if( creepSilver )
				{
					if( creepHP < silverCreepLifeCount ) 
					{
						damageCreepCage(creepHP);
						reinitializeCylinder(-1);
					}
					else
					{
						explodeYeah();
					}
				} else if( creepBlack )
				{
					if( creepHP < blackCreepLifeCount ) 
					{
						damageCreepCage(0);
						reinitializeCylinder(-1);
					}
					else 
					{
						moveCreepAway();
					}
				} else 
				{
					moveCreepAway();
				}

				creepHP++;

				if( GameConfig.Get.ShowEnemyCollisionPoints )
				{
					GameObject temp = GameObject.CreatePrimitive( PrimitiveType.Sphere );
					temp.transform.position = col.ClosestPointOnBounds( transform.position );
					temp.transform.parent = transform;
					temp.renderer.material.color = Color.red;
					Destroy( temp.GetComponent<SphereCollider>() );
				}
			} else
			{
				HighScoreManager.Get.shotFailed();
				reinitializeCylinder(-1);
				if(creepBlack) reinitializeCreepRow(-1);
			}
			Destroy( col.gameObject );
		}
	}

	public void reinitializeCylinder(int _cylinderValue)
	{
		if(_cylinderValue != -1) cylinderValue = _cylinderValue;
		rotationDuration = animationDuration * Random.Range (0.6f, animationDuration);
	}

	void moveCreepAway ()
	{
		
		generateRail( transform.FindChild( "animation_holder" ).gameObject );
		creepDeath ();
	}

	void kickCreepDown()
	{
		foreach (Transform element in transform.FindChild (Constants.ANIMATION_HOLDER).FindChild (Constants.CYLINDER)) {
			element.gameObject.AddComponent<Rigidbody>();
			element.gameObject.AddComponent<ConstantForce>();
			element.GetComponent<ConstantForce>().relativeTorque = new Vector3(Random.Range(0,10), Random.Range(0,10),Random.Range(0,10));
			element.GetComponent<ConstantForce>().relativeForce = new Vector3(Random.Range(0,5), Random.Range(0,5),Random.Range(0,5));
		}
		creepDeath ();
	}

	void creepDeath()
	{
		if (creepBlack) reinitializeCreepRow (0);
		HighScoreManager.Get.creepKilled();
		soundManager.playEnemyDeath();
		Destroy( GetComponent<BoxCollider>() );
	}

	void damageCreepCage(int damage)
	{
		foreach (Transform element in transform.FindChild (Constants.ANIMATION_HOLDER).FindChild (Constants.CYLINDER)) {
			if(damage == 0){
				element.rotation = CylinderUtility.Get.damageCylinder(element.rotation.eulerAngles, -1);
			}

			if(element.tag == Tags.DESTROYABLE){
				if(damage == 1){
					element.gameObject.AddComponent<Rigidbody>();
					element.gameObject.AddComponent<ConstantForce>();
					element.GetComponent<ConstantForce>().relativeTorque = new Vector3(Random.Range(0,10), Random.Range(0,10),Random.Range(0,10));
					element.GetComponent<ConstantForce>().relativeForce = new Vector3(Random.Range(0,5), Random.Range(0,5),Random.Range(0,5));
				}
			}
		} 
	}

	void reinitializeCreepRow(int value)
	{
		foreach (Transform creep in transform.parent) {
			if(creep.tag == Tags.CREEP) 
			{
				creep.GetComponent<CreepController3D>().reinitializeCylinder(value);
			}
		}
	}

	void rotateCylinder(){
		cylinderValue = Random.Range (0, 9);
		if(cylinderTransform) cylinderTransform.rotation = CylinderUtility.Get.rotateCylinder(cylinderTransform.rotation.eulerAngles, cylinderValue);
	}

	void explodeYeah ()
	{
		particleSystemExplosion.Play ();
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRaidus);
		foreach (Collider collider in colliders) {
			if(collider.transform.tag == Tags.CREEP){
				collider.GetComponentInParent<CreepController3D>().damageCreepCage(2);
				collider.GetComponentInParent<CreepController3D>().kickCreepDown();
			}
		}
	}

	void shakeIt(float _shakingTime)
	{
		shakingTime = _shakingTime;
	}
	
	void generateRail( GameObject obj )
	{
		((GameObject)Instantiate( PrefabDB.Get.VerticalRail(), transform.position, PrefabDB.Get.VerticalRail().transform.rotation )).GetComponent<NumberRailGoaway>().AddObj( obj );
	}
}