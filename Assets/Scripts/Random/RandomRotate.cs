using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = System.Random;

public class RandomRotate : MonoBehaviour
{
    public float delta=0;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        
        
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(0.2f);
        
        delta += Time.deltaTime;
        if (delta > 5)
        {
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            gameObject.GetComponent<Rigidbody2D>().rotation = 0;
            delta = 0;
            Destroy(this);

        }



    }

}