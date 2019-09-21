using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    [Range(0f, 10f)] public float speed;
    [Range(0f, 10f)] public float range;

    public Rigidbody2D body;
    public float angle;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2((float)(speed*Math.Cos(angle)), (float)(speed*Math.Sin(angle)));
    }

    void Update() {
    }

    
    
}
