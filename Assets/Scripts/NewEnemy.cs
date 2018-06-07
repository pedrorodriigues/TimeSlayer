using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour {

	public float speed;
	Rigidbody2D rb;
	bool facingRight = false;
	bool OnTheFloor = false;
	Transform groundCheck;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find ("EnemyGroundCheck");
	}
	
	void Update(){
		OnTheFloor = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		if (!OnTheFloor) {
			speed *= -1;
		}
	}

	void FixedUpdate(){
		rb.velocity = new Vector2 (speed, rb.velocity.y);
		if (speed > 0 && !facingRight) {
			Flip();
		}else if(speed < 0 && facingRight){
			Flip();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			BoxCollider2D box = other.gameObject.GetComponent<BoxCollider2D>();
			box.enabled = false;

			speed = 0;
			transform.Rotate (new Vector3 (0, 0, -180));
			Destroy (gameObject, 3);
		}
	}
}