using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMirror :MonoBehaviour
{
    public float delta;
    private Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        delta = 0;

    }

    // Update is called once per frame
    void Update()
    {
        body.velocity=new Vector2(-body.velocity.x,-body.velocity.y);
        
        delta += Time.deltaTime;
        if (delta > 3)
        {

            Destroy(this);
        }

    }
    

    
}
