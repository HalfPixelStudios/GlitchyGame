using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

    //public bool isOpen = false;
    private Animator anim;
    private GameObject chest_detector;
    public GameObject[] loot_table;

    void Start() {
        anim = gameObject.GetComponent<Animator>();
        anim.SetInteger("State", -1); //set animation as closed

        chest_detector = Instantiate(Resources.Load("Detectors/chest_detector"), transform.position, Quaternion.identity) as GameObject;
        chest_detector.transform.parent = transform;
    }

    void Update() {
        
    } 

    public void openChest() {
        anim.SetInteger("State", 0);
        Destroy(chest_detector);

        //Drop a random item from the loot table
        GameObject new_weapon = loot_table[Random.Range(0, loot_table.Length)];

        Instantiate(new_weapon, transform.position, Quaternion.identity);
    }


}
