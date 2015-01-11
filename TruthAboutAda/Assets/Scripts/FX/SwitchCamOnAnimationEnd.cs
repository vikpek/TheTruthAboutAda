using UnityEngine;
using System.Collections;

public class SwitchCamOnAnimationEnd : MonoBehaviour
{
	[SerializeField]
	GameObject targetCam;

	Animator _an;

	bool start;

	void Awake()
	{
		_an = GetComponent<Animator>();
		StartCoroutine( SwitchCam() );
	}

	IEnumerator SwitchCam()
	{
		while( _an.GetCurrentAnimatorStateInfo( 0 ).length == 0 ) yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds( _an.GetCurrentAnimatorStateInfo( 0 ).length );
		targetCam.SetActive( true );
		gameObject.SetActive( false );
	}
}