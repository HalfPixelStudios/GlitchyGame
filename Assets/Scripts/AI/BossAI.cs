using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Stats _stats;
    private Enemy _enemy;
    private float charging;
    
    void Start()
    {

        _stats=GetComponent<Stats>();
        _enemy = GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        if (charging > 0)
        {
            charging -= Time.deltaTime;
            if (charging < 0)
            {
                GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
            }
        }
        float percentage = 100*_stats.currentHealth / _stats.baseHealth;
        float dx = _enemy.player.transform.position.x - gameObject.transform.position.x;
        float dy = _enemy.player.transform.position.y - gameObject.transform.position.y;
        if (percentage < 20)
        {
            
        }else if (percentage < 40)
        {
            if (dx == 0)
            {
                charging = 8;

            }

            if (dy == 0)
            {
                
            }
            if (Mathf.Abs(dx) < Mathf.Abs(dy))
            {
                
                
                
            }
            
        }else if (percentage<80)
        {
            
            
            
        }
        else
        {
            
            
        }


    }
}
