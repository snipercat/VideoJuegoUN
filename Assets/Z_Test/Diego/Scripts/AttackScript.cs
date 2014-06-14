using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	public bool attacking = false;
	public int attackForce = 10;
	public LayerMask objectLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider){

		if (((1 << otherCollider.gameObject.layer) & objectLayer) != 0) {
				if (attacking)
				otherCollider.GetComponent<BoxScript>().Attacked(attackForce);
		}
	}
}
