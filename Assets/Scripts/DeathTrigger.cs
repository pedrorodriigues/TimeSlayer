using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    public LevelManager levelManager;
    public GameObject currentCheckpoint;
    private PlayerController player;
	private NewController player2;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		if (player == null) {
			player2 = FindObjectOfType<NewController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        // se colidir com um jogador reseta o jogo. Recarregar a cena. 
        if (other.gameObject.CompareTag("Player"))
        {
			if (player == null) {
				player2.transform.position = currentCheckpoint.transform.position;
			} else {
				player.transform.position = currentCheckpoint.transform.position;
			}
            
        }
    }
}
