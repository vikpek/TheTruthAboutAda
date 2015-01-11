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
	            
	void FixedUpdate()
	{
		float horizontal = ( smooth )?( Input.GetAxis("Horizontal") ):( Input.GetAxisRaw("Horizontal") );
		
		if( horizontal != 0f )
		{
			Vector3 nextPos = transform.position - new Vector3( horizontal * Time.fixedDeltaTime * speed, 0f );

			// TODO linear interpolation would be nice!
			if( nextPos.x > maxXBorder ) nextPos.x = maxXBorder;
			else if( nextPos.x < minXBorder ) nextPos.x = minXBorder;

			rigidbody.MovePosition( nextPos );
		}
	}
}