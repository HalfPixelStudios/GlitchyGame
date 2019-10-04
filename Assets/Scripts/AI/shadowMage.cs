using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class shadowMage : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy eComp;
    private float timer;
    void Start()
    {
        timer = 0;
        eComp = GetComponent<Enemy>();


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!eComp.detected&&timer>=3)
        {
            GetComponent<Transform>().position=new Vector3(Random.Range(0,7),Random.Range(0,7),0);
            timer = 0;
        }
        else
        {
            //shoot weapon
            
        }
        
        
    }
}
