using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : ObjectPool<Asteroid>
{
    [SerializeField]
    List<Asteroid> potentialPrefabs;

    protected override Asteroid CreateObject()
    {

        var newObject = Instantiate(potentialPrefabs.Random(), transform);
        newObject.gameObject.SetActive(false);
        newObject.Pool = this;
        pool.Add(newObject);
        return newObject;
    }
}
