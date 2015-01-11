using UnityEngine;
using System.Collections;

public class ProjectorLineController : MonoBehaviour 
{
	Animator _animator;
	Animation _animation;

	void Awake()
	{
		_animation = gameObject.GetComponent<Animation>();
		_animator = gameObject.GetComponent<Animator>();

		_animator.enabled = false;
	}
	
	public void playLineAnimation()
	{
		_animator.enabled = true;
		_animation.wrapMode = WrapMode.Once;
		_animation.Play ();
		_animator.enabled = false;
	}
}
