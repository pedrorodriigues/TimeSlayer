using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	Animator anim;

	public float intervaloAtaque;
	private float proximoAtaque;

	void Start(){
		anim = gameObject.GetComponent<Animator>();
	}
	
	void Update (){
		if (Input.GetButtonDown ("Fire1") && Time.time > proximoAtaque) {
			Attacking();
		} else {
			anim.SetBool("ataque", false);
		}
	}

	void Attacking(){
		anim.SetBool("ataque", true);
	}
}