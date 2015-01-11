using UnityEngine;

public class BulletController : MonoBehaviour
{
	int bulletValue;

	public void setBulletValue( Sprite img, int numb )
	{
//		transform.GetComponent<SpriteRenderer>().sprite = img;
		bulletValue = numb;
	}

	public int getBulletValue()
	{
		return bulletValue;
	}
}
