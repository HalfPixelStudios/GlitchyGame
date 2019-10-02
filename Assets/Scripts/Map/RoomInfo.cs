using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperTiled2Unity;

public class RoomInfo : MonoBehaviour {

    public bool isCleared = true;
    [SerializeField] public List<GameObject> entrances = new List<GameObject>();
    [SerializeField] public List<GameObject> exits = new List<GameObject>();

    void Awake() {
        createRoomWarpZones();
    }

    void Update() {
        
    }

    public void createRoomWarpZones() { //creates roomExit and roomEntrance objects 
        GameObject room_zones = transform.Find("Grid").gameObject.transform.Find("ROOM_ZONES").gameObject; //Get list of all collision objects in map

        foreach (Transform child in room_zones.transform) { //get all zone objects
            CustomProperty property;
            child.GetComponent<SuperCustomProperties>().TryGetCustomProperty("zone_type", out property); //get custom property obejct
            GameObject child_ob = child.gameObject;

            if (Equals(property.m_Value, "entrance")) {
                child_ob.GetComponent<BoxCollider2D>().isTrigger = true;
                child_ob.layer = LayerMask.NameToLayer("Zone");

                entrances.Add(child_ob);
                //Debug.Log(entrances.Count, gameObject);

            } else if (Equals(property.m_Value, "exit")) {
                RoomExit room_exit = child_ob.AddComponent<RoomExit>();
                room_exit.cur_room = gameObject;
                child_ob.GetComponent<BoxCollider2D>().isTrigger = true;
                child_ob.layer = LayerMask.NameToLayer("Zone");

                exits.Add(child_ob);

            }

        }

    }

    public Vector3 getRandomEntrance() {
        GameObject selected_entrance = entrances[Random.Range(0, entrances.Count)];
        Vector3 offset = selected_entrance.GetComponent<BoxCollider2D>().offset;
        Vector3 pos = selected_entrance.transform.position;
        return new Vector3(offset.x + pos.x, offset.y + pos.y, offset.z + pos.z);
    }
}
