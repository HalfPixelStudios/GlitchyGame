using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {



    void Start() {
        createNewRoom();
    }

    void Update() {
        
    }

    private void createNewRoom() {
        //from https://answers.unity.com/questions/1268079/how-to-get-file-names-in-directory.html
        string file_path = "Assets/Resources/Rooms/";
        DirectoryInfo dir = new DirectoryInfo(file_path);
        FileInfo[] info = dir.GetFiles("*.prefab"); //list of dungeon frames

        //pick a random dungeon frame
        string room_path = info[Random.Range(0, info.Length)].Name.Replace(".prefab","");
        //DONT INIT AS transform.position, transform.rotation!!!!!!
        GameObject room = Instantiate(Resources.Load("Rooms/"+room_path) as GameObject, transform.position, transform.rotation);

        //Each room that we load comes with children that are the room contents, we turn off all but one of the children to choose between them

    }
}
