using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zycrasAttack : MonoBehaviour {
	private bool attack;
	private float attackTimer;
	public Collider2D attackCheck;
	public Animator anime;

	// Use this for initialization
	void Awake () {
		attackCheck.enabled = false;
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
