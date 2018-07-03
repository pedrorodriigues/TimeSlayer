using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	// Use this for initialization
	private Vector3 initialPosition;
	public SpriteRenderer enemyRenderer;
	private int direction;
	public float movingSpeed = 0;
	public Transform colisor;
	public Transform boundCheck;
	public LayerMask whatIsBound; 
	public bool bounded;

	void Start()
    {
        initialPosition = transform.position;
        direction = -1;
    }
    
	void OnTriggerEnter2D(Collider2D other)
    {
        // se detectar colisão com o hero detrói a moeda
        if (other.gameObject.CompareTag("Finish"))
        {
			direction = direction * -1;
        }
		if(other.gameObject.CompareTag("Player")){
			movingSpeed = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
		bounded = Physics2D.OverlapCircle(boundCheck.position, 0.2f, whatIsBound);
        switch (direction)
        {
            case -1:
				// Moving Left
					GetComponent<Rigidbody2D>().velocity = new Vector2(-movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
				    enemyRenderer.flipX = false;

				if (bounded) {
					direction = 1;                  
				}                            
                break;
            case 1:
                //Moving Right
                    GetComponent<Rigidbody2D>().velocity = new Vector2( movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
				    enemyRenderer.flipX = true;                				
			    if (bounded){
                    direction = -1;                
                }
                break;

        }



    }
}

