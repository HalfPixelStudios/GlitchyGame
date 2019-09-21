using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    [Range(0f, 10f)] public float speed;
    [Range(0f, 10f)] public float range;

    public Rigidbody2D body;
    public float angle;

    private Vector2 start_position;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2((float)(speed*Math.Cos(angle)), (float)(speed*Math.Sin(angle)));
        start_position = transform.position;
    }

    void Update() {

        //check to see if projectile exceeded its max range
        float x = transform.position.x - start_position.x;
        float y = transform.position.y - start_position.y;
        float dist_travelled = (float)(Math.Pow(Math.Pow(x,2f)+Math.Pow(y,2f),0.5f));

        if (dist_travelled > range) {
            //DESTROYYYYY
            Destroy(this.gameObject);
        }
    }

    
    
}
