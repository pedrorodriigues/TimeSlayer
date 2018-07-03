using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Treasure : MonoBehaviour {

	public bool click = false;
	public Animator anime;
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player") ){
			anime.SetBool ("click", !click);
			StartCoroutine(waitTime());
        }
    }
	
	public IEnumerator waitTime (){
		click = false;
		Debug.Log("HERE");
		yield return new WaitForSeconds (2);
		Application.LoadLevel("ValentinaCroft"); //substituir pela fase que vai depois dessa

	}
}