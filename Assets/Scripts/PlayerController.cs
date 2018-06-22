using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D playerRigidbody;
	public SpriteRenderer playerSprite;
	public Transform playerTransform;
	public int forceJump;
	public Animator anime;
	public bool jump;
	//public bool slide;
	public bool grounded;
	public bool running;
	public bool attack;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float timeTemp;
	public float slideTemp;
	private float zero;
	public Transform colisor;
	public Collider2D colisorAttack;
	private Vector2 move = Vector2.zero;
	public float speed;
	public LevelManager levelManager;


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject != null){
			Debug.Log ("GO");
			if (other.gameObject.CompareTag ("Enemy")) {
				if (colisorAttack.enabled == true) {
					Debug.Log ("MATOU");
					other.gameObject.GetComponent<Animator> ().SetBool ("run", false);
					other.gameObject.GetComponent<Animator> ().SetBool ("death", true);
					Destroy (other.gameObject, (float)0.8);
				} else {
					Debug.Log ("MORRE PFVR");
					levelManager.RespawnPlayer ();
				}
			}
		}
    }

	void Start(){
		levelManager = FindObjectOfType<LevelManager>();
		colisorAttack.enabled = false;
	}
		
	void Update(){
		move.x = Input.GetAxis("Horizontal");
		if (move.x > 0){
			running = true;
			playerSprite.flipX = false;
			playerRigidbody.velocity = new Vector2(move.x * speed, playerRigidbody.velocity.y);
		} else if (move.x < 0) {
			running = true;
			playerSprite.flipX = true;
			playerRigidbody.velocity = new Vector2 (move.x * speed, playerRigidbody.velocity.y);
		} else{
			running = false;
		}
			
		if (Input.GetButtonDown("Jump") && grounded == true){
			playerRigidbody.AddForce (new Vector2 (0, forceJump));
			/*if (slide) {
				slide = false;
			}
			slide = false;*/
		}

		/*if (Input.GetButtonDown ("Slide") && grounded) {
			slide = true;
			timeTemp = 0;
		}*/

		if (Input.GetButtonDown ("Attack") && grounded) {
			attack = true;
			colisorAttack.enabled = true;
			timeTemp = 0;
		}
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

		/*if(slide){
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp){
				slide = false;
			}
		}*/

		if(attack){
			timeTemp += Time.deltaTime;
			if(timeTemp >= slideTemp) {
				attack = false;
				colisorAttack.enabled = false;
			}
		}
		
		anime.SetBool ("running", running);
		anime.SetBool ("jump", !grounded);
		//anime.SetBool ("slide", slide);
		anime.SetBool ("attack", attack);
	}

	void FixedUpdate(){
			
	}
}
