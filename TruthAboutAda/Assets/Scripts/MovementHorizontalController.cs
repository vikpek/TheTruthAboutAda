using UnityEngine;
using System.Collections;

public class MovementHorizontalController : MonoBehaviour {

	bool moving;

	float minX = -10; 
	float maxX = 7;

	public float smooth = 0.1f;

	[SerializeField]
	bool lerp;

	Vector3 move;

	public bool directionRight = true;
	
	void Awake()
	{
		move = transform.localPosition;
		Transform temp = transform.parent.Find( Constants.HORIZONTALRAIL );
		if( temp == null ) temp = transform.parent.parent.Find( Constants.HORIZONTALRAIL );
		if( temp == null ) temp = transform.parent.parent.parent.Find( Constants.HORIZONTALRAIL );
		if( temp == null )
		{
			Debug.LogError("Coudlnt find HorizontalRail... Borders set to -10 & 7");
			minX = -10;
			maxX = 7;
		} else
		{
			minX = temp.FindChild("right_border").transform.position.x;
			maxX = temp.FindChild("left_border").transform.position.x;
		}
	}

	void FixedUpdate()
	{	
		if( !( transform.localPosition.x > minX && transform.localPosition.x < maxX ) ) directionRight = !directionRight;
	
		if( directionRight ) move.x = maxX;
		else if( !directionRight ) move.x = minX;

		if( lerp ) transform.localPosition = Vector3.Lerp( transform.localPosition, move, smooth * Time.fixedDeltaTime );
		else transform.localPosition = Vector3.MoveTowards( transform.localPosition, move, smooth * Time.fixedDeltaTime );
	}

	void OnTriggerEnter( Collider col )
	{
		if( col.tag != Tags.BULLET ) directionRight = !directionRight;
	}
}
