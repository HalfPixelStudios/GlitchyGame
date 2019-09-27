using UnityEngine;

public class RotateEffect:Effect
{
    public override void Apply(GameObject obj)
    {
        obj.AddComponent<RandomRotate>();
    }
}