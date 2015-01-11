using UnityEngine;

public class LifeController : MonoBehaviour 
{

	[SerializeField]
	int initialLifeCount = 3;

	int lifeCount = 3;
	Sprite[] singleSprites;
	SpriteRenderer lifeLayer;

	void Awake()
	{
		singleSprites = PrefabDB.Get.Life();
		lifeLayer = transform.FindChild( Constants.LIFE_LAYER ).GetComponent<SpriteRenderer>();
	}

	public void decreaseLife()
	{
		if( lifeCount > 0 )
		{
			lifeCount--;
			lifeLayer.sprite = singleSprites[lifeCount];
			if( lifeCount <= 0 ) stopGame();
		}
	}

	public void resetLife()
	{
		lifeCount = initialLifeCount;
	}

	public int getLifeCount()
	{
		return lifeCount;
	}

	void stopGame() // GameOver Event
	{
		GameObject.FindWithTag( Tags.GAMECONTROLLER ).GetComponent<UIController>().SetGameOver();
	}
}