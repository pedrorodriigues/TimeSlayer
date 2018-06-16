using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Checkpoint : MonoBehaviour 
 {
    public LevelManager levelManager;
 
    void Start(){
        levelManager = FindObjectOfType<LevelManager>();
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