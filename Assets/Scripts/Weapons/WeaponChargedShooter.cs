using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChargedShooter : MonoBehaviour {

    private weaponController weapon_control;
    //[Range(0f,5f)] public float charge_state_1;
    //[Range(0f,5f)] public float charge_state_2;
    //[Range(0f, 5f)] public float charge_state_3;
    [Range(-1f, 1f)] public float offset_y = 0.5f;

    [Range(0f, 5f)] public float max_charge;
    [SerializeField] private float current_charge = 0;
    private GameObject charge_indicator;

    void Start() {
        weapon_control = gameObject.GetComponent<weaponController>();
    }

    void Update() {

        //while the attack key is held down
        if (Input.GetKey("q")) {
            current_charge += Time.deltaTime;
        }

        //shoot projectile
        if (Input.GetKeyUp("q")) {

            if (current_charge > max_charge) {
                weapon_control.shootProjectile();
            }
            /*
            if (current_charge < charge_state_1) { //uncharged

                
            } else if (current_charge < charge_state_2) { //charge power 1

            } else if (current_charge < charge_state_3) { //charge power 2

            } else if (current_charge >= charge_state_3) { //max charge
                weapon_control.shootProjectile();
            }
            */
            current_charge = 0;

            //Once projectile is show we can delete the indicator
            if (charge_indicator != null) {
                Destroy(charge_indicator);
                charge_indicator = null;
            }

        }

        //visuals
        if (charge_indicator == null & current_charge > 0) {
            charge_indicator = Instantiate(Resources.Load("UI/charge_indicator"), gameObject.transform.position, Quaternion.identity) as GameObject;
            //charge_indicator.transform.parent = transform;
        }
        if (charge_indicator != null) { //sync position
            Vector3 owner_pos = gameObject.GetComponent<weaponController>().owner.transform.position;
            charge_indicator.transform.position = new Vector3(owner_pos.x,owner_pos.y+offset_y,owner_pos.z);
        }


        /*
        if (current_charge < charge_state_1) { //uncharged

        } else if (current_charge < charge_state_2) { //charge power 1

        } else if (current_charge < charge_state_3) { //charge power 2

        } else if (current_charge >= charge_state_3) { //max charge

        }
        */



    }
}
