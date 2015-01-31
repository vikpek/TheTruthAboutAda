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

		// TODO : Inplement RowConfig Usage

		rowGen.GenerateRow( 5f, 7f, 0.5f );
		rowGen.addEnemy( RowGenerator.Creeps.Regular, Vector3.zero );

		return 10f;
	}
}