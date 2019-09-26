using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [Range(0, 10)] public int value;

    void Start() { }

    void Update() {

    }

    private void OnTriggerStay2D(Collider2D other) {

        if (Equals(other.gameObject.name, "player_knight_0")) {
            Destroy(this.gameObject);
        }

    }
}
