using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tiles;

    public bool create=false;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    void generate()
    {
        var bc2d = gameObject.GetComponent<BoxCollider2D>();
        var pos = gameObject.transform.position;
        for (int y = 0; y < bc2d.size.y; y += 1)
        {
            for (int x = 0; x < bc2d.size.x; x += 1)
            {
                GameObject tile = Instantiate(tiles[0]);
                tile.transform.position=new Vector3(pos.x+x-bc2d.size.x/2,pos.y+y-bc2d.size.y/2,0);
                tile.transform.SetParent(gameObject.transform);
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (create)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            generate();
            create = false;
        }
        
        
    }
}
