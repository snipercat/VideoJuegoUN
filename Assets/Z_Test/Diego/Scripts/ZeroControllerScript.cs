using UnityEngine;
using System.Collections;

public class ZeroControllerScript : MonoBehaviour {



	//Parameters
	private Animator anim;
	public float maxSpeed = 10f;
	public LayerMask groundLayer;
	public LayerMask objectLayer;
	public float jumpForce=210f;
	public bool autorun = false;

	public AttackScript attackScript;

	//Status (Change to Private)
	public bool grounded = false;
	public bool attacking = false;
	private bool facingRight = true;




//**************************************************
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		attackScript = GetComponentInChildren<AttackScript> ();

		transform.position = new Vector3 (0, -0.85f, 0);

	}
//**************************************************	
	// Update is called once per frame
	void FixedUpdate () {
			//cambio de variable vSpeed para cambiar animacion
			anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

			//** HorizontalMovement
			float move;
			if (autorun)
					move = 1;
			else
					move = Input.GetAxis ("Horizontal");

			// Aplicar movimiento
			rigidbody2D.velocity = new Vector2 (maxSpeed * move, rigidbody2D.velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (move));

			// Si cambio la direccion del movimiento, voltear al personaje
			if (move > 0 && !facingRight)
					Flip ();
			else if (move < 0 && facingRight)
					Flip ();
	}
//**************************************************
	void Update(){
		
	//*** Salto
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rigidbody2D.AddForce(new Vector2(0, jumpForce));			
			EndAttack();
		}
		

	//*** Ataque
		//SystemInfo esta en el suelo y se oprime Z, ataca y se aumenta uno al combo
		if (Input.GetKeyDown (KeyCode.Z) && grounded ) {
			
			if (!anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")){
				attacking = true;
				anim.SetBool ("Attack", true);
				attackScript.attacking = true;
			}
			anim.SetInteger ("AttackCount", anim.GetInteger ("AttackCount") + 1);
		}
	}
//**************************************************
	// verificar si esta en el suelo
	void OnTriggerStay2D(Collider2D otherCollider){
		if (((1 << otherCollider.gameObject.layer) & groundLayer) != 0) {
			grounded = true;
			anim.SetBool ("Ground", true);
		}


		if (((1 << otherCollider.gameObject.layer) & objectLayer) != 0) {
			if(!attacking)
			{

				//Destroy (this);
				anim.SetBool ("alive", false);
				//Application.LoadLevel(Application.loadedLevel);
			}

		}
	} 
//**************************************************
	void OnTriggerExit2D(Collider2D otherCollider){
		if (((1 << otherCollider.gameObject.layer) & groundLayer) != 0) {
						grounded = false;
						anim.SetBool("Ground", false);
				}
		
	}

//**************************************************
	void EndAttack(){

		//Si esta atacando cambia las variables, si no, se su pone que no deben estar en otro estado.
		if (attacking) {
				attacking = false;
				anim.SetBool ("Attack", false);
				anim.SetInteger ("AttackCount", 0);
				attackScript.attacking = false;
		}
	}
//**************************************************
	void Flip(){
		facingRight = !facingRight;
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}

	void Reset(){
		Application.LoadLevel(Application.loadedLevel);
	}

}
