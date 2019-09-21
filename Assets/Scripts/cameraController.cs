using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    [Range(0f,10f)] public float camera_speed;
    public GameObject target;

    void Start() {
        
    }

    void Update() {

        //Smoothly follows a target gamemobject
        Vector3 target_pos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target_pos, camera_speed * Time.deltaTime);
    }
}
