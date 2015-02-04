using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class RisingText : MonoBehaviour
{
	Vector3 crdsDelta;
	float alpha;
	float lifeLoss;
	Camera  cam;

	public Color color = Color.white;
	
	// SETUP - call this once after having created the object, to make it 
	// "points" shows the points.
	// "duration" is the lifespan of the object
	// "rise speed" is how fast it will rise over time.
	public void setup(string points, float duration, float rise_speed)
	{
		GetComponent<TextMesh>().text = points;       
		lifeLoss = 1f / duration;
		crdsDelta = new Vector3(0f, rise_speed, 0f);        
	}
	
	void Start() 
	{
		alpha = 1f;
		cam = Camera.main;
		crdsDelta = new Vector3(-2f, 1f, 1f);
		lifeLoss = 0.5f;
	}
	
	void Update () 
	{
		transform.Translate(crdsDelta * Time.deltaTime, Space.World);
//		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
	

		alpha -= Time.deltaTime * lifeLoss;
		renderer.material.color = new Color(color.r,color.g,color.b,alpha);

		if (alpha <= 0f) Destroy(gameObject);

		transform.LookAt(cam.transform.position);
		transform.rotation = cam.transform.rotation;        
	}
}