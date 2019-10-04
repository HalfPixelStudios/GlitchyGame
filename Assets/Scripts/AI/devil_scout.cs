using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devil_scout : MonoBehaviour
{
    private Enemy enemyComp;
    private Stats statComp;
    void Start()
    {
        enemyComp = gameObject.GetComponent<Enemy>();
        statComp = GetComponent<Stats>();


    }
    void Update()
    {
        if (enemyComp.detected)
        {
            float dx = enemyComp.player.transform.position.x - gameObject.transform.position.x;
            float dy = enemyComp.player.transform.position.y - gameObject.transform.position.y;
            if (Mathf.Abs(dx) > Mathf.Abs(dy))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(Mathf.Sign(dx)*statComp.move_speed,0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,Mathf.Sign(dy)*statComp.move_speed);
                
            }
            
        }
        
    }
}
