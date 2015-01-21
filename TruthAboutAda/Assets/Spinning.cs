using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {

	[SerializeField]
	float speed = 10f;

	[SerializeField]
	bool direction;


	void Update ()
	{if (direction == true) {
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
		} else {
			transform.Rotate(Vector3.left, speed * Time.deltaTime);
		}
	}
}
