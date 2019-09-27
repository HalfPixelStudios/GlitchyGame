using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Gravity : Effect
{
    public void apply(GameObject obj)
    {
        obj.AddComponent<RandomGravity>();
    }
}
