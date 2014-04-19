using UnityEngine;
using System.Collections;

public class ZeroControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	private bool facingRight = true;

	private Animator anim;

	public bool grounded = false;
	public LayerMask groundLayer;


	public AnimationState attack;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis( "Horizontal");
		rigidbody2D.velocity = new Vector2 (maxSpeed * move, rigidbody2D.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && !facingRight)
						Flip ();
		else if (move < 0 && facingRight)
						Flip ();

		Camera.main.transform.position = new Vector3 (rigidbody2D.gameObject.transform.position.x,
		                                              rigidbody2D.gameObject.transform.position.y,
		                                              Camera.main.transform.position.z
				);

	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		Flip ();
		if (otherCollider.gameObject.layer == groundLayer)
			grounded = true;
						
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Z)) {
						if (!anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack"))
								anim.SetBool ("Attack", true);
						anim.SetInteger ("AttackCount", anim.GetInteger ("AttackCount") + 1);
				} else {
						if (!anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
								anim.SetBool ("Attack", false);
								anim.SetInteger ("AttackCount", 0);
						}
				}
			
	}

	void EndAttack(){
		anim.SetBool ("Attack", false);
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;

	}
}
