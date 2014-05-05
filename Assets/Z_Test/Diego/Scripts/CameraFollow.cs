using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float distance = 3f;
	public float height = 3f;
	public float damping = 5f;
	public float horizontalOffset = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Camera.main.transform.position = new Vector3 (target.gameObject.transform.position.x + horizontalOffset,
		                                              Camera.main.transform.position.y,
		                                              Camera.main.transform.position.z
		                                              );
		                                              
	}
}
