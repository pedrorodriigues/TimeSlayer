using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    private Vector2 velocity;
    public float delayX;
    public float delayY;

    public Transform pl;

    // Update is called once per frame
    void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, pl.transform.position.x, ref velocity.x, delayX);
        float posY = Mathf.SmoothDamp(transform.position.y, pl.transform.position.y, ref velocity.y, delayY);

        transform.position = new Vector3(posX, posY+1.5f, transform.position.z);

    }
}
