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
	            

	Transform cogwheel1Transform;
	Transform cogwheel2Transform;

	void Awake()
	{
		cogwheel1Transform = transform.FindChild("DelayCylinder").FindChild("animation_holder_sidecog1").transform;
		cogwheel2Transform = transform.FindChild("DelayCylinder").FindChild("animation_holder_sidecog2").transform;
	}

	void FixedUpdate()
	{
		float horizontal = ( smooth )?( Input.GetAxis("Horizontal") ):( Input.GetAxisRaw("Horizontal") );
		
		if( horizontal != 0f )
		{
			Vector3 nextPos = transform.position - new Vector3( horizontal * Time.fixedDeltaTime * speed, 0f );

			// TODO linear interpolation would be nice!
			if( nextPos.x > maxXBorder ) nextPos.x = maxXBorder;
			else if( nextPos.x < minXBorder ) nextPos.x = minXBorder;

			if(horizontal>0)
			{
				cogwheel1Transform.rotation = CylinderUtility.Get.rotatePanelCogWheel(cogwheel1Transform.transform.eulerAngles, Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
				cogwheel2Transform.rotation = CylinderUtility.Get.rotatePanelCogWheel(cogwheel2Transform.transform.eulerAngles, Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
			} else if(horizontal<0)
			{
				cogwheel1Transform.rotation = CylinderUtility.Get.rotatePanelCogWheel(cogwheel1Transform.transform.eulerAngles, -Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
				cogwheel2Transform.rotation = CylinderUtility.Get.rotatePanelCogWheel(cogwheel1Transform.transform.eulerAngles, -Constants.PANEL_COGWHEEL_ROTATION_ANIMATION);
			}

			rigidbody.MovePosition( nextPos );
		}
	}
}