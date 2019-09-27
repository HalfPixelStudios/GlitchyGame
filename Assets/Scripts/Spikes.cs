using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Animator _animator;
    public bool activated;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();


    }
    void Update()
    {
        _animator.SetBool("activated",activated);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(activated);
        if (activated)
        {
            
            Stats s=other.gameObject.GetComponent<Stats>();
            s.modHp(-10);
        }
        
    }

    
}
