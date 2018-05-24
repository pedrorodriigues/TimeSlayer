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
	public bool slide;
	public bool grounded;
	public bool attack;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float timeTemp;
	public float slideTemp;
	public Transform colisor;
	public Collider2D colisorAttack;
	private Vector2 move = Vector2.zero;
	public float velocidadeValentina;
	public float maxSpeed = 30f;

	void OnTriggerEnter2D(Collider2D other)
    {
        // se detectar colisão com o hero detrói a moeda
         if (other.gameObject.CompareTag("Enemy"))
        {
			//Destroy(gameObject);
			//Application.LoadLevel(Application.loadedLevel);
        }

		Debug.Log(colisorAttack.enabled);

        if(colisorAttack.enabled == true && other.gameObject.CompareTag("Enemy")){
			Debug.Log("MATOU");
			Destroy(other);
		}


    }
	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {


		move.x = Input.GetAxis ("Horizontal");

		if (move.x > 0 && playerRigidbody.velocity.x < maxSpeed ){
			playerSprite.flipX = false;
			playerRigidbody.AddForce (new Vector2 (move.x * velocidadeValentina, 0));
		} else if (move.x < 0 && playerRigidbody.velocity.x < maxSpeed){
			playerSprite.flipX = true;
			playerRigidbody.AddForce (new Vector2 (move.x * velocidadeValentina, 0));
		}



		if (Input.GetButtonDown("Jump") && grounded == true) {
			playerRigidbody.AddForce (new Vector2 (0, forceJump));
			if (slide) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
			slide = false;
		}

		if (Input.GetButtonDown ("Slide") && grounded) {
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
			slide = true;
			timeTemp = 0;
		}

		if (Input.GetButtonDown ("Attack") && grounded) {
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
			attack = true;
			colisorAttack.enabled = true;
			timeTemp = 0;
			
		}
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

		if (slide) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;

			}
		}

		if (attack) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				attack = false;
				colisorAttack.enabled = false;
			}
		}



		anime.SetBool ("jump", !grounded);
		anime.SetBool ("slide", slide);
		anime.SetBool ("attack", attack);
	
	}



}
