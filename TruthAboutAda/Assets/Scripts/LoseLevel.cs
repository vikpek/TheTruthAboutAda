using UnityEngine;
using System.Collections;

public class LoseLevel : MonoBehaviour
{

	void OnCollisionEnter( Collision col )
	{
		if( col.gameObject.tag == Tags.CREEP ) {
			transform.GetComponent<TheEventNoTime>().enabled = true;
//			StartCoroutine(waitAndLoose(3f));
		}
	}

	IEnumerator waitAndLoose( float time )
	{
		yield return new WaitForSeconds( time );
		GameObject.FindWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>().SetGameOver();

	}
}