using UnityEngine;
using System.Collections;

public class RowSpawner : MonoBehaviour 
{
	public float spawnTimer = 1.5f;

	Animator animator;

	[SerializeField]
	bool incomingAnimation = true;

	public float movementStartDelay = 3;

	int aliveCreeps;

	bool spawn;
	bool move;

	void Awake()
	{
		movementStartDelay += spawnTimer;
		animator = transform.GetComponent<Animator>();
		foreach( Transform child in transform ) child.gameObject.SetActive( false );
		GetComponent<MovementVerticalController>().enabled = false;
	}

	void FixedUpdate()
	{
		if( !spawn )
		{
			if( spawnTimer > 0f ) spawnTimer -= Time.fixedDeltaTime;
			if( incomingAnimation && spawnTimer <= 0f )
			{
				animator.enabled = true;
				animator.Play( "RowAnimation" );
				foreach( Transform child in transform ) child.gameObject.SetActive( true );
				GetComponent<MovementVerticalController>().enabled = true;
				// count childs
				findChild( transform );
				Debug.Log( "Row with : " + aliveCreeps );
				HighScoreManager.Get.addCreeps( aliveCreeps );
				spawn = true;
			}
		}
		if( !move )
		{
			if( movementStartDelay > 0f ) movementStartDelay -= Time.fixedDeltaTime;
			if( movementStartDelay <= 0f )
			{
				foreach( Transform child in transform )
				{
					child.gameObject.SetActive( true );
					if(child.GetComponent<MovementHorizontalController>())	child.GetComponent<MovementHorizontalController>().enabled = true;
					if(child.GetComponent<MovementVerticalController>()) child.GetComponent<MovementVerticalController>().enabled = true;
				}
				animator.enabled = false;
				move = true;
			}
		}
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