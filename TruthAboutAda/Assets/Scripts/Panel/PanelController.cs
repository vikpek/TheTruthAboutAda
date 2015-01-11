using UnityEngine;

public class PanelController : MonoBehaviour 
{

	SoundManager soundManager;
	LifeController lifeController;

	void Awake()
	{
		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		lifeController = GameObject.FindGameObjectWithTag( Tags.LIFEBAR ).GetComponent<LifeController>();
	}

	void OnTriggerEnter( Collider collider )
	{
		Col( collider.gameObject );
	}

	void OnCollisionEnter( Collision col )
	{
		Col( col.gameObject );
	}

	void Col( GameObject obj )
	{
		if( obj.tag == Tags.CREEPBULLET )
		{
			Destroy( obj );
			lifeController.decreaseLife();
			if( lifeController.getLifeCount() < 1 )
			{
				GenericFXController.Get.rumbleCamera(0.8f, 0.4f);
				foreach( GameObject t in GameObject.FindGameObjectsWithTag( Tags.BULLET ) ) Destroy( t );
				Destroy( gameObject );
			} else GenericFXController.Get.rumbleCamera(0.2f, 0.1f);
			soundManager.playPlayerDeath();
		}
	}
}
