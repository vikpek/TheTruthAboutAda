using UnityEngine;

public class PanelShooting : MonoBehaviour 
{
	public GameObject Bullet;

	[SerializeField]
	Vector3 spawnOffset = new Vector3( 0f, 1f, -3f );

	[SerializeField]
	float shootsPerSecond = 2;

	[SerializeField]
	float waitBetweenDifferentsShots = 0.2f;

	Sprite[] bullets;
	Sprite[] singleChars;

	SoundManager soundManager;
	SpriteRenderer loadedBullet;

	float shootWaiter;

	int activeKey = -1;
	int lastActiveKey = -1;

	DelayController delayController;

	void Awake()
	{
		soundManager = GameObject.FindGameObjectWithTag( Tags.GAMECONTROLLER ).GetComponent<SoundManager>();
		bullets = PrefabDB.Get.ProjectileChars();
		singleChars = PrefabDB.Get.Indicators();
		loadedBullet = transform.FindChild( "LoadedNumber" ).GetComponent<SpriteRenderer>();
		delayController = GameObject.FindGameObjectWithTag( Tags.DELAYBAR ).GetComponent<DelayController>();

		//initating first shot
		shootWaiter = 0;
		activeKey = 0;
	}
	
	void FixedUpdate()
	{
		if (shootWaiter > 0f) 
		{
			delayController.setRestDelay(shootWaiter);
			shootWaiter -= Time.fixedDeltaTime;
		}
		if( shootWaiter <= 0f ) 
		{
			setBrightness( true );
			if( activeKey != -1 ) 
			{
				if( GameConfig.Get.DebugPannelShooting ) 
					Debug.Log( "Prepare Shot" );
				float wait = ( activeKey == lastActiveKey )?( 0f ):( waitBetweenDifferentsShots );
				lastActiveKey = activeKey;
				shootWaiter = 1f / shootsPerSecond + wait;
				loadedBullet.sprite = singleChars[activeKey];
				setBrightness( false );
				if( wait == 0f )
				{
					Debug.Log( "Activate Shot" );
					((GameObject)Instantiate( Bullet, transform.position + spawnOffset, Quaternion.identity )).GetComponent<BulletController>().setBulletValue( bullets[activeKey], activeKey );
					GenericFXController.Get.playTypewriterAnimation( activeKey );
					soundManager.playPlayerShot();

					delayController.resetDelay();
				}
			}
		} else if( GameConfig.Get.DebugPannelShooting )
		{
			if( activeKey != -1 ) 
				Debug.Log("Waiting for Shot");
		}
	}

	void LateUpdate()
	{
		activeKey = scanKeys();
		if( GameConfig.Get.DebugPannelShooting )
		{
			if( activeKey != -1 ) 
				Debug.Log( System.DateTime.Now.ToLongTimeString() + " : Key Pressed ( " + activeKey + " ) " );
		}
	}

	int scanKeys() 
	{
		if( Input.GetKeyDown( KeyCode.Alpha1 ) || Input.GetKeyDown( KeyCode.Keypad1 ) ) return 1;
		if( Input.GetKeyDown( KeyCode.Alpha2 ) || Input.GetKeyDown( KeyCode.Keypad2 ) ) return 2;
		if( Input.GetKeyDown( KeyCode.Alpha3 ) || Input.GetKeyDown( KeyCode.Keypad3 ) ) return 3;
		if( Input.GetKeyDown( KeyCode.Alpha4 ) || Input.GetKeyDown( KeyCode.Keypad4 ) ) return 4;
		if( Input.GetKeyDown( KeyCode.Alpha5 ) || Input.GetKeyDown( KeyCode.Keypad5 ) ) return 5;
		if( Input.GetKeyDown( KeyCode.Alpha6 ) || Input.GetKeyDown( KeyCode.Keypad6 ) ) return 6;
		if( Input.GetKeyDown( KeyCode.Alpha7 ) || Input.GetKeyDown( KeyCode.Keypad7 ) ) return 7;
		if( Input.GetKeyDown( KeyCode.Alpha8 ) || Input.GetKeyDown( KeyCode.Keypad8 ) ) return 8;
		if( Input.GetKeyDown( KeyCode.Alpha9 ) || Input.GetKeyDown( KeyCode.Keypad9 ) ) return 9;
		if( Input.GetKeyDown( KeyCode.Alpha0 ) || Input.GetKeyDown( KeyCode.Keypad0 ) ) return 0;
		return -1;
	}

	void setBrightness( bool show )
	{
		loadedBullet.material.color = ( show )?( Color.white ):( Color.gray );
	}
}