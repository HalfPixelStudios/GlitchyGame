using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//[ExecuteInEditMode]
public class RoomExit : MonoBehaviour {

    private GameObject room; //the room that the room exit will generate

    void Start() {

    }

    void Update() {
        
    }

    //TODO: sort rooms by difficulty or theme, and also (possibly) make sure that a room cannot be used twice
    private void createNewRoom() {
        //from https://answers.unity.com/questions/1268079/how-to-get-file-names-in-directory.html
        string file_path = "Assets/Resources/Rooms/";
        DirectoryInfo dir = new DirectoryInfo(file_path);
        FileInfo[] info = dir.GetFiles("*.prefab"); //list of dungeon frames

        //pick a random dungeon frame
        string room_path = info[Random.Range(0, info.Length)].Name.Replace(".prefab","");
        //DONT INIT AS transform.position, transform.rotation!!!!!!
        room = Instantiate(Resources.Load("Rooms/"+room_path) as GameObject, transform.position, transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D other) { //teleport player to a new room 
        createNewRoom();
        createRoomWarpZones();

        Destroy(gameObject);
    }

    private void createRoomWarpZones() { //creates roomExit and roomEntrance objects 
        GameObject room_zones = room.transform.Find("Grid").gameObject.transform.Find("ROOM_ZONES").gameObject;

        /*
        foreach (Transform child in room_zones.transform) { //get all zone objects
            string zone_type = child.GetComponent<SuperTiled2Unity.SuperCustomProperties>().GetType().GetField("zone_type");

            print(zone_type);
            if (Equals(zone_type,"entrance")) {
                Debug.Log("entrance");
            } else if (Equals(zone_type,"exit")) {
                Debug.Log("exit");
            }
        }
        */
    }
}
