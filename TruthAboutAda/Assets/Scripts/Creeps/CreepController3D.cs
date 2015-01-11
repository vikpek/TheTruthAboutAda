using UnityEngine;

public class CreepController3D : MonoBehaviour 
{
	[SerializeField]
	bool randomized = true;
	
	[SerializeField]
	int cylinderValue = 0;

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



	void Awake()
	{
		cylinderTransform = transform.FindChild ("animation_holder").FindChild ("cylinder").FindChild("animation_holder_cylinder").transform;

		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		particleSystem = transform.FindChild( Constants.CREEP_PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();

		cylinderValue = Random.Range (0, 9);
		cylinderTransform.rotation = Quaternion.Euler( new Vector3( 0, cylinderTransform.rotation.eulerAngles.y + ( cylinderValue * 36 ), 0 ) );

		rotationTime = beginRotationAfter;
		rotationDuration = animationDuration * Random.Range (0.6f, animationDuration);
	}

	void Update()
	{
		if (rotationTime > 0f) 
		{
			rotationTime -= Time.fixedDeltaTime;
		}
		if (rotationTime <= 0f && rotationDuration > 0) {
			rotationDuration -=Time.fixedDeltaTime;
			rotateCylinder();

		}
	}
	
	void OnTriggerEnter( Collider col )
	{
		if( col.gameObject.tag == Tags.BULLET )
		{
			particleSystem.Play();
			GenericFXController.Get.rumbleCamera( 0.3f, 0.03f );

			if( col.GetComponent<BulletController>().getBulletValue() == cylinderValue )
			{
				generateRail( gameObject );
//				GenericFXController.Get.playVerticalRailAnim();
				soundManager.playEnemyDeath();
				Destroy ( GetComponent<BoxCollider>() );

				if( GameConfig.Get.ShowEnemyCollisionPoints )
				{
					GameObject temp = GameObject.CreatePrimitive( PrimitiveType.Sphere );
					temp.transform.position = col.ClosestPointOnBounds( transform.position );
					temp.transform.parent = transform;
					temp.renderer.material.color = Color.red;
					Destroy( temp.GetComponent<SphereCollider>() );
				}
			}
			Destroy( col.gameObject );
		}
	}

	void rotateCylinder(){
		cylinderValue = Random.Range (0, 9);
		cylinderTransform.rotation = Quaternion.Euler( new Vector3( 0, cylinderTransform.rotation.eulerAngles.y + ( cylinderValue * 36 ), 0 ) );
	}
	
	void generateRail( GameObject obj )
	{
		((GameObject)Instantiate( PrefabDB.Get.VerticalRail(), transform.position, PrefabDB.Get.VerticalRail().transform.rotation )).GetComponent<NumberRailGoaway>().AddObj( obj );
	}
}