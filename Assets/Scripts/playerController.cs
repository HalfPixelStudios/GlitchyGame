using System;
using UnityEngine;

public class playerController : MonoBehaviour {

    private static float INPUT_THRESHHOLD = 0.5f; //this is only really important if we add controller support

    [Range(0f, 10f)] //Move this to player stat componenet later
    public float move_speed;

    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] private bool isMoving;

    void Start() {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {

        isMoving = false;
        body.velocity = new Vector2(0, 0);

        //Check to see if there is actually input
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        if (Math.Abs(input_x) > INPUT_THRESHHOLD || Math.Abs(input_y) > INPUT_THRESHHOLD) {
            body.velocity = new Vector2(input_x * move_speed, input_y * move_speed);
            isMoving = true;
        }

    }
}
