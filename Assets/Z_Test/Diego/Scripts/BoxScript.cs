using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	public int healt = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Attacked( int power){
		if (power >= healt) {
						GetComponent<Animator> ().SetBool ("Destroy", true);
						GetComponent<BoxCollider2D> ().enabled = false;
						GetComponent<Rigidbody2D> ().gravityScale = 0;
				} else {
						healt-= power;
				}
	}

	void Destroy(){
		Destroy (this.gameObject);
	}
}
