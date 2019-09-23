using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupDetector : MonoBehaviour {

    [Range(0f, 5f)] public float pickup_radius;
    public GameObject dropped_item_arrow;
    private GameObject arrow;

    void Start() {
        gameObject.GetComponent<CircleCollider2D>().radius = pickup_radius;
    }

    void Update() { }

    private void OnTriggerEnter2D (Collider2D other) {
        //show hovering arrow
        Debug.Log("Entered collision zone");
        arrow = Instantiate(dropped_item_arrow, transform.position, transform.rotation);
    }

    private void OnTriggerExit2D(Collider2D other) {
        //kill hovering arrow
        Destroy(arrow);
    }

}
