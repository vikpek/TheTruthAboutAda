using UnityEngine;
using System.Collections;

public class DelayController : MonoBehaviour {

	int delayCount = 0;

	Sprite[] singleSprites;
	SpriteRenderer delayLayer;

	float maxDelay = 0;

	ParticleSystem particleSystem;
	
	void Awake()
	{
		singleSprites = PrefabDB.Get.Life();
		delayLayer = transform.FindChild( Constants.DELAY_LAYER ).GetComponent<SpriteRenderer>();
		delayLayer.sprite = singleSprites [delayCount];

		particleSystem = transform.FindChild (Constants.PARTICLE_SYSTEM).GetComponent<ParticleSystem> ();
	}
	
	public void reduceRestDelay()
	{
		delayCount ++;
		delayLayer.sprite = singleSprites [delayCount];
	}

	public void setRestDelay(float restDelay)
	{
		if (maxDelay == 0) {
			maxDelay = restDelay;		
		}

		if (restDelay < maxDelay) 
		{
			delayLayer.sprite = singleSprites [0];		
			particleSystem.Stop();
		}
		if (restDelay < maxDelay / 2) {
			delayLayer.sprite = singleSprites [1];		
		}
		if (restDelay < maxDelay / 4) {
			delayLayer.sprite = singleSprites [2];		
		}
		if (restDelay < maxDelay / 10) {
			delayLayer.sprite = singleSprites [3];		
			particleSystem.Play();
		}
	}
	
	public void resetDelay()
	{
		delayCount = 0;
	}
}
