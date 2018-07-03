using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour 
{
	public LevelManager2 levelManager;

	void Start(){
		levelManager = FindObjectOfType<LevelManager2>();
	}

	void  Update() {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// se colidir com um jogador reseta o jogo. Recarregar a cena. 
		if (other.gameObject.CompareTag("Player")){
			levelManager.currentCheckpoint = gameObject;
		}
	}
}