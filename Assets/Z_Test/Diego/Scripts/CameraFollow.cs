using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float distance = 3f;
	public float height = 3f;
	public float damping = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 wantedPosition = target.TransformPoint (0, height, -distance);

		//transform.position = new Vector3( target.position.x, transform.position.y,  transform.position.z);


		//transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		Camera.main.transform.position = new Vector3 (target.gameObject.transform.position.x,
		                                              target.gameObject.transform.position.y + height,
		                                              Camera.main.transform.position.z
		                                              );
		                                              
	}
}
