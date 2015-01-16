using UnityEngine;
using System.Collections;

public class CylinderUtility : MonoBehaviour {
	// Singleton
	static CylinderUtility _instance;
	
	public static CylinderUtility Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<CylinderUtility>();
				DontDestroyOnLoad( _instance );
			}
			return _instance;
		}
	}

	public Quaternion rotateCylinder (Vector3 eulerAngles, float cylinderValue)
	{
			return Quaternion.Euler (new Vector3 (0, eulerAngles.y + (cylinderValue * Constants.CYLINDER_ROTATION_ANIMATION), 0));
	}

	public Quaternion setCylinderToValue (float cylinderValue)
	{
		return Quaternion.Euler (new Vector3 (0, cylinderValue * Constants.CYLINDER_ROTATION, 0));
	}

	public Quaternion damageCylinder (Vector3 eulerAngles, float cylinderValue)
	{
		return Quaternion.Euler (new Vector3 (eulerAngles.y + Random.Range(-20,20), 0, eulerAngles.y + Random.Range(-10, 10)));
	}

	public Quaternion shakeCylinder (float shakingTime)
	{
		return Quaternion.Euler( new Vector3 (0,0, Random.Range(-20, 20) * shakingTime));
	}
}
