using UnityEngine;
using System.Collections;

public class ThreatingLevel : MonoBehaviour {

	GameObject[] creeps;

	float relativeDistance;

	// Use this for initialization
	void Start () {
		InvokeRepeating("calculateDistance", 0f, 2.0f);
	}


	void calculateDistance() {
		creeps = GameObject.FindGameObjectsWithTag(Tags.CREEP);

		if(creeps.Length>0)
		{
			relativeDistance = 100f;

			foreach (GameObject creep in creeps) {
				if(creep.transform.position.y > 20f)
				{
					if((creep.transform.position.y - transform.position.y) < relativeDistance)
					{
						relativeDistance = (creep.transform.position.y - transform.position.y);
					}
				}
			}
		}

		Debug.Log(relativeDistance);
		GenericFXController.Get.rumbleCamera(1f, 5f/relativeDistance); 
	}
}
