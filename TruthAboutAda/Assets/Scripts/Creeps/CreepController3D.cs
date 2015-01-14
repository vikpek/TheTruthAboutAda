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
	
	SoundManager soundManager;
	ParticleSystem particleSystem;
	CameraRumbler cameraRumbler;

	Transform cylinderTransform;

	float rotationTime;
	float rotationDuration;

	AudioSource audioSource;

	[SerializeField]
	bool blackCreep;

	int blackCreepStatus;


	void Awake()
	{
		cylinderTransform = transform.FindChild( "animation_holder" ).FindChild( "cylinder" ).FindChild( "animation_holder_cylinder" ).transform;

		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		particleSystem = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();

		audioSource = transform.GetComponent<AudioSource>();

		rotationTime = beginRotationAfter;
		reinitializeCylinder (-1);
	}

	void FixedUpdate()
	{
		if( rotationTime > 0f ) rotationTime -= Time.fixedDeltaTime;
		if( rotationTime <= 0f && rotationDuration > 0 )
		{
			rotationDuration -= Time.fixedDeltaTime;
			rotateCylinder();
			cylinderTransform.rotation = CylinderUtility.Get.rotateCylinder( new Vector3(0,0,0), cylinderValue );

			if( !audioSource.isPlaying ) audioSource.Play();
		} else audioSource.Stop();
	}
	
	void OnTriggerEnter( Collider col )
	{
		if( col.gameObject.tag == Tags.BULLET )
		{
			particleSystem.Play();
			GenericFXController.Get.rumbleCamera( 0.3f, 0.03f );
		
			if( col.GetComponent<BulletController>().getBulletValue() == cylinderValue )
			{
				if( blackCreep )
				{
					if( blackCreepStatus < 2 ) blackCreepStatus++;
					else destroyCreepOperation();
				} else destroyCreepOperation();

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
				if(blackCreep) reinitializeCreepRow();
			}
			Destroy( col.gameObject );
		}
	}

	public void reinitializeCylinder(int _cylinderValue)
	{
		if(_cylinderValue != -1) cylinderValue = _cylinderValue;
		rotationDuration = animationDuration * Random.Range (0.6f, animationDuration);
	}

	void destroyCreepOperation ()
	{
		if (blackCreep)
			damageBlackCreepOperation ();
		HighScoreManager.Get.creepKilled();
		generateRail( transform.FindChild( "animation_holder" ).gameObject );
		soundManager.playEnemyDeath();
		Destroy( GetComponent<BoxCollider>() );
	}

	void damageBlackCreepOperation()
	{
		foreach (Transform element in transform.FindChild ("animation_holder").FindChild ("cylinder")) {
			if(element.tag == Tags.DESTROYABLE){
				element.gameObject.AddComponent<Rigidbody>();
				element.gameObject.AddComponent<ConstantForce>();
				element.GetComponent<ConstantForce>().relativeTorque = new Vector3(Random.Range(0,10), Random.Range(0,10),Random.Range(0,10));
				element.GetComponent<ConstantForce>().relativeForce = new Vector3(Random.Range(0,5), Random.Range(0,5),Random.Range(0,5));
			}
		} 
	}

	void reinitializeCreepRow()
	{
		foreach (Transform creep in transform.parent) {
			if(creep.tag == Tags.CREEP) 
			{
				creep.GetComponent<CreepController3D>().reinitializeCylinder(-1);
			}
		}
	}

	void rotateCylinder(){
		cylinderValue = Random.Range (0, 9);
		cylinderTransform.rotation = CylinderUtility.Get.rotateCylinder(cylinderTransform.rotation.eulerAngles, cylinderValue);
	}
	
	void generateRail( GameObject obj )
	{
		((GameObject)Instantiate( PrefabDB.Get.VerticalRail(), transform.position, PrefabDB.Get.VerticalRail().transform.rotation )).GetComponent<NumberRailGoaway>().AddObj( obj );
	}
}