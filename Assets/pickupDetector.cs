using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupDetector : MonoBehaviour {

    [Range(0f, 5f)] public float pickup_radius;
    [Range(-1f, 1f)] public float offset_x;
    [Range(-1f, 1f)] public float offset_y;
    private GameObject arrow;

    void Start() {
        gameObject.GetComponent<CircleCollider2D>().radius = pickup_radius;
    }

    void Update() { }

    private void OnTriggerEnter2D (Collider2D other) {
        //show hovering arrow
        //Debug.Log(Resources.Load("dropped_item_arrow") as GameObject);
        arrow = Instantiate(Resources.Load("UI/dropped_item_arrow") as GameObject, transform.position, transform.rotation);
    }

    private void OnTriggerExit2D(Collider2D other) {
        //kill hovering arrow
        Destroy(arrow);
    }

}
