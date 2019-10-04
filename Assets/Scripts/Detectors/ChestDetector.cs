using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDetector : MonoBehaviour {

    [Range(0f, 5f)] public float radius;

    void Start() {
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

    void Update() { }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown("e")) { //open chest button
            gameObject.GetComponent<TreasureChest>().openChest();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
    }
}
