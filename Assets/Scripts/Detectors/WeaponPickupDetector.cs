using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupDetector : MonoBehaviour {

    [Range(0f, 5f)] public float radius;
    [Range(-1f, 1f)] public float offset_x;
    [Range(-1f, 1f)] public float offset_y;
    private GameObject arrow;

    void Start() {
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

    void Update() { }

    private void OnTriggerEnter2D(Collider2D other) {
        //show hovering arrow once player becomes within range
        arrow = Instantiate(Resources.Load("UI/dropped_item_arrow") as GameObject, new Vector3(transform.position.x + offset_x, transform.position.y + offset_y, transform.position.z), Quaternion.identity);
        arrow.transform.parent = transform;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown("e")) { //pickup button

            weaponController old_weapon = other.gameObject.GetComponent<weaponSheath>().equiped_weapon.GetComponent<weaponController>();

            if (old_weapon != null) { //if the owner had a previous item, drop that item
                old_weapon.set_drop_mode();
            }

            gameObject.transform.parent.GetComponent<weaponController>().set_pickup_mode(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //kill hovering arrow once player is no longer within range
        Destroy(arrow);
    }

}