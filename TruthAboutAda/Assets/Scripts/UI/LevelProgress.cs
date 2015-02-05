using UnityEngine;

public class LevelProgress : MonoBehaviour 
{
	bool[] level;

	// Singleton
	static LevelProgress _instance;
	
	public static LevelProgress Get
	{
		get
		{
			if( _instance == null )
			{
				_instance = GameObject.FindObjectOfType<LevelProgress>();
				if( _instance == null )
				{
					GameObject temp = new GameObject();
					_instance = temp.AddComponent<LevelProgress>();
				}
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
		level = new bool[6];
	}

	public void SetLevel( int lv )
	{
		if( lv > 0 && lv < level.Length ) level[lv] = true;
	}

	public bool GetLevel( int lv )
	{
		if( lv > 0 && lv < level.Length ) return level[lv];
		else return false;
	}

	// Presentation Hack
	void Update()
	{
		if( Input.GetKeyDown( KeyCode.U ) && Input.GetKeyDown( KeyCode.I ) && Input.GetKeyDown( KeyCode.O ) )
		{
			Debug.Log("Hack active");
			level[0] = true;
			level[1] = true;
			level[2] = true;
			level[3] = true;
			level[4] = true;
			level[5] = true;
		}
	}
}
