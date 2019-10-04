using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlitchValue : MonoBehaviour
{
    public float glitchValue = 0;
    public List<Effect> effects;

    private float delta;
    //glitches
    //random gravity
    void Start()
    {
        delta = 0;
        effects=new List<Effect>();
        effects.Add(new RotateEffect());
        effects.Add(new GravityEffect());
        effects.Add(new TeleportationEffect());
        effects.Add(new MirrorEffect());
        

    }
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > 2f)
        {
            if (Random.Range(1,100) <= glitchValue)
            {
                effects[Random.Range(0,effects.Count)].Apply(gameObject);
            }
            delta = 0;
        }

    }

    public void modGlitch(float delta)
    {
        
        glitchValue -= delta;

    }
}
