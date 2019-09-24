using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy e;
    void Start()
    {
        e = gameObject.GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        if (e.attack)
        {
            
        }
        else if (e.detected)
        {
            var pos = gameObject.transform.position;
            pos.Set(pos.x+1,pos.y,pos.z);
        }
        
        
    }
}
