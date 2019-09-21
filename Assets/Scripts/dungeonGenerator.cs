using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonGenerator : MonoBehaviour
{
    public Transform room;
    private int num;
    private List<Rect> rooms=new List<Rect>();
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            Vector2 point = Random.insideUnitCircle;
            Vector2 size = Random.insideUnitCircle;
            point.Scale(new Vector2(10,10));
            size.Scale(new Vector2(20,20));
            
            
            rooms.Add(new Rect(point,size));
        }

        //Instantiate(room.);





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
