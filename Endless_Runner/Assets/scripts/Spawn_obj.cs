using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_obj : MonoBehaviour
{
    public float spawnTime;
    private float spawnDelay = 5;
    public GameObject spawnObject;
    [Space]
    [Header("Pickups")]
    [SerializeField] GameObject[] pickUpObjects;
    [Tooltip("set probability of each pickup spawning to the total of the previous probabilities + the new obstacle's probability of spawning")] [SerializeField] float[] spawnProbability;

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
        /*Instantiate(spawnObject, this.transform.position, transform.rotation);*/
        int seededRandom = Random.Range(1, 101);
        
        for (int i = 0; i < pickUpObjects.Length; i++)
        {
            // in inspector, set probability of each pickup spawning to the total of the previous probabilities + the new obstacle's probability of spawning
            if (seededRandom > 100-spawnProbability[i])
            {
                Instantiate(pickUpObjects[i], transform.position, transform.rotation);
                spawnDelay = RandomizeDelay(spawnDelay);
                return;
            }
        }


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
