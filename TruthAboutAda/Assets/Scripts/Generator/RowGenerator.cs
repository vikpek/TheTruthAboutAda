using UnityEngine;

public class RowGenerator : MonoBehaviour 
{

	[SerializeField]
	GameObject basicRow;

	[SerializeField]
	GameObject creepRegular;

	[SerializeField]
	GameObject creepSilver;

	[SerializeField]
	GameObject creepBlack;

	[SerializeField]
	GameObject creepGhost;

	GameObject temp = null;

	public enum Creeps
	{
		Ghost = -1,
		Regular = 0,
		Silver = 1,
		Black = 2
	};

	void Awake()
	{
		bool check = false;
		// check for Prefab sets
		if( basicRow == null ) Debug.LogError( "EnemyRow Prefab not set." );
		else if( creepRegular == null ) Debug.LogError( "CreepRegular Prefab not set." );
		else if( creepSilver == null ) Debug.LogError( "CreepSilver Prefab not set." );
		else if( creepBlack == null ) Debug.LogError( "CreepBlack Prefab not set." );
		else if( creepGhost == null ) Debug.LogError( "CreepGhost Prefab not set." );
		else check = true;
		if( !check ) Debug.Break();
		creepRegular.SetActive( false );
		creepSilver.SetActive( false );
		creepBlack.SetActive( false );
	}

	public void GenerateRow( float spawnTimer, float movementStartDelay, float smooth )
	{
		temp = (GameObject)Instantiate( basicRow );
		temp.name = temp.name.Substring( 0, temp.name.Length - 7 );
		// Configuration
		RowSpawner c0 = temp.GetComponent<RowSpawner>();
		c0.spawnTimer = spawnTimer;
		c0.movementStartDelay = movementStartDelay + spawnTimer;
		temp.GetComponent<MovementVerticalController>().smooth = smooth;
	}

	public void addEnemy( Creeps type, Vector3 pos, int value = -1, float smoothMove = 0f )
	{
		if( temp != null )
		{
			GameObject enemy = null;
			switch( type )
			{
				case Creeps.Regular :
					enemy = (GameObject)Instantiate( creepRegular );
					break;
				case Creeps.Silver :
					enemy = (GameObject)Instantiate( creepSilver );
					break;
				case Creeps.Black :
					enemy = (GameObject)Instantiate( creepBlack );
					break;
				case Creeps.Ghost :
					enemy = (GameObject)Instantiate( creepGhost );
					break;
				default :
					Debug.LogWarning( "Unkown enemy type : " + type );
					break;
			}
			if( enemy != null )
			{
				enemy.name = enemy.name.Substring( 0, enemy.name.Length - 7 );
				enemy.transform.parent = temp.transform;
				enemy.transform.localPosition = pos;
				if( type != Creeps.Ghost )
				{
					enemy.SetActive( false );
					if( value >= 0 && value <= 9 )
					{
						enemy.GetComponent<CreepController3D>().randomized = false;
						enemy.GetComponent<CreepController3D>().cylinderValue = value;
					}
				}
				if( smoothMove != 0f )
				{
					MovementHorizontalController controll = enemy.GetComponent<MovementHorizontalController>();
					if( controll == null ) controll = enemy.AddComponent<MovementHorizontalController>();
					controll.smooth = Mathf.Abs( smoothMove );
					if( smoothMove < 0f ) controll.directionRight = false;
				}
			}
		} else Debug.LogWarning( "BasicRow is missing." );
	}

	public Creeps Creep( int type )
	{
		switch( type )
		{
			case -1 :
				return Creeps.Ghost;
			case 0 :
				return Creeps.Regular;
			case 1 :
				return Creeps.Silver;
			case 2 :
				return Creeps.Black;
			default :
				Debug.LogWarning("Unkown CreepType : " + type );
				return Creeps.Regular;
		}
	}
}