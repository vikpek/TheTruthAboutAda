using UnityEngine;

public class VerticalRailController : MonoBehaviour
{
	Animator _animator;
	
	void Awake()
	{
		_animator = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		if( _animator.GetCurrentAnimatorStateInfo( 0 ).normalizedTime > 1 && !_animator.IsInTransition( 0 ) )
		{
			_animator.SetTarget( AvatarTarget.Root, 0.0f );
		}
	}


	public void playRandomVerticalRailsAnimation()
	{
		// TODO random animations 
		playAnimation01();
	}

	
	void playAnimation01()
	{
		_animator.Play("VerticalRailAnim01");
	}
}
