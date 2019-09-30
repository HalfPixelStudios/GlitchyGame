using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class mapGenerator : MonoBehaviour {

    void Start() {
        createNewRoom();
        //this.load_all();
    }

    void Update() {
        
    }

    /*
    private void load_all() {
        //from https://answers.unity.com/questions/1268079/how-to-get-file-names-in-directory.html
        string file_path = "Assets/Resources/Rooms/";
        DirectoryInfo dir = new DirectoryInfo(file_path);
        FileInfo[] info = dir.GetFiles("*.prefab"); //list of dungeon frames

        foreach (FileInfo f in info) {
            Debug.Log(f);
        }
    }
    */

        //TODO: sort rooms by difficulty or theme, and also (possibly) make sure that a room cannot be used twice
    private void createNewRoom() {
        //from https://answers.unity.com/questions/1268079/how-to-get-file-names-in-directory.html
        string file_path = "Assets/Resources/Rooms/";
        DirectoryInfo dir = new DirectoryInfo(file_path);
        FileInfo[] info = dir.GetFiles("*.prefab"); //list of dungeon frames

        //pick a random dungeon frame
        string room_path = info[Random.Range(0, info.Length)].Name.Replace(".prefab","");
        //DONT INIT AS transform.position, transform.rotation!!!!!!
        GameObject room = Instantiate(Resources.Load("Rooms/"+room_path) as GameObject, transform.position, transform.rotation);

    }
}
