using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

    [Range(0f,200f)] public float melee_damage; //damage dealt when weapon hits entity

    public string weapon_type; //unused for now
    public GameObject projectile;

    public GameObject owner;

    [Header("Graphics")]
    [Range(-3f, 3f)] public float orbit_radius;
    [Range(-1f,1f)] public float follow_offset_x;
    [Range(-1f, 1f)] public float follow_offset_y;
    [Range(0f, 360f)] public float angle_offset; //in degrees

    void Start() {
        //owner
        //this is giving error for some reason
        //Physics.IgnoreCollision(owner.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        orbit_radius = 0.8f;
    }

    void Update() {

        if (owner == null) { return; } //dont do anything is no one owns the weapon

        float mouse_angle = owner.GetComponent<playerController>().mouse_angle; //change this to be more generic so it works with enemies too

        //roatate  weapon depending on where mouse is
        transform.rotation = Quaternion.Euler((float)(transform.rotation.x*180/Math.PI), (float)(transform.rotation.y*180/Math.PI), (float)(mouse_angle*180/Math.PI+angle_offset));

        //weapon 'orbits' owner
        float new_x = (float)(owner.transform.position.x + orbit_radius*Math.Cos(mouse_angle) + follow_offset_x);
        float new_y = (float)(owner.transform.position.y + orbit_radius*Math.Sin(mouse_angle) + follow_offset_y);
        transform.position = new Vector3(new_x, new_y, owner.transform.position.z);

        //transform.RotateAround(owner_pos, transform.forward, 2f);
        //Debug.Log(mouse_angle);

    }

    public void shootProjectile(float angle) { //create a new projectile object
        projectileController p = Instantiate(projectile, transform.position, transform.rotation).GetComponent<projectileController>();
        p.angle = angle; //set the angle the bullet travels at
    }

    void OnCollisionEnter2D(Collision2D other) { //if the weapon hits an object

        healthComponent hp_comp = other.gameObject.GetComponent<healthComponent>();
        if (hp_comp != null) { //if the object the projectile hit has a health bar
            hp_comp.modHp(-1 * melee_damage);
        }
    }
}
