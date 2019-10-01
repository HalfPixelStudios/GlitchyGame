using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using SuperTiled2Unity;

//[ExecuteInEditMode]
public class RoomExit : MonoBehaviour {

    private GameObject room; //the room that the room exit will generate
    [SerializeField] private List<GameObject> entrances = new List<GameObject>();
    [SerializeField] private List<GameObject> exits = new List<GameObject>();

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
        //Create the new room
        createNewRoom();
        createRoomWarpZones();

        //Teleport player to a random room entrance
        GameObject selected_entrance = exits[Random.Range(0, entrances.Count)];
        print(other.gameObject.name);
        other.gameObject.transform.position = selected_entrance.transform.position;

        
        //Then delete all the entrances
        foreach (GameObject ent in entrances) { Destroy(ent); }
        entrances.Clear();

        //Destroy current map
        Destroy(gameObject); //destroy roomExit object
    }

    private void createRoomWarpZones() { //creates roomExit and roomEntrance objects 
        GameObject room_zones = room.transform.Find("Grid").gameObject.transform.Find("ROOM_ZONES").gameObject; //Get list of all collision objects in map
        
        foreach (Transform child in room_zones.transform) { //get all zone objects
            CustomProperty property;
            child.GetComponent<SuperCustomProperties>().TryGetCustomProperty("zone_type", out property); //get custom property obejct
            GameObject child_ob = child.gameObject;

            if (Equals(property.m_Value,"entrance")) {
                child_ob.GetComponent<BoxCollider2D>().isTrigger = true;

                entrances.Add(child_ob);

            } else if (Equals(property.m_Value, "exit")) {
                child_ob.AddComponent<RoomExit>();
                child_ob.GetComponent<BoxCollider2D>().isTrigger = true;


                exits.Add(child_ob);

            }
            
        }
        
    }
}
