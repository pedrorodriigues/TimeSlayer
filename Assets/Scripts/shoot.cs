using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
	public enemyRanged enemy;
	public bool isLeft = false;

	// Use this for initialization
	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")){
			if (isLeft) {
				enemy.Attack (false);
			} else {
				enemy.Attack (true);
			}
		}
	}
}
