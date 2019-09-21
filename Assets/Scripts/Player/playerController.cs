using System;
using UnityEngine;

public class playerController : MonoBehaviour {

    private static float INPUT_THRESHHOLD = 0.5f; //this is only really important if we add controller support

    [Range(0f, 10f)] //Move this to player stat componenet later
    public float move_speed;

    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] private bool isMoving;
    private float facing;
    public float mouse_angle;


    void Start() {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {

        //find mouse rotation
        Vector2 mouse_pos = Input.mousePosition;
        mouse_angle = (float)Math.Atan2(mouse_pos.y - Screen.height / 2, mouse_pos.x - Screen.width / 2);

        isMoving = false;
        body.velocity = new Vector2(0, 0);

        //get user input
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        //Check to see if there is actually input
        if (Math.Abs(input_x) > INPUT_THRESHHOLD || Math.Abs(input_y) > INPUT_THRESHHOLD) {
            body.velocity = new Vector2(input_x * move_speed, input_y * move_speed);
            isMoving = true;
        }

        //tell the animator to flip player depending on position of mouse
        facing = mouse_pos.x < Screen.width / 2 ? -1 : 1;
        
        //update anim
        anim.SetFloat("Facing", facing);
        anim.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown("q")) {
            Debug.Log("pressed q");
            GameObject weapon = GetComponent<playerInventory>().equiped_weapon;
            weapon.GetComponent<weaponController>().shootProjectile(mouse_angle);

        }
    }
}
