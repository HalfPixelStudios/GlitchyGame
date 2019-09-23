using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupDetector : MonoBehaviour {

    [Range(0f, 5f)] public float pickup_radius;

    void Start() {
        gameObject.GetComponent<CircleCollider2D>().radius = pickup_radius;
    }

    void Update() { }


    private void OnCollisionStay2D(Collision2D other) {
        //show hovering arrow
    }

    private void OnCollisionExit2D(Collision2D other) {
        //kill hovering arrow
    }

}
