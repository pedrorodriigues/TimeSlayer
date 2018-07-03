using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2 : MonoBehaviour 
{
	public LevelManager2 levelManager;
	public GameObject currentCheckpoint;
	private zycrasController player;

	void Start(){
		player = FindObjectOfType<zycrasController>();

	}

	void Update(){  
	}

	public void RespawnPlayer(){
		//Debug.Log("Player Respawn");
		player.transform.position = currentCheckpoint.transform.position;
	}

}
