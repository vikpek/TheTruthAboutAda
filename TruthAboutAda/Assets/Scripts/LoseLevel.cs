using UnityEngine;
using System.Collections;

public class LoseLevel : MonoBehaviour
{

	UIController uiController;
	bool _lock;

	void Awake(){
		uiController = GameObject.FindWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>();
	}

	void OnCollisionEnter( Collision col )
	{
		if( col.gameObject.tag == Tags.CREEP  && !_lock) {
			_lock = true;
			transform.GetComponent<TheEventNoTime>().enabled = true;
			StartCoroutine(waitAndLoose(3f));
		}
	}

	IEnumerator waitAndLoose( float time )
	{
		yield return new WaitForSeconds( time );
		uiController.BackToMenu();

	}
}