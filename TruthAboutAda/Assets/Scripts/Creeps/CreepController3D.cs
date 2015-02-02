using UnityEngine;
using System.Collections;

public class CreepController3D : MonoBehaviour 
{
	public bool randomized = true;
	
	public int cylinderValue;

	[SerializeField]
	float beginRotationAfter = 2;
	
	[SerializeField]
	float animationDuration = 2;

	[SerializeField]
	float explosionRadius = 6;

	[SerializeField]
	Vector3 HitOffset;

	SoundManager soundManager;
	ParticleSystem particleSystem;
	ParticleSystem particleSystemExplosion;
	ParticleSystem particleSystemLightning;
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

	RowSpawner _link;

	bool destroyed;

	bool gotPoints;

	void Awake()
	{
		if( transform.name == Constants.CREEP_BLACK ) creepBlack = true;
		else if( transform.name == Constants.CREEP_SILVER ) creepSilver = true;
		
		cylinderTransform = transform.FindChild( Constants.ANIMATION_HOLDER ).FindChild( Constants.CYLINDER ).FindChild( "animation_holder_cylinder" ).transform;

		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		particleSystem = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();
		particleSystemExplosion = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM_EXPLOSION ).GetComponent<ParticleSystem>();
		particleSystemLightning = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM_LIGHTNING ).GetComponent<ParticleSystem>();

		audioSource = transform.GetComponent<AudioSource>();

		rotationTime = beginRotationAfter;
		reinitializeCylinder( -1 );

		findMovVerCon( transform );
		if( randomized ) cylinderValue = Random.Range( 0, 9 );
	}

	void findMovVerCon( Transform obj )
	{
		if( obj.parent.GetComponent<RowSpawner>() != null ) _link = obj.parent.GetComponent<RowSpawner>();
		else findMovVerCon( obj.parent );
	}

	void Update()
	{
		if( rotationTime > 0f ) rotationTime -= Time.deltaTime;
		if( rotationTime <= 0f && rotationDuration > 0 )
		{
			rotationDuration -= Time.deltaTime;
			rotateCylinder();
			shakeIt( 0.5f );
			if( creepBlack || creepSilver ) if( !audioSource.isPlaying ) audioSource.Play();
		} else if( creepBlack || creepSilver ) audioSource.Stop();

		if( rotationDuration <= 0 )
		{
			cylinderTransform.rotation = CylinderUtility.Get.setCylinderToValue( cylinderValue );
		}
		if( shakingTime > 0f && rotationTime <= 0f )
		{
			if( shakingTime % 2 == 0 ) transform.rotation = CylinderUtility.Get.shakeCylinder( 5f );
			shakingTime -= Time.deltaTime;
		}
	}

	void OnTriggerEnter( Collider col )
	{
		shakeIt(0.5f);
		if( col.gameObject.tag == Tags.BULLET )
		{
			particleSystem.Play();
			GenericFXController.Get.rumbleCamera( 0.3f, 0.03f );
		
			if(col.GetComponent<BulletController>().IsBulletJoker())
			{
				explodeAllWithValue(cylinderValue);
			} else if( col.GetComponent<BulletController>().GetBulletValue() == cylinderValue )
			{
				if( creepSilver )
				{
					if( creepHP < silverCreepLifeCount ) 
					{
						damageCreepCage( creepHP );
						reinitializeCylinder( -1 );
					} else explodeYeah();
					blockShot( col.gameObject );
				} else if( creepBlack )
				{
					if( creepHP < blackCreepLifeCount ) 
					{
						cylinderTransform.FindChild("cylinder_main").renderer.materials[0].mainTexture = (Texture) Resources.Load ("Textures/Chars/MM_GPE_cylinder_black");
						cylinderTransform.FindChild("cylinder_main").renderer.materials[1].mainTexture = (Texture) Resources.Load ("Textures/Chars/MM_GPE_cylinder_black");
						damageCreepCage(0);
						reinitializeCylinder(-1);
						blockShot( col.gameObject );
					} else generateRail( col.gameObject );
				} else generateRail( col.gameObject );

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
				soundManager.playFailedShot();
				reinitializeCylinder( -1 );
				if( creepBlack ) reinitializeCreepRow(-1);
				blockShot( col.gameObject );
			}
		}
	}

	void explodeAllWithValue (int _cylinderValue)
	{
		foreach (GameObject go in GameObject.FindGameObjectsWithTag(Tags.CREEP)) {
			if(go.GetComponent<CreepController3D>().cylinderValue == _cylinderValue)
			{
				Debug.Log ("test");
				go.GetComponent<CreepController3D>().explodeYeah();
			}
		}
	}

	// The owned cylinder will rotate and finally set to the given value which is random if -1.
	public void reinitializeCylinder( int _cylinderValue )
	{
		cylinderValue = ( _cylinderValue == -1 )?( Random.Range( 0, 9 ) ):(_cylinderValue );
		rotationDuration = Random.Range( 0.6f, animationDuration );
	}

	// Creep simply falls down. This is an alternative dying animation.
	void kickCreepDown()
	{
		soundManager.playFallingParts();
		Transform el = transform.Find( Constants.ANIMATION_HOLDER + "/" + Constants.CYLINDER );
		foreach( Transform element in el ) addConstForces( element.gameObject );
		creepDeath();
	}

	// The logical consequences for destroyed creep - independend of the animations.
	void creepDeath()
	{
		if( !destroyed )
		{
			if( creepBlack )
			{
				reinitializeCreepRow( cylinderValue );
				particleSystemLightning.Play();
			}
			if( !gotPoints )
			{
				HighScoreManager.Get.creepKilled(transform.position);
				gotPoints = true;
			}
			soundManager.playEnemyDeath();
			Destroy( GetComponent<BoxCollider>() );
			Destroy( transform.FindChild("direction_trigger").GetComponent<BoxCollider>() );
			destroyed = true;
		}
		if( !gotPoints )
		{
			HighScoreManager.Get.creepKilled(transform.position);
			gotPoints = true;
		}
		soundManager.playEnemyDeath();
		soundManager.playCreepExplosionBlackCreep();
		Destroy( GetComponent<BoxCollider>() );
		Destroy( transform.FindChild("direction_trigger").GetComponent<BoxCollider>() );
//		Destroy( GetComponent<CreepController3D>() );
	}


	// Damages the creep cage in different stages dependent on damage:
	// 0 - bends some elements of the cage
	// 1 - cage falls down in single parts
	void damageCreepCage( int damage )
	{
		soundManager.playPlayerDamageShot();
		Transform el = transform.Find( Constants.ANIMATION_HOLDER + "/" + Constants.CYLINDER );
		foreach( Transform element in el )
		{
			if( element.tag == Tags.DESTROYABLE )
			{
				if( damage == 0 ) element.rotation = CylinderUtility.Get.damageCylinder(element.rotation.eulerAngles, -1);
				else if( damage == 1 ) addConstForces( element.gameObject );
			}
		} 
	}

	void addConstForces( GameObject element )
	{
		ConstantForce temp = element.GetComponent<ConstantForce>();
		if( temp == null ) temp = element.AddComponent<ConstantForce>();
		Rigidbody rig = element.GetComponent<Rigidbody>();
		if( rig == null ) rig = element.AddComponent<Rigidbody>();
		temp.relativeTorque = new Vector3(Random.Range(0,10), Random.Range(0,10),Random.Range(0,10));
		temp.relativeForce = new Vector3(Random.Range(0,5), Random.Range(0,5),Random.Range(0,5));
	}
	
	// Reinitializes a whole creep row. If value is set to -1 the row is initialized with random values.
	void reinitializeCreepRow( int value )
	{
		foreach( Transform creep in transform.parent )
			if( creep.tag == Tags.CREEP ) creep.GetComponent<CreepController3D>().reinitializeCylinder( value );
	}


	// Randomly rotates the cylinder. This only includes the animation. The actual final value has to be set explictly.
	void rotateCylinder()
	{
		if( cylinderTransform ) cylinderTransform.rotation = CylinderUtility.Get.rotateCylinder( cylinderTransform.rotation.eulerAngles, Random.Range (0, 9) );
	}

	// Explosion that affects all creep in sphere radius.
	public void explodeYeah()
	{
		if( !destroyed )
		{
			soundManager.playCreepExplosion();
			soundManager.playCreepExplosion2();
			particleSystemExplosion.Play();
			Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
			foreach( Collider coll in colliders ) 
			{
				if( coll.transform.tag == Tags.CREEP )
				{
					CreepController3D t = coll.GetComponentInParent<CreepController3D>();
					if( coll.name == Constants.CREEP_SILVER && t != this ) t.explodeYeah();
					else t.explodeMe();
				}
			}
		}
	}

	public void explodeMe()
	{
		if( !destroyed )
		{
			destroyed = true;
			damageCreepCage(2);
			kickCreepDown();
			transform.parent = null;
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			_link.CreepKill();
		}
	}

	public bool getDestroyed()
	{
		return destroyed;
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
		if( !destroyed )
		{
			creepDeath();
			// Bullet
			Destroy( obj.GetComponent<BulletMovement>() );
			Destroy( obj.GetComponent<Rigidbody>() );
			Destroy( obj.GetComponent<BoxCollider>() );
			// Creep
			Destroy( GetComponent<CreepController3D>() );
			Destroy( GetComponent<Rigidbody>() );
			//Debug.Log( transform.Find( Constants.ANIMATION_HOLDER + "/" + Constants.CYLINDER + "/animation_holder_cylinder/Spotlight" ) );
			gameObject.tag = "Untagged";
			Transform child = transform.Find( Constants.ANIMATION_HOLDER );
			child.parent = obj.transform;
			child.localPosition = HitOffset;
			obj.AddComponent<NumberRailGoaway>();
			_link.CreepKill();
			destroyed = true;
		}
	}
}