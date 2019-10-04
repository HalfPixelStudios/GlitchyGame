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
                int dir;
                if (Mathf.Sign(dx) == 1)
                {
                    dir = Random.Range(-3, 15);
                    
                    
                }
                else
                {
                    dir = Random.Range(-14, 4);
                }
                gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(Mathf.Sign(dir)*statComp.move_speed,0);
                
            }
            else
            {
                int dir;
                if (Mathf.Sign(dy) == 1)
                {
                    dir = Random.Range(-3, 15);
                    
                    
                }
                else
                {
                    dir = Random.Range(-14, 4);
                }
                gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,Mathf.Sign(dir)*statComp.move_speed);
                
            }
            
        }
        
    }
}
