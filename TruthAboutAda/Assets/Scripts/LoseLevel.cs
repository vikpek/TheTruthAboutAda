using UnityEngine;
using System.Collections;

public class LoseLevel : MonoBehaviour
{
	bool _lock;

	void OnCollisionEnter( Collision col )
	{
		if( col.gameObject.tag == Tags.CREEP  && !_lock ) 
		{
			Debug.Log( col.gameObject.name );
			_lock = true;
			HighScoreManager.Get.printHighScore();
			transform.GetComponent<TheEventNoTime>().enabled = true;
		}
	}
}