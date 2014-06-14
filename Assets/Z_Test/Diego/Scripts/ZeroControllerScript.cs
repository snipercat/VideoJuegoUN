using UnityEngine;
using System.Collections;

public class ZeroControllerScript : MonoBehaviour
{
	
	
	
	//Parameters
	private Animator anim;
	public float maxSpeed = 10f;
	public LayerMask groundLayer;
	public LayerMask objectLayer;
	public float jumpForce = 210f;
	public bool autorun = false;
	public bool jumpButton = false;
	public bool attackButton = false;
	public AttackScript attackScript;
	
	
	
	//Status (Change to Private)
	public bool grounded = true;
	public bool attacking = false;
	private bool facingRight = true;
	public bool alive = true;
	private float lastX = -Mathf.Infinity;
	
	
	//**************************************************
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		attackScript = GetComponentInChildren<AttackScript> ();
		
	}
	//**************************************************
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!alive)
			return;
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
		
		
		float currentX = this.gameObject.transform.position.x;

		if (lastX >= currentX) {
			alive = false;
			anim.SetBool ("alive", false);
		}
		else
			lastX = currentX;
		
		// Si cambio la direccion del movimiento, voltear al personaje
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	//**************************************************
	void Update ()
	{
		
		//*** Salto
		if (alive && grounded && (jumpButton || Input.GetKeyDown (KeyCode.Space) )) {
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			jumpButton = false;
			EndAttack ();
		}
		
		//*** Ataque
		//SystemInfo esta en el suelo y se oprime Z, ataca y se aumenta uno al combo
		if (alive && (attackButton || Input.GetKeyDown (KeyCode.Z)) && grounded) {
			
			if (!anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
				attacking = true;
				anim.SetBool ("Attack", true);
				attackScript.attacking = true;
				attackButton = false;
			}
			anim.SetInteger ("AttackCount", anim.GetInteger ("AttackCount") + 1);
		}
	}
	//**************************************************
	// verificar si esta en el suelo
	void OnTriggerEnter2D (Collider2D otherCollider)
	{


		if (((1 << otherCollider.gameObject.layer) & groundLayer) != 0) {
			grounded = true;
			anim.SetBool ("Ground", true);
		}
		
		
		if (((1 << otherCollider.gameObject.layer) & objectLayer) != 0) {
			if (!attacking) {
				//alive = false;
				//Destroy (this);
				//anim.SetBool ("alive", false);
				//Application.LoadLevel(Application.loadedLevel);
			}
			
		}
	}
	//**************************************************
	void OnTriggerExit2D (Collider2D otherCollider)
	{
		if (((1 << otherCollider.gameObject.layer) & groundLayer) != 0) {
			grounded = false;
			anim.SetBool ("Ground", false);
		}
		
	}
	
	//**************************************************
	void EndAttack ()
	{
		
		//Si esta atacando cambia las variables, si no, se su pone que no deben estar en otro estado.
		if (attacking) {
			attacking = false;
			attackButton = false;
			anim.SetBool ("Attack", false);
			anim.SetInteger ("AttackCount", 0);
			attackScript.attacking = false;
		}
	}
	//**************************************************
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}
	
	void Reset ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	//**************************************************
	void Die(){
		anim.SetBool ("Ground", true);
		anim.SetFloat ("vSpeed", 0);
		anim.SetBool ("alive", true);

	}
	
	
	//Metodos de los botones---------------------------------------------------
	void OnGUI ()
	{
		// Make a background box
		if (!alive) {
			if (GUI.Button (new Rect (Screen.width/2-45, Screen.height-160, 90,90), "Repetir")) {
				Reset();
			}
				}


		else{
			// Make the first button. If it is pressed, monacho jumps
			if (GUI.Button (new Rect (20, Screen.height-160, 90,90), "Saltar")) {
				jumpButton = true;
			}
			
			// Make the second button. If it is pressed, monacho attacks
			if (GUI.Button (new Rect (Screen.width-110, Screen.height-160, 90,90 ), "Atacar")) {
				attackButton = true;
			}
		}

		//return to Menu
		if (GUI.Button (new Rect (10, 10, 90,90 ), "regresar"))
			Application.LoadLevel ("Menu0");

	}
}