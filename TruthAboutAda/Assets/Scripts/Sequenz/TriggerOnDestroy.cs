using UnityEngine;

public class TriggerOnDestroy : MonoBehaviour
{
	[SerializeField]
	GameObject target;

	void OnDestroy()
	{
		Debug.Log("Trigger");
		target.SetActive( true );
		this.enabled = false;
	}
}