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
	float explosionRadius = 6;
	

	SoundManager soundManager;
	ParticleSystem particleSystem;
	ParticleSystem particleSystemExplosion;
	CameraRumbler cameraRumbler;

	Transform cylinderTransform;

	float rotationTime;
	float rotationDuration;

	AudioSource audioSource;

	bool creepBlack;
	bool creepSilver;

	//TODO hp organisation...
	int blackCreepLifeCount = 1;
	int silverCreepLifeCount = 2;
	int creepHP;

	float shakingTime;

	MovementVerticalController _link;

	void Awake()
	{
		if( transform.name == Constants.CREEP_BLACK ) creepBlack = true;
		else if( transform.name == Constants.CREEP_SILVER ) creepSilver = true;
		
		cylinderTransform = transform.FindChild (Constants.ANIMATION_HOLDER).FindChild (Constants.CYLINDER).FindChild( "animation_holder_cylinder" ).transform;

		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		particleSystem = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();
		particleSystemExplosion = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM_EXPLOSION ).GetComponent<ParticleSystem>();

		audioSource = transform.GetComponent<AudioSource>();

		rotationTime = beginRotationAfter;
		reinitializeCylinder( -1 );

		findMovVerCon( transform );
	}

	void findMovVerCon( Transform obj )
	{
		if( obj.parent.GetComponent<MovementVerticalController>() != null ) _link = obj.parent.GetComponent<MovementVerticalController>();
		else findMovVerCon( obj.parent );
	}

	void FixedUpdate()
	{
		if( rotationTime > 0f ) rotationTime -= Time.fixedDeltaTime;
		if( rotationTime <= 0f && rotationDuration > 0 )
		{
			rotationDuration -= Time.fixedDeltaTime;
			rotateCylinder ();
			shakeIt(0.5f);

			if( !audioSource.isPlaying ) audioSource.Play();
		} else audioSource.Stop();

		if( rotationDuration <= 0 ) cylinderTransform.rotation = CylinderUtility.Get.setCylinderToValue( cylinderValue );

		if( shakingTime > 0f && rotationTime <= 0f )
		{
			if( shakingTime % 2 == 0 ) transform.rotation = CylinderUtility.Get.shakeCylinder( 5f );
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
						damageCreepCage( creepHP );
						reinitializeCylinder( -1 );
					}
					else
					{
						explodeYeah();
						_link.CreepKill();
					}
				} else if( creepBlack )
				{
					if( creepHP < blackCreepLifeCount ) 
					{
						cylinderTransform.FindChild("cylinder_main").renderer.materials[0].mainTexture = (Texture) Resources.Load ("Textures/Chars/MM_GPE_cylinder_black");
						cylinderTransform.FindChild("cylinder_main").renderer.materials[1].mainTexture = (Texture) Resources.Load ("Textures/Chars/MM_GPE_cylinder_black");
						damageCreepCage(0);
						reinitializeCylinder(-1);
					}
					else 
					{
						creepDeath();
						generateRail( col.gameObject );
						_link.CreepKill();
					}
				} else 
				{
					creepDeath();
					generateRail( col.gameObject );
					_link.CreepKill();
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
				reinitializeCylinder( -1 );
				if( creepBlack ) reinitializeCreepRow(-1);
				blockShot( col.gameObject );
			}

		}
	}

	// The owned cylinder will rotate and finally set to the given value which is random if -1.
	public void reinitializeCylinder(int _cylinderValue)
	{
		if(_cylinderValue != -1) cylinderValue = _cylinderValue;
		rotationDuration = Random.Range (0.6f, animationDuration);
	}

	// Creep simply falls down. This is an alternative dying animation.
	void kickCreepDown()
	{
		foreach (Transform element in transform.FindChild (Constants.ANIMATION_HOLDER).FindChild (Constants.CYLINDER))
		{
			element.gameObject.AddComponent<Rigidbody>();
			element.gameObject.AddComponent<ConstantForce>();
			element.GetComponent<ConstantForce>().relativeTorque = new Vector3(Random.Range(0,10), Random.Range(0,10),Random.Range(0,10));
			element.GetComponent<ConstantForce>().relativeForce = new Vector3(Random.Range(0,5), Random.Range(0,5),Random.Range(0,5));
		}
		creepDeath();
	}

	// The logical consequences for destroyed creep - independend of the animations.
	void creepDeath()
	{
		if (creepBlack) reinitializeCreepRow (0);
		HighScoreManager.Get.creepKilled();
		soundManager.playEnemyDeath();
		Destroy( GetComponent<BoxCollider>() );
		Destroy( transform.FindChild("direction_trigger").GetComponent<BoxCollider>());
	}


	// Damages the creep cage in different stages dependent on damage:
	// 0 - bends some elements of the cage
	// 1 - cage falls down in single parts
	void damageCreepCage(int damage)
	{
		foreach (Transform element in transform.FindChild (Constants.ANIMATION_HOLDER).FindChild (Constants.CYLINDER)) {

			if(element.tag == Tags.DESTROYABLE){
				if(damage == 0){
					element.rotation = CylinderUtility.Get.damageCylinder(element.rotation.eulerAngles, -1);
				}
				if(damage == 1){
					element.gameObject.AddComponent<Rigidbody>();
					element.gameObject.AddComponent<ConstantForce>();
					element.GetComponent<ConstantForce>().relativeTorque = new Vector3(Random.Range(0,10), Random.Range(0,10),Random.Range(0,10));
					element.GetComponent<ConstantForce>().relativeForce = new Vector3(Random.Range(0,5), Random.Range(0,5),Random.Range(0,5));
				}
			}
		} 
	}


	// Reinitializes a whole creep row. If value is set to -1 the row is initialized with random values.
	void reinitializeCreepRow(int value)
	{
		foreach (Transform creep in transform.parent) {
			if(creep.tag == Tags.CREEP) 
			{
				creep.GetComponent<CreepController3D>().reinitializeCylinder(value);
			}
		}
	}


	// Randomly rotates the cylinder. This only includes the animation. The actual final value has to be set explictly.
	void rotateCylinder()
	{
		cylinderValue = Random.Range (0, 9);
		if(cylinderTransform) cylinderTransform.rotation = CylinderUtility.Get.rotateCylinder(cylinderTransform.rotation.eulerAngles, cylinderValue);
	}


	// Explosion that affects all creep in sphere radius.
	void explodeYeah ()
	{
		particleSystemExplosion.Play ();
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders) {
			if(collider.transform.tag == Tags.CREEP){
				collider.GetComponentInParent<CreepController3D>().damageCreepCage(2);
				collider.GetComponentInParent<CreepController3D>().kickCreepDown();
			}
		}
	}


	// Increases the shake duration by _shakingTime.
	void shakeIt( float _shakingTime )
	{
		shakingTime = _shakingTime;
	}

	void blockShot( GameObject shot )
	{
		Destroy( shot.GetComponent<BulletMovement>() );
	}
	
	void generateRail( GameObject obj )
	{
		// Bullet
		Destroy( obj.GetComponent<BulletMovement>() );
		Destroy( obj.GetComponent<Rigidbody>() );
		Destroy( obj.GetComponent<BoxCollider>() );
		// Creep
		Destroy( GetComponent<CreepController3D>() );
		Destroy( GetComponent<Rigidbody>() );
		transform.parent = obj.transform;
		transform.localPosition = new Vector3();
		obj.AddComponent<NumberRailGoaway>();
	}
}