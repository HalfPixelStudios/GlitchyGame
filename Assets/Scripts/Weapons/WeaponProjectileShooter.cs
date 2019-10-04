using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileShooter : MonoBehaviour {

    private weaponController weapon_control;

    void Start() {
        weapon_control = gameObject.GetComponent<weaponController>();
    }

    void Update() {
        //weapon stuff
        if (Input.GetKeyDown("q")) {
            weapon_control.shootProjectile();
        }
    }
}
