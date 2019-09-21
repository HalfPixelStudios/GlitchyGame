using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class dungeonGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int num;
    private List<GameObject> rooms=new List<GameObject>();
    private List<GameObject> mainRooms = new List<GameObject>();
    private bool simDone = false;
    private float mean=0;
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            
            Vector2 position = Random.insideUnitCircle;
            
            
            
            
            
            GameObject r=Instantiate(roomPrefab);
            BoxCollider2D bc2d = r.GetComponent<BoxCollider2D>();
            bc2d.size=new Vector2(Random.Range(3,10),Random.Range(3,10));
            r.GetComponent<Transform>().position=new Vector3(position.x,position.y,0);
            mean += bc2d.size.x * bc2d.size.y;
            
            r.transform.SetParent(gameObject.transform);
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
                if (bc2d.size.x * bc2d.size.y > mean*1.25 )
                {
                    
                    
                    mainRooms.Add(room);
                    //rooms.Remove(room);
                }
                else
                {
                    //rooms.Remove(room);
                    //Destroy(room);

                }

                
                
            }
            //instead of this preconstruction of graph, Delaunay would be used
            
            HashSet<GameObject> mst=new HashSet<GameObject>();
            Dictionary<GameObject,float> weights=new Dictionary<GameObject, float>();
            Dictionary<GameObject,GameObject> parents=new Dictionary<GameObject, GameObject>();
            mst.Add(rooms[0]);
            foreach (var rm in mainRooms)
            {
                weights.Add(rm,Single.MaxValue);
                
            }

            while (mst.Count!=mainRooms.Count)
            {
                foreach (var obj in weights.Keys)
                {
                    foreach (var node in mst)
                    {
                        float dist = obj.GetComponent<BoxCollider2D>().Distance(node.GetComponent<BoxCollider2D>())
                            .distance;
                        if (dist < weights[obj])
                        {
                            weights[obj] = dist;
                            parents[obj] = node;
                        }
                    }
                    
                }
                float min=Single.MaxValue;
                GameObject minNode=null;
                foreach (var i in weights)
                {
                    if (i.Value < min)
                    {
                        min = i.Value;
                        minNode = i.Key;

                    }
                }
                weights.Remove(minNode);
                mst.Add(minNode);




            }
            Debug.Log(parents);
            
            
            
            


        }

    }

    void NaiveDelaunay()
    {
        
    }

    
}
