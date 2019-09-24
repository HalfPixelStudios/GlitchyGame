using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthComponent : MonoBehaviour {

    [Range(0f, 200f)] public float baseHealth;
    public float currentHealth;

    ParticleSystem hit_particle; //move this somewhere else later

    void Start() {
        currentHealth = baseHealth;
        hit_particle = (Instantiate(Resources.Load("Particles/hit_particles"),transform.position,transform.rotation) as GameObject).GetComponent<ParticleSystem>();
        hit_particle.Stop();
    }

    void Update() {
        hit_particle.gameObject.transform.position = transform.position; //sync position of particle emitter with object
    }

    public void modHp(float deltaHp) {
        currentHealth += deltaHp;

        if (deltaHp < 0) { //if the entity is losing health, play damage particles
            hit_particle.Play();
        }

        if (currentHealth <= 0) {
            Debug.Log("DEAD",gameObject);
            //drop weapon if any
            weaponController old_weapon = gameObject.GetComponent<weaponSheath>().equiped_weapon.GetComponent<weaponController>();
            if (old_weapon != null) {
                old_weapon.set_drop_mode();
            }
            
            Destroy(this.gameObject); //THIS IS VERY BAD, especially for players, fix later
        } else if (currentHealth > baseHealth) { currentHealth = baseHealth; } //cant go over max hp
    }

}
