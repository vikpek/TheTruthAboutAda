using UnityEngine;

public class LoseLevel : MonoBehaviour
{

	void OnCollisionEnter( Collision col )
	{
		if( col.gameObject.tag == Tags.CREEP )  GameObject.FindWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>().SetGameOver();
	}
}