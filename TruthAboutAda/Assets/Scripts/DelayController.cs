using UnityEngine;
using System.Collections;

public class DelayController : MonoBehaviour {

	int delayCount;
	
	SpriteRenderer delayLayer;

	float maxDelay;

	ParticleSystem particleSystem;

	Transform cylinderTransform;

	int loadedNumber;

	AudioSource audioSource;
	
	void Awake()
	{
		cylinderTransform = transform.FindChild ("animation_holder").FindChild ("cylinder").FindChild("animation_holder_cylinder").FindChild("cylinder_main").transform;
		particleSystem = transform.FindChild( Constants.PARTICLE_SYSTEM ).GetComponent<ParticleSystem>();
		audioSource = transform.GetComponent<AudioSource> ();
	}

	public void setRestDelay( float restDelay )
	{
		rotateCylinder();
		if( !audioSource.isPlaying ) audioSource.Play();

		if( maxDelay == 0 ) maxDelay = restDelay;		

		if( restDelay < maxDelay / 10 )
		{
			particleSystem.Play();
			audioSource.Stop();
		}
	}

	void rotateCylinder()
	{
		cylinderTransform.localRotation = CylinderUtility.Get.rotateCylinder( cylinderTransform.rotation.eulerAngles, loadedNumber );
	}

	public void setCylinderToNumber( int _loadedNumber )
	{
		cylinderTransform.localRotation = CylinderUtility.Get.setCylinderToValue( _loadedNumber );
	}

	public void resetDelay()
	{
		delayCount = 0;
	}

	public void setLoadedNumner( int _loadedNumber )
	{
		loadedNumber = _loadedNumber;
	}
}
