using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetForce : MonoBehaviour {

    [Range(0f, 30f)] public float magnet_strength;
    [Range(0f, 5f)] public float pickup_radius;

    void Start() {
        gameObject.GetComponent<CircleCollider2D>().radius = pickup_radius;
    }

    void Update() {
        transform.position = transform.parent.position;
    }

    private void OnTriggerStay2D(Collider2D other) { //while coin object is within range, make it gravitate towards player
        if (other.gameObject.GetComponent<Coin>() != null) {
            Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
            Vector3 other_pos = other.gameObject.transform.position;
            Vector3 this_pos = gameObject.transform.position;
            float move_direct = (float)(Math.Atan2(other_pos.y-this_pos.y,other_pos.x-this_pos.x)+Math.PI);

            body.AddForce(new Vector2((float)(magnet_strength*Math.Cos(move_direct)), (float)(magnet_strength*Math.Sin(move_direct))));
        }
        
    }

}
