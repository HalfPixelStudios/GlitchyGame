using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour {

    public GameObject owner;
    [Range(-1f,1f)] public float follow_offset_x;
    [Range(-1f, 1f)] public float follow_offset_y;

    void Start() {
        
    }

    void Update() {

        //weapon is always on top of owner
        Vector3 owner_pos = new Vector3(owner.transform.position.x+follow_offset_x,owner.transform.position.y+follow_offset_y,owner.transform.position.z);
        transform.position = owner_pos;

        //rotate weapon to direction of mouse
        Vector2 mouse_pos = Input.mousePosition;
        float mouse_angle = (float) Math.Atan2(mouse_pos.y-Screen.height/2, mouse_pos.x-Screen.width/2);
        transform.rotation = Quaternion.Euler((float)(transform.rotation.x*180/Math.PI), (float)(transform.rotation.y*180/Math.PI), (float)(mouse_angle *180/Math.PI));

        //flip weapon if on left side
        if (mouse_pos.x < Screen.width / 2) {
            
        }
        //Debug.Log(mouse_angle);

    }
}
