using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour { //THIS SCRIPT NEEDS SOME CLEANING UP SOMETIME

    Dictionary<string, float> input_dict = new Dictionary<string, float>() {
        {"posit_x", 0}, {"nega_x", 0}, {"posit_y", 0}, {"nega_y", 0}, //movement input
        {"attack_key", 0}
    };

    //this is also pretty bad i think
    Dictionary<string, string> key_bindings = new Dictionary<string, string>() {
        {"posit_x", "d"}, {"nega_x", "a"}, {"posit_y", "w"}, {"nega_y", "s"}, //movement input
        {"attack_key", "q"}
    };

    void Start() { }

    void Update() {
        
    }
}
