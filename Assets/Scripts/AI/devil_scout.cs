using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devil_scout : MonoBehaviour
{
    private Enemy enemyComp;
    void Start()
    {
        enemyComp = gameObject.GetComponent<Enemy>();


    }
    void Update()
    {
        if (enemyComp.detected)
        {
            float dx = enemyComp.player.transform.position.x - gameObject.transform.position.x;
            float dy = enemyComp.player.transform.position.y - gameObject.transform.position.y;
            if (dx > dy)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2();
            }
            
        }
        
    }
}
