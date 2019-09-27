using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomGravity : MonoBehaviour
{
    private float delta;
    // Start is called before the first frame update
    void Start()
    {
        delta = 0;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1,5);

    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > 3)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            
            Destroy(this);
        }

    }
}
