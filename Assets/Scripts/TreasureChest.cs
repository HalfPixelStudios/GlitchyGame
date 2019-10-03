using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

    //public bool isOpen = false;
    private Animator anim;

    void Start() {
        anim = gameObject.GetComponent<Animator>();
        anim.SetInteger("State", -1);
    }

    void Update() {
        
    } 

    public void openChest() {
        anim.SetInteger("State", 0);
    }


}
