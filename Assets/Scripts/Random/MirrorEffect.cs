using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class MirrorEffect:Effect
{
    public override void Apply(GameObject obj)
    {
        obj.AddComponent<RandomMirror>();
    }
}

