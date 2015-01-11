using UnityEngine;

public class GenericFXController : MonoBehaviour
{	
	static GenericFXController _instance;

	TypewriterArmController typewriterArmController;
	VerticalRailController verticalRailController;
	CameraRumbler cameraRumbler;
	
	public static GenericFXController Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<GenericFXController>();
				DontDestroyOnLoad( _instance );
				_instance.init();
			}
			return _instance;
		}
	}
	
	void Awake()
	{
		if( _instance == null ) // First Instance
		{
			_instance = this;
			DontDestroyOnLoad( this );
			init();
		} else if( this != _instance ) Destroy( gameObject );
	}

	void init()
	{
		typewriterArmController = GameObject.FindGameObjectWithTag( Tags.TYPEWRITERARM ).GetComponent<TypewriterArmController>();
		cameraRumbler = GameObject.FindGameObjectWithTag( Tags.CAMERAHOLDER ).GetComponent<CameraRumbler>();
		verticalRailController = GameObject.FindGameObjectWithTag( Tags.VERTICALRAIL ).GetComponent<VerticalRailController>();
	}

	public void playTypewriterAnimation( int activeKey )
	{
		typewriterArmController.playAnimation( activeKey );
	}

	public void rumbleCamera( float _shake, float _shakeAmount )
	{
		cameraRumbler.rumble( _shake, _shakeAmount);
	}

	public void playVerticalRailAnim()
	{
		verticalRailController.playRandomVerticalRailsAnimation();
	}
}