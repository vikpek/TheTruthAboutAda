using UnityEngine;

public class MalusController : MonoBehaviour
{
	[SerializeField]
	float height = 1.5f;

	[SerializeField]
	float speed = 5f;

	bool up = true;
	bool rigUp = true;
	
	Sprite[] malusSprites;
	Rigidbody rigid;

	Vector3 lastPos;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		malusSprites = PrefabDB.Get.Malus();
		height += transform.position.y;
	}


	void FixedUpdate()
	{
		if( up )
		{
			Vector3 pos = transform.position;
			float move = Time.fixedDeltaTime * speed;
			if( pos.y + move >= height )
			{
				up = false;
				pos.y = height;
				rigid.useGravity = true;
			} else pos.y += move;
			rigid.MovePosition( pos );
		} else if( rigUp )
		{
			if( Mathf.Abs( Vector3.Distance( lastPos, transform.position ) ) <= 0.1f )
			{
				GetComponent<SpriteRenderer>().sprite = malusSprites[0];
				tag = Tags.CREEPBULLET;
				rigUp = false;
			} else lastPos = transform.position;
		}
	}
}