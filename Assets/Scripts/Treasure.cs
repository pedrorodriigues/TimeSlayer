using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Treasure : MonoBehaviour {

	private bool click = false;
	public Animator anime;

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
			anime.SetBool ("click", !click);
			Application.LoadLevel("ValentinaCroft"); //substituir pela fase que vai depois dessa
        }
    }
	
	void Update () {
	}
	
	void Start () {
	}
}