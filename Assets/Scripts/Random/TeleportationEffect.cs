using UnityEngine;
using Random = UnityEngine.Random;

public class TeleportationEffect:Effect
{
    public override void Apply(GameObject obj)
    {
        Debug.Log("teleport");
        obj.transform.position.Set(Random.Range(-7,7),Random.Range(-7,7),0);
    }
}
