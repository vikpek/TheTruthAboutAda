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
		public float Wait;
	}

	// Basic
	public int RowPerWaves = 5;

	// ROW CONFIGURATION
	// Init
	public float InitSpawnTimer = 5f;
	public float InitMoveDelay = 3f;
	public float InitSmooth = 0.5f;
	public float InitWaitRows = 3f;

	// Multiplyer
	public float MultiSpawnTimer = -0.2f;
	public float MultiMoveDelay = -0.2f;
	public float MultiSmooth = 0f;
	public float MultiWaitRows = -0.5f;

	// RowDiffer
	public float RowMultiSpawnTimer = 0f;
	public float RowMultiMoveDelay = 0f;
	public float RowMultiSmooth = 0f;
	public float RowMultiWaitRows = 0f;

	// Max
	public float MaxSpawnTimer = 10f;
	public float MaxMoveDelay = 5f;
	public float MaxSmooth = 1f;
	public float MaxWaitRows = 3f;

	// Min
	public float MinSpawnTimer = 1f;
	public float MinMoveDelay = 0.5f;
	public float MinSmooth = 0.1f;
	public float MinWaitRows = 0.5f;

	// CREEP CONFIGURATION
	// Max
	public int Creep_MaxCounter = 5;
	public float Creep_MaxPosition = 10f;
	public float Creep_MaxSmooth = 1f;
	public int Creep_MaxRandomTrys = 10;

	// Min
	public int Creep_MinCounter = 1;
	public float Creep_MinPosition = -10f;
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

		// Wait
		temp.Wait = InitWaitRows + wave * MultiWaitRows + row * RowMultiWaitRows;
		if( temp.Wait > MaxWaitRows ) temp.Wait = MaxWaitRows;
		else if( temp.Wait < MinWaitRows ) temp.Wait = MinWaitRows;

		// CREEP CONFIGURATION
		temp.creeps = new CreepConfig[Random.Range( Creep_MinCounter, Creep_MaxCounter )];
		float space = 0f;
		float startPos = 0f;
		if( temp.creeps.Length != 1 ) 
		{
			space = ( Creep_MaxPosition - Creep_MinPosition ) / ( temp.creeps.Length - 1 );
			startPos = Creep_MinPosition;
		}
		for( int i = 0; i < temp.creeps.Length; i++ )
		{
			CreepConfig creep;
			creep.Value = Random.Range( 0, 9 );
			creep.Position = startPos;
			startPos += space;
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
}