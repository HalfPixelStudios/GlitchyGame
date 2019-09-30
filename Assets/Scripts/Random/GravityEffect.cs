using UnityEngine;

public class GravityEffect:Effect
{
    public override void Apply(GameObject obj)
    {
        obj.AddComponent<RandomGravity>();
    }
}
