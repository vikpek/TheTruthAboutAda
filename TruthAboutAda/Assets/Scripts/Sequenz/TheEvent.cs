﻿using UnityEngine;

public class TheEvent : MonoBehaviour
{
	enum Effects
	{
		None,
		Fade
	}

	[SerializeField]
	bool hideThemself = true;

	[SerializeField]
	bool triggerAfterDisappear = false;

	[SerializeField]
	bool skipWholeEvent = false;

	[SerializeField]
	float Duration = 1f;

	[SerializeField]
	GameObject nextEvent;

	[SerializeField]
	GameObject hideEvent;

	[SerializeField]
	Effects appearEffect = Effects.None;
	
	[SerializeField]
	float appearDuration = 1f;

	[SerializeField]
	Vector2 appearVisibility = new Vector2( 0f, 1f );

	[SerializeField]
	Effects disappearEffect = Effects.None;

	[SerializeField]
	float disappearDuration = 1f;

	[SerializeField]
	Vector2 disappearVisibility = new Vector2( 1f, 0f );

	[SerializeField]
	bool canBeSkipped = true;

	[SerializeField]
	bool triggerOnSkip;

	[SerializeField]
	bool fastSkip;

	[SerializeField]
	bool hideOnSkip;

	float startTime;
	float lifeTime;
	float endTime;

	bool skip;
	
	UnityEngine.UI.MaskableGraphic render;

	void Awake()
	{
		render = GetComponent<UnityEngine.UI.RawImage>();
		if( render == null ) render = GetComponent<UnityEngine.UI.Text>();
		if( appearDuration == 0f ) triggerAfterDisappear = false; // disable if no disappear
		Set();
	}

	void Update()
	{
		if( canBeSkipped )
		{
			if( fastSkip ) Skip();
			else if( startTime <= 0f ) Skip();
		}
	}

	void Skip()
	{
		if( ( Input.GetKeyDown( KeyCode.Return ) || Input.GetKeyDown( KeyCode.JoystickButton2 ) ) && !skip )
		{
			if( triggerOnSkip )
			{
				if( skipWholeEvent ) SkipWholeEvent(); 
				else if( !triggerAfterDisappear ) Trigger();
				if( hideOnSkip ) hideThemself = true;
				startTime = 0f;
				lifeTime = 0f;
			} else if( skipWholeEvent ) SkipWholeEvent();
			else 
			{
				if( startTime > 0f ) Effect( Mathf.Lerp( appearVisibility.x, appearVisibility.y, 1 ), appearEffect );
				startTime = 0f;
				lifeTime = 0f;
				if( !triggerAfterDisappear ) Trigger();
			}
			skip = true;
		}
	}

	void SkipWholeEvent()
	{
		if( endTime > 0f ) Effect( Mathf.Lerp( disappearVisibility.x, disappearVisibility.y, 1 ), disappearEffect );
		startTime = 0f;
		lifeTime = 0f;
		endTime = 0f;
		if( triggerAfterDisappear ) Trigger();
	}

	void FixedUpdate()
	{
		if( startTime > 0f )
		{
			float startNormal = 1 - ( 1 / appearDuration ) * startTime;
			Effect( Mathf.Lerp( appearVisibility.x, appearVisibility.y, startNormal ), appearEffect );

			startTime -= Time.fixedDeltaTime;
			if( startTime <= 0f ) Effect( Mathf.Lerp( appearVisibility.x, appearVisibility.y, 1 ), appearEffect );
		}
		else if( lifeTime >= 0f )
		{
			lifeTime -= Time.fixedDeltaTime;
			if( lifeTime < 0f )	
				if( !triggerAfterDisappear && !triggerOnSkip ) Trigger();
		} 
		else if( endTime > 0f && hideThemself )
		{
			float endNormal = 1 - ( 1 / disappearDuration ) * endTime;
			Effect( Mathf.Lerp( disappearVisibility.x, disappearVisibility.y, endNormal ), disappearEffect );

			endTime -= Time.fixedDeltaTime;
			if( endTime < 0f ) Effect( Mathf.Lerp( disappearVisibility.x, disappearVisibility.y, 1 ), disappearEffect );
		} 
		else if( hideThemself )
		{
			if( triggerAfterDisappear ) Trigger();
			else gameObject.SetActive( false );
		}
	}

	void Set()
	{
		startTime = appearDuration;
		if( appearEffect == Effects.Fade ) render.color = new Color( render.color.r, render.color.g, render.color.b, appearVisibility.x );
		endTime = disappearDuration;
		lifeTime = Duration;
	}

	void Disappear()
	{
		hideThemself = true;
	}

	void Trigger()
	{
		if( nextEvent != null )	nextEvent.SetActive( true );
		if( hideEvent != null )	
			if( hideEvent.activeSelf ) hideEvent.BroadcastMessage("Disappear", SendMessageOptions.DontRequireReceiver );
		if( endTime <= 0f && hideThemself ) gameObject.SetActive( false );
	}

	void Effect( float normal, Effects effect )
	{
		switch( effect )
		{
			case Effects.Fade :
				render.color = new Color( render.color.r, render.color.g, render.color.b, normal );
				break;
		}
	}
}