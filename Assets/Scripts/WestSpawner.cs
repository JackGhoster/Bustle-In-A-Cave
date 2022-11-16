using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestSpawner : AbstractSpawner
{
    public override void Awake()
    {
        ySpawnBound = spawnerMinY;

        base.Awake();
    }

    void Start()
    {
        Spawn();
    }

    public override void Spawn()
    {
        xSpawnBound = spawnerMinX;
        ySpawnVariation = Random.Range(spawnerMinY, spawnerMaxY);
        xSpawnVariation = 0;
        base.Spawn();
    }
}
