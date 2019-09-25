using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlitchValue : MonoBehaviour
{
    public float glitchValue = 0;
    public List<Type> effects;
    //glitches
    //random gravity
    void Start()
    {
        effects.Add(typeof(RandomGravity));
        
    }
    void Update()
    {
        if (Random.Range(1, 10000) <= glitchValue)
        {
            gameObject.AddComponent(effects[Random.Range(0, effects.Count - 1)]);
        }
        
    }

    public void Damage()
    {
        glitchValue += 1;

    }
}
