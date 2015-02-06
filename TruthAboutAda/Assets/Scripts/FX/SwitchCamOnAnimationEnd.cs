using UnityEngine;
using System.Collections;

public class SwitchCamOnAnimationEnd : MonoBehaviour
{
	[SerializeField]
	GameObject panel;

	[SerializeField]
	GameObject targetCam;

	Animator _an;

	bool start;

	void Awake()
	{
		_an = GetComponent<Animator>();
		StartCoroutine( SwitchCam() );
		if( panel == null ) panel = GameObject.Find("Panel2.0");
		panel.GetComponent<PanelShooting>().SetShootDisable( true );
		panel.GetComponent<PanelMovement>().SetMoveDisable( true );
	}

	IEnumerator SwitchCam()
	{
		while( _an.GetCurrentAnimatorStateInfo( 0 ).length == 0 ) yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds( _an.GetCurrentAnimatorStateInfo( 0 ).length );
		targetCam.SetActive( true );
		panel.GetComponent<PanelShooting>().SetShootDisable( false );
		panel.GetComponent<PanelMovement>().SetMoveDisable( false );
		gameObject.SetActive( false );
	}
}