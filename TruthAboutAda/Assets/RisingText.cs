using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class RisingText : MonoBehaviour
{
	float alpha;
	float lifeLoss;
	Camera  cam;
	Vector3 destination;

	public Color color = Color.white;
	
	// SETUP - call this once after having created the object, to make it 
	// "points" shows the points.
	// "duration" is the lifespan of the object
	// "rise speed" is how fast it will rise over time.
	public void setup(string points, float duration, float rise_speed)
	{
		GetComponent<TextMesh>().text = points;       
		lifeLoss = 1f / duration;
	}
	
	void Start() 
	{
		destination = GameObject.FindGameObjectWithTag(Tags.HIGHSCOREDISPLAY).GetComponent<Transform>().position;
		alpha = 1f;
		cam = Camera.main;
		lifeLoss = 0.5f;
	}
	
	void Update () 
	{
//		transform.Translate(crdsDelta * Time.deltaTime, Space.World);
		transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
	

		alpha -= Time.deltaTime * lifeLoss;
		renderer.material.color = new Color(color.r,color.g,color.b,alpha);

		if (alpha <= 0f) Destroy(gameObject);

		transform.LookAt(cam.transform.position);
		transform.rotation = cam.transform.rotation;        
	}
}