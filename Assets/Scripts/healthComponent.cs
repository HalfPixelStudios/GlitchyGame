using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthComponent : MonoBehaviour {

    [Range(0f, 200f)] public float baseHealth;
    public float currentHealth;

    void Start() {
        currentHealth = baseHealth;
    }

    void Update() {
        
    }

    public void modHp(float deltaHp) {
        currentHealth += deltaHp;
        if (currentHealth <= 0) {
            Debug.Log("DEAD",gameObject);
            Destroy(this.gameObject); //THIS IS VERY BAD, especially for players, fix later
        } else if (currentHealth > baseHealth) { currentHealth = baseHealth; } //cant go over max hp
    }

}
