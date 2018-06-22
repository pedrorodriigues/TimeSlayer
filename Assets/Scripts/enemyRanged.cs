using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemyRanged : MonoBehaviour {

	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed=100;
	public float bulletTimer;

	public bool awake = false;
	public bool lookingright = true;

	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootPointLeft;
	public Transform shootPointRight;

	public void Attack(bool attackingRight){
		bulletTimer += Time.deltaTime;
		if (bulletTimer >= shootInterval) {
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();
			if (!attackingRight) {
				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
				bulletTimer = 0;
			}
			if (attackingRight) {
				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
				bulletTimer = 0;
			}
		}	
	}
}

