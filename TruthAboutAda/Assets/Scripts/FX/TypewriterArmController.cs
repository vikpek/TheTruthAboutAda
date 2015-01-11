using UnityEngine;

public class TypewriterArmController : MonoBehaviour {

	[SerializeField]
	float forwardAnimationSpeed = 3.0f;

	[SerializeField]
	float backwardAnimationSpeed = -0.8f;

	Animation _animation;
	Animator _animator;

	int _activeKey = 1;


	void Awake()
	{
		_animation = gameObject.GetComponent<Animation>();
		_animator = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		if(_activeKey != -1){
			if( _animator.GetCurrentAnimatorStateInfo( 0 ).normalizedTime > 1 && !_animator.IsInTransition( 0 ) ) playBackwards();
		}
	}

	public void playAnimation(int activeKey)
	{
		_activeKey = activeKey;
		_animator.speed = forwardAnimationSpeed;
		_animator.Play("TypewriterArmHit" + _activeKey);
	}

	public void playBackwards()
	{
//		_animator.speed = backwardAnimationSpeed;
//		_animator.Play("TypewriterArmHit" + _activeKey);
//		_activeKey = -1;
	}
	
}



