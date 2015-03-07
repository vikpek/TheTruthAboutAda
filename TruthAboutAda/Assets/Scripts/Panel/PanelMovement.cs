using UnityEngine;

public class PanelMovement : MonoBehaviour
{
	[SerializeField]
	float speed = 25f;

	[SerializeField]
	bool smooth = true;

	[SerializeField]
	float maxXBorder;

	[SerializeField]
	float minXBorder;
	            
	bool move = true;

	Transform transformSideCogRight;
	Transform transformSideCogLeft;

	ParticleSystem particleSystemSideCogRight;
	ParticleSystem particleSystemSideCogLeft;

	SoundManager soundManager;

	void Awake()
	{
		transformSideCogRight = transform.Find("DelayCylinder/animation_holder_sidecog_right").transform;
		transformSideCogLeft = transform.Find("DelayCylinder/animation_holder_sidecog_left").transform;

		particleSystemSideCogRight = transform.Find("DelayCylinder/particle_system_sidecog_right").GetComponent<ParticleSystem>(); 
		particleSystemSideCogLeft = transform.Find("DelayCylinder/particle_system_sidecog_left").GetComponent<ParticleSystem>();

		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();

	}

	void FixedUpdate()
	{
		float horizontal = ( move )?( ( smooth )?( Input.GetAxis( "Horizontal" ) ):( Input.GetAxisRaw( "Horizontal" ) ) ):( 0f );
		
		if( horizontal != 0f )
		{
			particleSystemSideCogRight.Play();
			particleSystemSideCogLeft.Play();
			Vector3 nextPos = transform.position - new Vector3( horizontal * Time.fixedDeltaTime * speed, 0f );
		
			if( nextPos.x > maxXBorder ) nextPos.x = maxXBorder;
			else if( nextPos.x < minXBorder ) nextPos.x = minXBorder;

			if( horizontal > 0 )
			{
				transformSideCogRight.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogRight.transform.eulerAngles, Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
				transformSideCogLeft.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogLeft.transform.eulerAngles, Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);

//				particleSystemSideCogLeft.Stop();
//				particleSystemSideCogRight.Play();
				particleSystemSideCogLeft.enableEmission = false;
				particleSystemSideCogRight.enableEmission = true;
			} else if( horizontal < 0 )
			{
				transformSideCogRight.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogRight.transform.eulerAngles, -Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
				transformSideCogLeft.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogRight.transform.eulerAngles, -Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
		
				particleSystemSideCogLeft.enableEmission = true;
				particleSystemSideCogRight.enableEmission = false;

//				particleSystemSideCogLeft.Play();
//				particleSystemSideCogRight.Stop ();
			}

			soundManager.playPanelMovementSound();
			GetComponent<Rigidbody>().MovePosition( nextPos );
		}
	}

	public void SetMoveDisable( bool v )
	{
		move = !v;
	}
}