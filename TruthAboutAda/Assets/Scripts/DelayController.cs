using UnityEngine;
using System.Collections;

public class DelayController : MonoBehaviour {

	int delayCount = 0;
	
	SpriteRenderer delayLayer;

	float maxDelay = 0;

	ParticleSystem particleSystem;

	Transform cylinderTransform;

	int loadedNumber = 0;

	AudioSource audioSource;
	
	void Awake()
	{
		cylinderTransform = transform.FindChild ("animation_holder").FindChild ("cylinder").FindChild("animation_holder_cylinder").transform;
		particleSystem = transform.FindChild (Constants.PARTICLE_SYSTEM).GetComponent<ParticleSystem> ();
		audioSource = transform.GetComponent<AudioSource> ();
	}

	public void setRestDelay(float restDelay)
	{
		rotateCylinder();
		if (!audioSource.isPlaying) {
			audioSource.Play ();
		}

		if (maxDelay == 0) {
			maxDelay = restDelay;		
		}

		if (restDelay < maxDelay / 10) {
			setCylinderToNumber(loadedNumber);
			particleSystem.Play();
			audioSource.Stop ();
		}
	}

	void rotateCylinder(){
		cylinderTransform.rotation = Quaternion.Euler( new Vector3( 0, cylinderTransform.rotation.eulerAngles.y + ( Random.Range (0, 9) * 9 ), 0 ) );
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
