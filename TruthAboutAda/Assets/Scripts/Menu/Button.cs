using UnityEngine;

public class Button : MonoBehaviour
{
	[SerializeField]
	GameObject regular;

	[SerializeField]
	GameObject hover;
	
	void OnMouseEnter()
	{
		regular.SetActive( false );
		hover.SetActive( true );
	}
	
	void OnMouseExit()
	{
		regular.SetActive( true );
		hover.SetActive( false );
	}
}
