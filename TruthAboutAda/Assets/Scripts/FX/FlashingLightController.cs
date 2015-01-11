using UnityEngine;

public class FlashingLightController : MonoBehaviour
{

	[SerializeField]
	float intensityMax = 3f;

	[SerializeField]
	float intensityMin = 0.5f;

	[SerializeField]
	float randomnessFactor = 0.7f;

	Light flashingLight;
	
	void Awake()
	{
		flashingLight = GetComponent<Light>();
	}
	
	void Update()
	{
		float randomNummer = Random.value;
		flashingLight.enabled = true;

		if( randomNummer <= randomnessFactor ) 
			flashingLight.intensity = intensityMax;
		else 
			flashingLight.intensity = intensityMin;
	}
}