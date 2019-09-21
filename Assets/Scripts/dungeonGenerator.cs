using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class dungeonGenerator : MonoBehaviour
{
    public GameObject room;
    public int num;
    private List<GameObject> rooms=new List<GameObject>();
    private List<GameObject> mainRooms=new List<GameObject>();
    private Dictionary<GameObject, List<GameObject>> graph;
    private bool simDone = false;
    private float mean=0;
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            
            Vector2 position = Random.insideUnitCircle;
            
            
            
            
            
            GameObject r=Instantiate(room);
            BoxCollider2D bc2d = r.GetComponent<BoxCollider2D>();
            bc2d.size=new Vector2(Random.Range(3,10),Random.Range(3,10));
            r.GetComponent<Transform>().position=new Vector3(position.x,position.y,0);
            mean += bc2d.size.x * bc2d.size.y;
            
            rooms.Add(r);
            
            
            
        }

        //Instantiate(room.);
        mean /= num;

    }

    // Update is called once per frame
    void Update()
    {
        if (!simDone)
        {
            bool done = true;
            foreach (GameObject room in rooms)
            {
                Transform t = room.GetComponent<Transform>();
                Rigidbody2D body = room.GetComponent<Rigidbody2D>();

                if (!body.IsSleeping())
                {
                    done = false;

                }


            }

            if (done)
            {
                simDone = true;
            }
        }
        else 
        {
            foreach (GameObject room in rooms)
            {
                BoxCollider2D bc2d = room.GetComponent<BoxCollider2D>();
                Debug.Log(bc2d.size.x*bc2d.size.y);
                Debug.Log(mean*2);
                if (bc2d.size.x * bc2d.size.y > mean*1.25 )
                {
                    
                    
                    mainRooms.Add(room);
                }
                else
                {
                    Destroy(room);

                }
                
            }
            
        }

    }

    void NaiveDelaunay()
    {
        
    }

    
}
