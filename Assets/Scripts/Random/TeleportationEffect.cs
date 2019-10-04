using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeleportationEffect:Effect
{
    public override void Apply(GameObject obj)
    {
        obj.transform.position=new Vector3(Random.Range(-7,7),Random.Range(-7,7),0);
    }
}
