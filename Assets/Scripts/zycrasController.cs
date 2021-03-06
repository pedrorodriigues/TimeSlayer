using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zycrasController : MonoBehaviour {
	private Rigidbody2D zycrasRigidbody;
	public SpriteRenderer playerSprite;
	public Transform playerTransform;
	public int forceJump;
	public Animator anime;
	public bool jump;
	public bool run;
	public bool grounded;
	public bool attack;
	public bool idle;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float attackTimer;
	public float slideTemp;
	public Transform colisor;
	private Vector2 move = Vector2.zero;
	public float threshold;
	public float knockBackForca;
	public float velocidade = 100f;
	private Rigidbody2D fallground; 
	private float timeTemp;
	public LevelManager2 levelManager;
	public Collider2D attackCheck;
	public Rigidbody2D rgdb;



	// Use this for initialization
	void Start () {
		attackCheck.enabled = false;
		zycrasRigidbody = gameObject.GetComponent<Rigidbody2D>();
		levelManager = FindObjectOfType<LevelManager2>();
	}




	// Update is called once per frame
	void Update () {
		move.x = Input.GetAxis ("Horizontal");
		grounded =	Physics2D.OverlapCircle(groundCheck.position,	0.2f,	whatIsGround);
		if (move.x > 0) {
			playerSprite.flipX = false;
			run = true;
			zycrasRigidbody.AddForce (new Vector2 (move.x * velocidade, 0));

		} else if (move.x < 0) {
			playerSprite.flipX = true;
			run = true;
			zycrasRigidbody.AddForce ((Vector2.right * velocidade) * move.x);

		} else {
			idle = true;
			run = false;
		}



		if (Input.GetButtonDown("Jump") && grounded == true) {
			zycrasRigidbody.AddForce (new Vector2 (0, forceJump));
			jump = true;
		}

		//respawn
		if (transform.position.y < threshold) {
			Application.LoadLevel (Application.loadedLevel);
			transform.position = new Vector3(20f, 3f, 0);
		}
			



		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

		if (Input.GetButtonDown ("Attack") && !attack) {
			attack = true;
			attackTimer = 0.3F;
			attackCheck.enabled= true;
		}

		if (attack) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime; 
			} else {
				attack = false;
				attackCheck.enabled = false;
			}
		}

		anime.SetBool ("atack", attack);





		anime.SetBool ("jump", !grounded);
		anime.SetBool("idle",idle);
		anime.SetBool ("run", run);



	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("fall")) {
			Debug.Log ("entrei!!");
			fallground = other.gameObject.GetComponent<Rigidbody2D> ();
			StartCoroutine (test (fallground));
		}
		if (other.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("aaa");
			if (attackCheck.enabled == true) {
				Debug.Log ("MATOU");
				rgdb = other.gameObject.GetComponent<Rigidbody2D> ();
				rgdb.AddForce (new Vector2 (move.x * 1, 0));
				other.gameObject.GetComponent<Animator> ().SetBool ("die", true);
				Destroy (other.gameObject, (float)0.8);
			} else {
				Debug.Log ("MORRE PFVR");
				levelManager.RespawnPlayer ();
			}
		}
	}
		

	public IEnumerator test(Rigidbody2D ground){

		yield return new WaitForSeconds (2);
		print ("3secs");
		ground.velocity = new Vector2 (0, -5);
	}


	/*void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject != null) {
			// se detectar colisão com o hero detrói a moeda
			if (col.gameObject.CompareTag ("spike")) {
				StartCoroutine (KnockBack (0.02f, knockBackForca));
				//Application.LoadLevel (Application.loadedLevel);
			}
		}

	}


	public IEnumerator KnockBack(float knockDur,float knockBackForca){

		float timer = 0;
		while (knockDur > timer){
			timer+=Time.deltaTime;
			zycrasRigidbody.velocity = new Vector2 (0, 0); 
			zycrasRigidbody.AddForce (new Vector3 (transform.position.x * -150, transform.position.y + knockBackForca, transform.position.z));
		}
		yield return 0;
	}*/

}
