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
	AudioClip PlayerDamageShot;

	[SerializeField]
	AudioClip FallingParts;

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
}