﻿using System;
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

    private GameObject pickup;
    private Rigidbody2D body;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        
        

        orbit_radius = 0.8f;

        if (owner != null) { set_pickup_mode(owner);
        } else { set_drop_mode(); }
    }

    void Update() {

        if (owner != null) {
            
            //ignores collision
            Physics.IgnoreCollision(owner.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            

            float mouse_angle = owner.GetComponent<playerController>().mouse_angle; //change this to be more generic so it works with enemies too

            //roatate  weapon depending on where mouse is
            transform.rotation = Quaternion.Euler((float)(transform.rotation.x * 180 / Math.PI), (float)(transform.rotation.y * 180 / Math.PI), (float)(mouse_angle * 180 / Math.PI + angle_offset));

            //weapon 'orbits' owner
            //HARDCODED ORBIT RAIDUS AS 1 FOR NOW
            float new_x = (float)(owner.transform.position.x + 1 * Math.Cos(mouse_angle) + follow_offset_x);
            float new_y = (float)(owner.transform.position.y + 1 * Math.Sin(mouse_angle) + follow_offset_y);
            transform.position = new Vector3(new_x, new_y, owner.transform.position.z);

            //transform.RotateAround(owner_pos, transform.forward, 2f);
            //Debug.Log(mouse_angle);

        } else { //if weapon does not have an owner, display it as a dropped item
            transform.Rotate(0, 4f, 0); //cheesy rotating effect
        }

    }

    public void shootProjectile(float angle) { //create a new projectile object
        projectileController p = Instantiate(projectile, transform.position, transform.rotation).GetComponent<projectileController>();
        p.angle = angle; //set the angle the bullet travels at
    }

    public void set_pickup_mode(GameObject new_owner) { //if the weapon is being used
        owner = new_owner;

        //set equipped item as this weapon
        new_owner.GetComponent<playerInventory>().equiped_weapon = this.gameObject;
        
        gameObject.layer = LayerMask.NameToLayer("Weapons");
        body.isKinematic = true;
        body.freezeRotation = false;

        Destroy(pickup);
    }

    public void set_drop_mode() { //if the weapon is no longer being used
        owner = null;

        gameObject.layer = LayerMask.NameToLayer("Dropped Items");
        body.isKinematic = false; //just make sure there is no force when the item is dropped
        body.freezeRotation = true;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);

        //create an object that detects if an entity is within the pickup range
        pickup = Instantiate(Resources.Load("Objects/pickup_detector") as GameObject, transform.position, transform.rotation);
        pickup.GetComponent<pickupDetector>().weapon = this.gameObject;
    }


    private void OnCollisionEnter2D(Collision2D other) { //if the weapon hits an object
        if (weapon_type != "range")
        {
            healthComponent hp_comp = other.gameObject.GetComponent<healthComponent>();
            if (hp_comp != null)
            {
                //if the object the projectile hit has a health bar
                hp_comp.modHp(-1 * melee_damage);
            }
        }
    }
}
