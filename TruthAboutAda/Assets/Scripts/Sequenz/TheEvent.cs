using UnityEngine;

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
	Vector2 appearVisibility;

	[SerializeField]
	Effects disappearEffect = Effects.None;

	[SerializeField]
	float disappearDuration = 1f;

	[SerializeField]
	Vector2 disappearVisibility;

	float startTime;
	float lifeTime;
	float endTime;
	
	UnityEngine.UI.MaskableGraphic render;

	void Awake()
	{
		render = GetComponent<UnityEngine.UI.RawImage>();
		if( render == null ) render = GetComponent<UnityEngine.UI.Text>();
		if( appearDuration == 0f ) triggerAfterDisappear = false; // disable if no disappear
		Set();
	}

	void LateUpdate()
	{
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			if( skipWholeEvent )
			{
				if( endTime > 0f ) Effect( 0, disappearEffect );
				startTime = 0f;
				lifeTime = 0f;
				endTime = 0f;
				if( triggerAfterDisappear ) Trigger();
			} else 
			{
				if( startTime > 0f ) Effect( 1, appearEffect );
				startTime = 0f;
				lifeTime = 0f;
				if( !triggerAfterDisappear ) Trigger();
			}
		}
	}

	void FixedUpdate()
	{
		if( startTime > 0f )
		{
			float startNormal = 1 - ( 1 / appearDuration ) * startTime;
			Effect( startNormal, appearEffect );

			startTime -= Time.fixedDeltaTime;
			if( startTime <= 0f ) Effect( 1, appearEffect );
		}
		else if( lifeTime >= 0f )
		{
			lifeTime -= Time.fixedDeltaTime;
			if( lifeTime < 0f )	
				if( !triggerAfterDisappear  ) Trigger();
		} 
		else if( endTime > 0f && hideThemself )
		{
			float endNormal = ( 1 / disappearDuration ) * endTime;
			Effect( endNormal, disappearEffect );

			endTime -= Time.fixedDeltaTime;
			if( endTime < 0f ) Effect( 0, disappearEffect );
		} 
		else if( hideThemself )
		{
			if( triggerAfterDisappear ) Trigger();
			else gameObject.SetActive( false );
			Set(); // Prepare for next use
		}
	}

	void Set()
	{
		startTime = appearDuration;
		if( appearEffect == Effects.Fade ) render.color = new Color( render.color.r, render.color.g, render.color.b, 0 );
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
			if( hideEvent.activeSelf ) hideEvent.BroadcastMessage("Disappear");
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