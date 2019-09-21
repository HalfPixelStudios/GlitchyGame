using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

    public GameObject projectile;

    public GameObject owner;
    public float orbit_radius;
    [Range(-1f,1f)] public float follow_offset_x;
    [Range(-1f, 1f)] public float follow_offset_y;

    void Start() {
        orbit_radius = 0.8f;
    }

    void Update() {

        if (owner == null) { return; } //dont do anything is no one owns the weapon

        float mouse_angle = owner.GetComponent<playerController>().mouse_angle;

        //roatate  weapon depending on where mouse is
        transform.rotation = Quaternion.Euler((float)(transform.rotation.x * 180 / Math.PI), (float)(transform.rotation.y * 180 / Math.PI), (float)(mouse_angle * 180 / Math.PI));

        //weapon 'orbits' owner
        float new_x = (float)(owner.transform.position.x + orbit_radius*Math.Cos(mouse_angle) + follow_offset_x);
        float new_y = (float)(owner.transform.position.y + orbit_radius*Math.Sin(mouse_angle) + follow_offset_y);
        transform.position = new Vector3(new_x, new_y, owner.transform.position.z);

        //transform.RotateAround(owner_pos, transform.forward, 2f);
        //Debug.Log(mouse_angle);

    }

    public void shootProjectile(float angle) { //create a new projectile object
        projectileController p = Instantiate(projectile, transform.position, transform.rotation).GetComponent<projectileController>();
        p.angle = angle;
    }
}
