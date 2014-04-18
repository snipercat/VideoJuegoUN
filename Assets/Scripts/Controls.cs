using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	private float direction=1;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		MoveScript movement = this.gameObject.GetComponent<MoveScript>();
		Animation animation = this.gameObject.GetComponent<Animation> ();
	// Revisa si se ha cambiado el sentido del movimiento para cambiar el sentido del movimiento
	// hacia le lado correcto
		if (Input.GetAxis ("Horizontal") < 0 && direction != -1){
						direction = -1;
						transform.localScale = new Vector3 (transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
		}
		if (Input.GetAxis ("Horizontal") > 0 && direction != 1){
						transform.localScale = new Vector3 (transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
						direction = 1;
		}



		if (Input.GetAxis ("Horizontal") == 0)
						animation.Idle ();
		else {
			movement.Move (Input.GetAxis ("Horizontal"));
			animation.Walk();
		}


	//Realiza el movimiento
		
	}

}
