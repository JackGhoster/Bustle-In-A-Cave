using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    //defines variations in spawn positions(will be a randomized value) that will be added to the bounds of the spawner boxes
    protected float xSpawnVariation;
    protected float ySpawnVariation;

    //randomized time to spawn
    protected float minSpawnTime;
    protected float maxSpawnTime;
    protected float spawnTime;

    //measurments of the spawner
    protected float spawnerMinX;
    protected float spawnerMaxX;
    protected float spawnerMinY;
    protected float spawnerMaxY;

    //the values for these bounds are set in the respective spawner classes
    protected float xSpawnBound;
    protected float ySpawnBound;
    protected Vector3 spawnBoundsVector;


    protected Vector3 spawnerSizeVector;
    protected Vector3 spawnerCenterVector;




    public virtual void Awake()
    {
        //the new unit will be spawned between this two values of time in seconds
        minSpawnTime = 2;
        maxSpawnTime = 5;


        //getting the measurments of the spawner
        spawnerSizeVector = this.GetComponent<SpriteRenderer>().bounds.size;
        spawnerCenterVector = this.GetComponent<SpriteRenderer>().bounds.center;

        spawnerMinX = this.GetComponent<SpriteRenderer>().bounds.min.x;
        spawnerMaxX = this.GetComponent<SpriteRenderer>().bounds.max.x;
        spawnerMinY = this.GetComponent<SpriteRenderer>().bounds.min.y;
        spawnerMaxY = this.GetComponent<SpriteRenderer>().bounds.max.y;
    }

    public virtual void Spawn()
    {
        //setting a random time
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        spawnBoundsVector = new Vector3(xSpawnBound + xSpawnVariation, ySpawnBound + ySpawnVariation, 0);
        //the spawn itself!
        Instantiate(objectToSpawn, spawnBoundsVector, Quaternion.identity);
        //the delay for the next spawn 
        StartCoroutine(WaitForNextSpawn()); 
    }

    IEnumerator WaitForNextSpawn()
    {
        yield return new WaitForSeconds(spawnTime);
        Spawn();   
    }
}
