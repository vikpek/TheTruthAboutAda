using UnityEngine;
using System.Collections;

public class WaveGenerator : MonoBehaviour
{
	[SerializeField]
	WaveConfig config;

	[SerializeField]
	RowGenerator rowGen;

	[SerializeField]
	float firstWaveTimer = 3f;

	int waveCounter = 1;
	int rowCounter;

	int rowPerWaves;

	void Awake()
	{
		bool check = false;
		if( rowGen == null ) rowGen = GetComponent<RowGenerator>();
		if( rowGen == null ) Debug.LogError( "RowGenerator is not set." );
		else if( config == null ) Debug.LogError( "WaveConfig is not set." );
		else check = true;
		if( !check ) Debug.Break();
		HighScoreManager.Get.setBlock( true );
		rowPerWaves = config.RowPerWaves;
		// Start First Wave
		StartCoroutine( WaitAndGenerate( firstWaveTimer ) );
	}

	IEnumerator WaitAndGenerate( float wait )
	{
		yield return new WaitForSeconds( wait );
		StartCoroutine( WaitAndGenerate( GenerateRow() ) );
	}

	float GenerateRow()
	{
		rowCounter++;
		if( rowCounter > rowPerWaves ) 
		{
			waveCounter++;
			rowCounter = 1;
		}
		WaveConfig.RowConfig rowConfig = config.GetRowConfig( waveCounter, rowCounter );		

		rowGen.GenerateRow( rowConfig.SpawnTimer, rowConfig.MoveDelay, rowConfig.Smooth );
		foreach( WaveConfig.CreepConfig conf in rowConfig.creeps ) 
			rowGen.addEnemy( rowGen.Creep( conf.Type ), new Vector3( conf.Position, 0f ), conf.Value, conf.Smooth );

		return rowConfig.Wait + rowConfig.SpawnTimer;
	}
}