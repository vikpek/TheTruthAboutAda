using UnityEngine;

public class BulletController : MonoBehaviour
{
	int bulletValue;

	public void setBulletValue( int numb )
	{
		bulletValue = numb;
	}

	public int getBulletValue()
	{
		return bulletValue;
	}
}
