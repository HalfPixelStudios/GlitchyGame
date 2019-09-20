using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class dungeonGenerator : MonoBehaviour
{
    public GameObject room;
    public int num;
    private List<GameObject> rooms=new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            //Vector2 point = Random.insideUnitCircle;
            Vector2 size = Random.insideUnitCircle;
            
            
            
            
            GameObject r=Instantiate(room);
            r.GetComponent<BoxCollider2D>().size = new Vector2(Random.value*10,Random.value*10);
            r.GetComponent<Transform>().position=new Vector3(size.x*2,size.y*2,0);
            
            rooms.Add(r);
            
            
            
        }

        





    }

    // Update is called once per frame
    void Update()
    {
        bool done = true;
        foreach(GameObject room in rooms)
        {
            Rigidbody2D body = room.GetComponent<Rigidbody2D>();

            if (!body.IsSleeping())
            {
                done = false;

            }
            

        }

        if (done)
        {
            
        }
        
    }
}
