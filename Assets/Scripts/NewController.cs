using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour {

	public float speed;
	public float jumpForce;

	private Rigidbody2D rb;
	private bool facingRight = true;
	private bool jump = false;
	private Animator anim;
	private bool onTheFloor = false;
	private Transform groundCheck;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		groundCheck = gameObject.transform.Find("GroundCheck");
	}
	
	void Update(){

		onTheFloor = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButtonDown("Jump") && onTheFloor){
			jump = true;
			anim.SetBool("pulo", true);
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw("Horizontal");
		anim.SetFloat("velocidade", Mathf.Abs(h));
		rb.velocity = new Vector2(h * speed, rb.velocity.y);

		if(h > 0 && !facingRight){
			Flip ();
		}else if(h < 0 && facingRight){
			Flip();
		}

		if (jump) {
			rb.AddForce(new Vector2(0, jumpForce));
			jump = false;
			anim.SetBool("pulo", false);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
