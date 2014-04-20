using UnityEngine;
using System.Collections;

public class ZeroControllerScript : MonoBehaviour {



	//Parameters
	private Animator anim;
	public float maxSpeed = 10f;
	public LayerMask groundLayer;
	public float jumpForce=210f;

	//Status (Change to Private)
	public bool grounded = false;
	public bool attacking = false;
	private bool facingRight = true;


//**************************************************
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
//**************************************************	
	// Update is called once per frame
	void FixedUpdate () {


	//** HorizontalMovement
		float move;
		//Si esta atacando y esta en el piso se queda quieto
		if( attacking && grounded)
				move = 0;
		else
				move = Input.GetAxis( "Horizontal");

		// Aplicar movimiento
		rigidbody2D.velocity = new Vector2 (maxSpeed * move, rigidbody2D.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (move));

		// Si cambio la direccion del movimiento, voltear al personaje
		if ( move > 0 && !facingRight)
						Flip ();
		else if (move < 0 && facingRight)
						Flip ();
	}
//**************************************************
	void Update(){
		
	//*** Salto
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			//anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));			
		}
		

	//*** Ataque
		//SystemInfo esta en el suelo y se oprime Z, ataca y se aumenta uno al combo
		if (Input.GetKeyDown (KeyCode.Z) && grounded ) {
			
			if (!anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")){
				attacking = true;
				anim.SetBool ("Attack", true);
			}
			anim.SetInteger ("AttackCount", anim.GetInteger ("AttackCount") + 1);
		}
	}
//**************************************************
	void OnTriggerEnter2D(Collider2D otherCollider){
		if (((1 << otherCollider.gameObject.layer) & groundLayer) != 0) {
						grounded = true;
						anim.SetBool ("Ground", true);
				}
	}
//**************************************************
	void OnTriggerExit2D(Collider2D otherCollider){
		//Flip ();

		if (((1 << otherCollider.gameObject.layer) & groundLayer) != 0) {
						grounded = false;
						anim.SetBool("Ground", false);
				}
		
	}

//**************************************************
	void EndAttack(){
		attacking = false;
		anim.SetBool ("Attack", false);
		anim.SetInteger ("AttackCount", 0);
	}
//**************************************************
	void Flip(){
		facingRight = !facingRight;
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;

	}
}
