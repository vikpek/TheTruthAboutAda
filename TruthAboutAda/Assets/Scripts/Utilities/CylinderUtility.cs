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
		return Quaternion.Euler (new Vector3 (0, eulerAngles.y + (cylinderValue * Constants.CYLINDER_ROTATION), 0));
	}



}
