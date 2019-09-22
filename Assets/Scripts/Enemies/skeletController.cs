using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletController : MonoBehaviour {

    public static System.Random rand = new System.Random();

    [Range(0f, 10f)] public float speed;

    private Animator anim;
    private Rigidbody2D body;
    private bool isMoving = false; //start off in idle state

    void Start() {
        
    }

    void Update() {
        
    }
}
