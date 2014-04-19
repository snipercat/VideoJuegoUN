using UnityEngine;
using System.Collections;

public class ZeroScript : MonoBehaviour {

	// Use this for initialization
	public float maxSpeed= 10f;
	bool facingRight = true;

	//The animator created for Zero character
	Animator zeroAnimator;

	//to see if Zero is in the floor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius =  0.2f;
	public LayerMask whatIsGround;
	public float jumpForce=70f;

	void Start () {
		zeroAnimator = GetComponent<Animator>();
	}


	//Does not change each frame rate
	//Method name changed from Update to FixedUpdate
	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		zeroAnimator.SetBool ("Ground", grounded);

		zeroAnimator.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");

		//Setting the animator "Speed" float variable for the conditions of animation change
		zeroAnimator.SetFloat ("Speed", Mathf.Abs (move)); 

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);



		//world rotations to make monacho face the right side
		if (move > 0 && !facingRight)
						flip ();
		else if (move < 0 && facingRight)
						flip ();
	}


	void Update(){
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			zeroAnimator.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));			
		}
		if(Input.GetKeyDown (KeyCode.LeftControl)){
			zeroAnimator.SetBool("Attacking", true);
		}
		//zeroAnimator.SetBool ("Attacking", false);
	}

	//Flipping the world (not the sprite)
	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
