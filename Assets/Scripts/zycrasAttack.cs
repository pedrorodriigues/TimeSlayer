using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zycrasAttack : MonoBehaviour {
	private bool attack;
	private float attackTimer;
	public Collider2D attackCheck;
	public Animator anime;
	public LevelManager2 levelManager;

	// Use this for initialization
	void Awake () {
		attackCheck.enabled = false;
		levelManager = FindObjectOfType<LevelManager2>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Enemy")) {
			if (attackCheck.enabled == true) {
				Debug.Log ("MATOU");
				other.gameObject.GetComponent<Animator> ().SetBool ("run", false);
				other.gameObject.GetComponent<Animator> ().SetBool ("die", true);
				Destroy (other.gameObject, (float)0.8);
			} else {
				Debug.Log ("MORRE PFVR");
				levelManager.RespawnPlayer ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		

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
		
	}

}
