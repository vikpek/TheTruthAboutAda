using UnityEngine;
using System.Collections;

public class DelayController : MonoBehaviour {

	int delayCount = 0;
	
	SpriteRenderer delayLayer;

	float maxDelay = 0;

	ParticleSystem particleSystem;

	Transform cylinderTransform;

	int loadedNumber = 0;
	
	void Awake()
	{
		cylinderTransform = transform.FindChild ("animation_holder").FindChild ("cylinder").FindChild("animation_holder_cylinder").transform;
		particleSystem = transform.FindChild (Constants.PARTICLE_SYSTEM).GetComponent<ParticleSystem> ();
	}

	public void setRestDelay(float restDelay)
	{
		rotateCylinder();
		if (maxDelay == 0) {
			maxDelay = restDelay;		
		}

		if (restDelay < maxDelay) 
		{
//			delayLayer.sprite = singleSprites [0];		
			particleSystem.Stop();
		}
		if (restDelay < maxDelay / 2) {
//			delayLayer.sprite = singleSprites [1];		
		}
		if (restDelay < maxDelay / 4) {
//			delayLayer.sprite = singleSprites [2];		
		}
		if (restDelay < maxDelay / 10) {
			setCylinderToNumber(loadedNumber);
			particleSystem.Play();
		}
	}

	void rotateCylinder(){
		cylinderTransform.rotation = Quaternion.Euler( new Vector3( 0, cylinderTransform.rotation.eulerAngles.y + ( Random.Range (0, 9) * 36 ), 0 ) );
	}

	void setCylinderToNumber(int loadedNumber)
	{
		cylinderTransform.rotation = Quaternion.Euler( new Vector3( 0,  (loadedNumber-1) * 36 , 0 ) );
	}

	public void resetDelay()
	{
		delayCount = 0;
	}

	public void setLoadedNumner(int _loadedNumber)
	{
		loadedNumber = _loadedNumber;
	}
}
