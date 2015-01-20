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
	            

	Transform transformSideCogRight;
	Transform transformSideCogLeft;

	ParticleSystem particleSystemSideCogRight;
	ParticleSystem particleSystemSideCogLeft;

	void Awake()
	{
		transformSideCogRight = transform.Find("DelayCylinder/animation_holder_sidecog_right").transform;
		transformSideCogLeft = transform.Find("DelayCylinder/animation_holder_sidecog_left").transform;

		particleSystemSideCogRight = transform.Find("DelayCylinder/particle_system_sidecog_right").GetComponent<ParticleSystem>(); 
		particleSystemSideCogLeft = transform.Find("DelayCylinder/particle_system_sidecog_left").GetComponent<ParticleSystem>();

	}

	void FixedUpdate()
	{
		float horizontal = ( smooth )?( Input.GetAxis("Horizontal") ):( Input.GetAxisRaw("Horizontal") );
		
		if( horizontal != 0f )
		{
			particleSystemSideCogRight.Play();
			particleSystemSideCogLeft.Play();
			Vector3 nextPos = transform.position - new Vector3( horizontal * Time.fixedDeltaTime * speed, 0f );
		
			if( nextPos.x > maxXBorder ) nextPos.x = maxXBorder;
			else if( nextPos.x < minXBorder ) nextPos.x = minXBorder;

			if(horizontal > 0)
			{
				transformSideCogRight.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogRight.transform.eulerAngles, Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
				transformSideCogLeft.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogLeft.transform.eulerAngles, Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);

//				particleSystemSideCogLeft.Stop();
//				particleSystemSideCogRight.Play();
				particleSystemSideCogLeft.enableEmission = false;
				particleSystemSideCogRight.enableEmission = true;

			
			} else if(horizontal < 0)
			{
				transformSideCogRight.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogRight.transform.eulerAngles, -Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
				transformSideCogLeft.rotation = CylinderUtility.Get.rotatePanelCogWheel(transformSideCogRight.transform.eulerAngles, -Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
		
				particleSystemSideCogLeft.enableEmission = true;
				particleSystemSideCogRight.enableEmission = false;

//				particleSystemSideCogLeft.Play();
//				particleSystemSideCogRight.Stop ();
			}
			rigidbody.MovePosition( nextPos );
		}
	}
}