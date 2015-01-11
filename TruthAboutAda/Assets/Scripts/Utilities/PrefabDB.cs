using UnityEngine;

public class PrefabDB : MonoBehaviour
{
	const string SINGLE_CHARS = "AP_Creeps_Digits_Single";
	const string BODY_CHARS = "AP_Creeps_Body";
	const string PROJECTILE_CHARS = "AP_Creeps_Digits_Projectiles";
	const string MALUS = "AP_Creeps_Malus";
	const string INDICATOR = "AP_Creeps_Indicator";
	const string LIFE = "AP_Creeps_Life";

	Sprite[] singleChars;
	Sprite[] bodyChars;
	Sprite[] projectileChars;
	Sprite[] malus;
	Sprite[] indicator;
	Sprite[] life;

	Texture[] creepTextures;

	[SerializeField]
	GameObject VerticalRailObject;

	// Singleton
	static PrefabDB _instance;

	public static PrefabDB Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<PrefabDB>();
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
	// Helper functions
	void init()
	{
		string path = "Textures/Chars/";
		singleChars = Resources.LoadAll<Sprite>( path + SINGLE_CHARS );
		bodyChars = Resources.LoadAll<Sprite>( path + BODY_CHARS );
		projectileChars = Resources.LoadAll<Sprite>( path + PROJECTILE_CHARS );
		malus = Resources.LoadAll<Sprite>( path + MALUS );
		indicator = Resources.LoadAll<Sprite>( path + INDICATOR );
		life = Resources.LoadAll<Sprite>( path + LIFE );
		creepTextures = Resources.LoadAll<Texture> ("Textures/CreepTextures/");
	}


	public Texture[] CreepTextures()
	{
		return creepTextures;
	}

	public Sprite[] SingleChars()
	{
		return singleChars;
	}

	public Sprite[] BodyChars()
	{
		return bodyChars;
	}

	public Sprite[] ProjectileChars()
	{
		return projectileChars;
	}

	public GameObject VerticalRail()
	{
		return VerticalRailObject;
	}

	public Sprite[] Malus()
	{
		return malus;
	}

	public Sprite[] Indicators()
	{
		return indicator;
	}

	public Sprite[] Life()
	{
		return life;
	}
}