using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    [SerializeField]
    BulletTrailPool trailPool;

    protected override Bullet CreateObject()
    {
        var obj = base.CreateObject();
        obj.TrailPool = trailPool;
        return obj;
    }
}
