using UnityEngine;

public class WaveConfig : MonoBehaviour
{
	public struct CreepConfig
	{
		public float Position;
		public float Smooth;
		public int Value;
		public int Type;
	}

	public struct RowConfig
	{
		public CreepConfig[] creeps;
		// RowConfig
		public float SpawnTimer;
		public float MoveDelay;
		public float Smooth;
	}

	// Basic
	public int RowPerWaves;

	// ROW CONFIGURATION
	// Init
	public float InitSpawnTimer = 5f;
	public float InitMoveDelay = 3f;
	public float InitSmooth = 0.5f;

	// Multiplyer
	public float MultiSpawnTimer = -0.2f;
	public float MultiMoveDelay = -0.2f;
	public float MultiSmooth = 0f;

	// RowDiffer
	public float RowMultiSpawnTimer = 0f;
	public float RowMultiMoveDelay = 0f;
	public float RowMultiSmooth = 0f;

	// Max
	public float MaxSpawnTimer = 10f;
	public float MaxMoveDelay = 5f;
	public float MaxSmooth = 1f;

	// Min
	public float MinSpawnTimer = 1f;
	public float MinMoveDelay = 0.5f;
	public float MinSmooth = 0.1f;

	// CREEP CONFIGURATION
	// Max
	public int Creep_MaxCounter = 5;
	public float Creep_MaxPosition = 10f;
	public float Creep_MaxSmooth = 1f;
	public int Creep_MaxRandomTrys = 10;

	// Min
	public int Creep_MinCounter = 1;
	public float Creep_MinPosition = -10f;
	public float Creep_MinDifPos = 0.5f;
	public float Creep_MinSmooth = -1f;

	RowConfig temp;

	public virtual RowConfig GetRowConfig( int wave, int row )
	{
		temp = new RowConfig();
		// ROW CONFIGURATION
		// SpawnTimer
		temp.SpawnTimer = InitSpawnTimer + wave * MultiSpawnTimer + row * RowMultiSpawnTimer;
		if( temp.SpawnTimer > MaxSpawnTimer ) temp.SpawnTimer = MaxSpawnTimer;
		else if( temp.SpawnTimer < MinSpawnTimer ) temp.SpawnTimer = MinSpawnTimer;

		// MoveDelay
		temp.MoveDelay = InitMoveDelay + wave * MultiMoveDelay + row * RowMultiMoveDelay;
		if( temp.MoveDelay > MaxMoveDelay ) temp.MoveDelay = MaxMoveDelay;
		else if( temp.MoveDelay < MinMoveDelay ) temp.MoveDelay = MinMoveDelay;

		// Smooth
		temp.Smooth = InitSmooth + wave * MultiSmooth + row * RowMultiSmooth;
		if( temp.Smooth > MaxSmooth ) temp.Smooth = MaxSmooth;
		else if( temp.Smooth < MinSmooth ) temp.Smooth = MinSmooth;

		// CREEP CONFIGURATION
		float lastPos = 12f;
		temp.creeps = new CreepConfig[Random.Range( Creep_MinCounter, Creep_MaxCounter )];
		for( int i = 0; i < temp.creeps.Length; i++ )
		{
			CreepConfig creep;
			creep.Value = Random.Range( 0, 9 );
			creep.Position = Random.Range( Creep_MinPosition, Creep_MaxPosition );

			int counter = 0;
			bool run = checkRange( Creep_MinDifPos, creep.Position );

			while( run )
			{
				// Process
				creep.Position = creep.Position = Random.Range( Creep_MinPosition, Creep_MaxPosition );
				// Check
				counter++;
				if( counter > Creep_MaxRandomTrys ) run = false;
				else run = checkRange( Creep_MinDifPos, creep.Position );
			}
			float smooth = Random.Range( Creep_MinSmooth, Creep_MaxSmooth );
			if( smooth > 0.1f || smooth < -0.1f ) creep.Smooth = smooth; else creep.Smooth = 0f;
			int type = Random.Range( 0, 6 );
			if( type == 6 ) creep.Type = 2;
			else if( type == 5 || type == 4 ) creep.Type = 1;
			else creep.Type = 0;
			// Add to RowConfig
			temp.creeps[i] = creep;
		}

		return temp;
	}

	bool checkRange( float MinDif, float CurrentPos )
	{
		for( int i = 0; i < temp.creeps.Length; i++ )
			if( Mathf.Abs( temp.creeps[i].Position - CurrentPos ) < MinDif ) return true;
		return false;
	}
}