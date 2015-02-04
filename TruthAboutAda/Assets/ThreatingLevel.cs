using UnityEngine;
using System.Collections;

public class ThreatingLevel : MonoBehaviour {

	[SerializeField]
	float _threatBottomBorder = 7f;

	GameObject[] _creeps;

	float _relativeDistance;

	// Use this for initialization
	void Start () {
		InvokeRepeating("calculateDistance", 0f, 2.0f);
	}


	void calculateDistance() {
		_creeps = GameObject.FindGameObjectsWithTag(Tags.CREEP);

		if(_creeps.Length>0)
		{
			_relativeDistance = 100f;

			foreach (GameObject creep in _creeps) {
				if(creep.transform.position.y > 20f)
				{
					if((creep.transform.position.y - transform.position.y) < _relativeDistance)
					{
						_relativeDistance = (creep.transform.position.y - transform.position.y);
					}
				}
			}
		}

		Debug.Log(_relativeDistance);
		if(_relativeDistance < _threatBottomBorder && _relativeDistance != 0){
			GenericFXController.Get.rumbleCamera(1f, 1f/_relativeDistance); 
		}
	}
}
