using UnityEngine;

public class SoundManager : MonoBehaviour
{
	AudioSource audioSource;

	[SerializeField]
	AudioClip PlayerDeath;
		
	[SerializeField]
	AudioClip EnemyDeath;
		
	[SerializeField]
	AudioClip PlayerShot;

	[SerializeField]
	AudioClip EnemyShot;
		
	[SerializeField]
	AudioClip GameBackgroundLoop;

	[SerializeField]
	AudioClip MenuBackgroundLoop;

	[SerializeField]
	AudioClip FailedShot;

	[SerializeField]
	AudioClip CreepExplosion;

	[SerializeField]
	AudioClip CreepExplosion2;

	[SerializeField]
	AudioClip CreepExplosionBlackCreep;

	[SerializeField]
	AudioClip PlayerDamageShot;

	[SerializeField]
	AudioClip FallingParts;

	[SerializeField]
	AudioClip Lightning;

	[SerializeField]
	AudioClip PanelRotation;

	[SerializeField]
	AudioClip HighscoreRotation;

	[SerializeField]
	AudioClip CreepCylinderRotation;

	[SerializeField]
	AudioClip PanelMovementSound;

	void Start()
	{	
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.PlayOneShot( GameBackgroundLoop );
	}
	
	public void playPlayerDeath()
	{
		if( PlayerDeath != null ) audioSource.PlayOneShot( PlayerDeath );
	}

	public void playFallingParts()
	{
		if( FallingParts != null ) audioSource.PlayOneShot( FallingParts );
	}

	public void playPlayerDamageShot()
	{
		if( PlayerDamageShot != null ) audioSource.PlayOneShot( PlayerDamageShot );
	}


	public void playCreepExplosion()
	{
		if( CreepExplosion != null ) audioSource.PlayOneShot( CreepExplosion );
	}

	public void playCreepExplosion2()
	{
		if( CreepExplosion2 != null ) audioSource.PlayOneShot( CreepExplosion2 );
	}

	public void playCreepExplosionBlackCreep()
	{
		if( CreepExplosionBlackCreep != null ) audioSource.PlayOneShot( CreepExplosionBlackCreep );
	}

	public void playFailedShot()
	{
		if( FailedShot != null ) audioSource.PlayOneShot( FailedShot );
	}
	
	public void playPlayerShot()
	{
		if( PlayerShot != null ) audioSource.PlayOneShot( PlayerShot );
	}
	
	public void playEnemyDeath()
	{
		if( EnemyDeath != null ) audioSource.PlayOneShot( EnemyDeath );
	}
	
	public void playEnemyShot()
	{
		if( EnemyShot != null ) audioSource.PlayOneShot( EnemyShot );
	}
	
	public void playGameBackgroundLoop()
	{
		if( GameBackgroundLoop != null) audioSource.PlayOneShot( GameBackgroundLoop );
	}
	
	public void playMenuBackgroundLoop ()
	{
		if( MenuBackgroundLoop != null ) audioSource.PlayOneShot( MenuBackgroundLoop );
	}	

	public void playLightning ()
	{
		if( Lightning != null ) audioSource.PlayOneShot( Lightning );
	}	
	
	public void playPanelRotation ()
	{
		if( PanelRotation != null ) audioSource.PlayOneShot( PanelRotation );
	}	

	public void playHighscoreRotation ()
	{
		if( HighscoreRotation != null ) audioSource.PlayOneShot( HighscoreRotation );
	}	

	public void playCreepCylinderRotation ()
	{
		if( CreepCylinderRotation != null ) audioSource.PlayOneShot( CreepCylinderRotation );
	}

	public void playPanelMovementSound ()
	{

		if( PanelMovementSound != null ) {
			if(!audioSource.isPlaying){
					audioSource.PlayOneShot( PanelMovementSound );
			}
		}
	}
}