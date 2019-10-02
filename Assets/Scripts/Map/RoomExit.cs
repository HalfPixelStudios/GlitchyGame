using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using SuperTiled2Unity;

//[ExecuteInEditMode]
public class RoomExit : MonoBehaviour {

    public GameObject cur_room;

    void Start() {

    }

    void Update() {
        
    }

    //TODO: sort rooms by difficulty or theme, and also (possibly) make sure that a room cannot be used twice
    private GameObject createNewRoom() {
        //from https://answers.unity.com/questions/1268079/how-to-get-file-names-in-directory.html
        string file_path = "Assets/Resources/Rooms/";
        DirectoryInfo dir = new DirectoryInfo(file_path);
        FileInfo[] info = dir.GetFiles("*.prefab"); //list of dungeon frames

        //pick a random dungeon frame
        string room_path = info[Random.Range(0, info.Length)].Name.Replace(".prefab","");
        //DONT INIT AS transform.position, transformu.rotation!!!!!!
        GameObject room = Instantiate(Resources.Load("Rooms/"+room_path) as GameObject, new Vector3(-16,16,0), transform.rotation);
        room.AddComponent<RoomInfo>();
        return room;
    }

    private void OnTriggerEnter2D(Collider2D other) { //teleport player to a new room 
        RoomInfo room_info = cur_room.GetComponent<RoomInfo>();

        if (!room_info.isCleared) { return; } //dont do anything if the room hasnt been cleared yet

        //Destroy current map
        Destroy(cur_room); //destroy roomExit object

        //Create the new room
        GameObject new_room = createNewRoom();

        //Teleport player to a random room entrance
        other.gameObject.isStatic = true;
        other.gameObject.transform.position = new_room.GetComponent<RoomInfo>().getRandomEntrance();
        other.gameObject.isStatic = false;

    }

}
