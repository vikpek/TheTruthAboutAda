using UnityEngine;

public class RowSpawner : MonoBehaviour 
{
	[SerializeField]
	float spawnTimer = 1.5f;

	[SerializeField]
	Animator animator;

	[SerializeField]
	bool incomingAnimation = true;

	[SerializeField]
	float movementStartDelay = 3;

	void Awake()
	{
		setRowActive(false);
	}

	void Update()
	{
		spawnTimer -= Time.deltaTime;
		if (incomingAnimation && spawnTimer <= 0f && animator.enabled) {
			animator.enabled = true;
			animator.Play ("RowAnimation");
			setRowActive(true);
			setCreepMovementActive(false);
		}

		if( movementStartDelay > 0f ) movementStartDelay -= Time.fixedDeltaTime;
		if (movementStartDelay <= 0f) {
			Debug.Log ("moving start");
			setRowActive(true);
			setCreepMovementActive(true);
			animator.enabled = false;
		}
	}

	void setRowActive(bool active)
	{
		foreach (Transform child in transform){
			child.gameObject.SetActive (active);
		}
	}

	void setCreepMovementActive(bool active)
	{
		foreach (Transform child in transform){
				child.GetComponent<CreepMovement>().enabled = active;
		}
	}
}