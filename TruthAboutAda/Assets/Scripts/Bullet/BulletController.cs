using UnityEngine;

public class BulletController : MonoBehaviour
{
	int bulletValue;

	[SerializeField]
	int bulletType = 0;

	public void SetBulletValue( int numb )
	{
		bulletValue = numb;
	}

	public int GetBulletValue()
	{
		return bulletValue;
	}

	// 0 is regular; 1 is joker
	public void SetBulletToType(int type)
	{
		bulletType = type;
	}

	public bool IsBulletJoker()
	{
		return bulletType == 1;
	}
}
