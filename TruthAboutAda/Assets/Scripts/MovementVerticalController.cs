using UnityEngine;
using System.Collections;

public class MovementVerticalController : MonoBehaviour {

	bool moving;

	[SerializeField]
	float minY = 45; 

	public float smooth = 5f;

	Vector3 move;
	Vector3 startPosition;

	int aliveCreeps;

	void Awake()
	{
		move = transform.position;
		startPosition = transform.position;
		findChild( transform );
		Debug.Log( "Row with : " + aliveCreeps );
		HighScoreManager.Get.addCreeps( aliveCreeps );
	}

	void FixedUpdate()
	{
		move.y = minY;
		transform.position = Vector3.MoveTowards(transform.position, move, smooth * Time.fixedDeltaTime);
	}

	void findChild( Transform parent )
	{
		if( parent.childCount > 0 )
		{
			foreach( Transform child in parent )
				if( child.tag == Tags.CREEP ) aliveCreeps++;
				else if( child.tag == "Untagged" ) findChild( child );
		}
	}

	public void CreepKill()
	{
		aliveCreeps--;
		if( aliveCreeps <= 0 ) Destroy( gameObject );
	}
}
