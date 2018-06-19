using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public float forcaHorizontal = 15;
	public float tempoDeDestruicao = 1;
	private float forcaHorizontalPadrao;

	void Start(){
		forcaHorizontalPadrao = forcaHorizontal;
	}
	
	void Update(){
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Enemy")){
			other.gameObject.GetComponent<Enemy>().enabled = false;
			BoxCollider2D box = other.gameObject.GetComponent<BoxCollider2D>();
			box.enabled = false;

			if(other.transform.position.x < transform.position.x){
				forcaHorizontal *= -1;
			}

			other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (forcaHorizontal, 0), ForceMode2D.Impulse);
			Destroy(other.gameObject, tempoDeDestruicao);
			forcaHorizontal = forcaHorizontalPadrao;
		}
	}
}