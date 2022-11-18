using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthSpawner : AbstractSpawner
{
    public override void Awake()
    {       
        xSpawnBound = spawnerMinX;
        
        base.Awake();
    }

    void Start()
    {
        Spawn();
    }

    public override void Spawn()
    {
        ySpawnBound = spawnerMinY;
        xSpawnVariation = Random.Range(spawnerMinX, spawnerMaxX);
        ySpawnVariation = 0;       
        base.Spawn();
    }
}
