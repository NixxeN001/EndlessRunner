using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_obj : MonoBehaviour
{
    public float spawnTime;
    private float spawnDelay = 5;
    public GameObject spawnObject;
    
    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            
            Spawn();
        }
    }
    private void Spawn()
    {

        spawnTime = Time.time + spawnDelay;
        Instantiate(spawnObject, this.transform.position, transform.rotation);
        spawnDelay = RandomizeDelay(spawnDelay);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= spawnTime;
    }

    private float RandomizeDelay(float timedelay)
    {
         timedelay = Random.Range(3f, 6f);

        return timedelay;
    }
}
