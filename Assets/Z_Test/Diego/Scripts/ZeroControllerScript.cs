using UnityEngine;
using System.Collections;

public class ZeroControllerScript : MonoBehaviour
{
	float buttonW;
	float buttonH;
	
	
	//Parameters
	private Animator anim;
	public float maxSpeed = 10f;
	public LayerMask groundLayer;
	public LayerMask objectLayer;
	public LayerMask finishLayer;
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
	private bool finished = false;
	
	
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
		//*** End of Level
		if (((1 << otherCollider.gameObject.layer) & finishLayer) != 0) {
			Finish();
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


	//**************************************************
	void Finish(){
		finished = true;
	}
	
	//Metodos de los botones---------------------------------------------------
	void OnGUI ()
	{
		buttonW = Screen.width/5;
		buttonH = Screen.height/5;


		// Make a background box
		//si esta muerto, pinta el boton para repetir
		if (!alive) {
			if (GUI.Button (new Rect (0.40f * Screen.width, Screen.height*0.3f, 150,90), "Repetir")) {
				Reset();
			}
		}
		// si no esta muerto y no se ha acabado el nivel, pinta los botones de saltar y atacar
		else{
			if(!finished){
				// Make the first button. If it is pressed, monacho jumps
				if(GUI.Button(new Rect(0.02f*Screen.width,0.8f*Screen.height,buttonW,buttonH), "Saltar")) {
					jumpButton = true;
				}
				
				// Make the second button. If it is pressed, monacho attacks
				if(GUI.Button(new Rect(0.78f*Screen.width,0.8f*Screen.height,buttonW,buttonH), "Atacar")) {
					attackButton = true;
				}
			}
		}

		//return to Menu
		if (GUI.Button(new Rect(0.02f*Screen.width,0.14f*Screen.height,buttonW,buttonH), "regresar"))
			Application.LoadLevel ("Menu0");

		// si se ha terminado el nivel, se pinta el boton para continuar
		if (finished) {
			if (GUI.Button (new Rect (Screen.width*0.4f,Screen.height*0.3f,Screen.width*0.4f,Screen.height*0.2f), "Nivel Terminado,\nContinuar.")) {

				//Carga una escena diferente dependiendo de si se est'a devolviendo o no.
				if( PlayerPrefs.GetInt("Returning") == 1 ){
					Application.LoadLevel("CharacterSelect");
				}
				else{
					Application.LoadLevel("EndOfLevel");
				}
			}

				}

	}
}