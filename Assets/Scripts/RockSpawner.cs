using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField]
    private float maxSpawnInterval = 2f;

    [SerializeField]
    private float minSpawnInterval = 0.5f;

    [SerializeField]
    private float spawnChance = 10;

    [SerializeField]
    private GameObject rockPrefab;

    [SerializeField]
    private Transform[] spawnPositions;

    private float spawnTimer = 0;

    public delegate void RockDelegate(Rock rock);
    public event RockDelegate OnRockSpawned;

    // Update is called once per frame
    void Update()
    {
        CheckSpawn();   
    }

    /// <summary>
    /// Checks if spawner should spawn a new rock.
    /// </summary>
    private void CheckSpawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= minSpawnInterval)
        {
            float randomChance = Random.Range(0, 100);
            if (randomChance <= spawnChance)
            {
                SpawnRock();
                return;
            }
            if (spawnTimer >= maxSpawnInterval)
            {
                SpawnRock();
                return;
            }
        }

    }

    /// <summary>
    /// Spawns a new rock
    /// </summary>
    private void SpawnRock()
    {
        spawnTimer = 0;
        GameObject rock = Instantiate(rockPrefab, spawnPositions[Random.Range(0, spawnPositions.Length - 1)].position, rockPrefab.transform.rotation) as GameObject;
        
        if(OnRockSpawned != null)
        {
            Rock rockComponent = rock.GetComponent<Rock>();
            OnRockSpawned(rockComponent);
        }
    }
}
