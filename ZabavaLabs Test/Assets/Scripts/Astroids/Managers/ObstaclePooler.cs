using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : PoolManager<Obstacle>
{
    [SerializeField] private int initialSpawnCount = 4;
    
    List<Obstacle> obstacles = new List<Obstacle>();

    private Transform playerTransform;
    
    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        SpawnLevelObstacles();
    }

    public void SpawnLevelObstacles()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-12f, 12f), Random.Range(-5f, 5f), 0f);
            
            float distanceToPlayer = Vector3.Distance(spawnPos, playerTransform.position);
            
            if (distanceToPlayer < 2f)
            {
                spawnPos += new Vector3(5f, 5f, 0f);
            }
            
            Obstacle obstacle = SpawnFromPool(PoolType.Obstacle, spawnPos, Quaternion.identity);
            AddObstacles(obstacle);
        }
    }

    public void AddObstacles(Obstacle obstacle)
    {
        obstacles.Add(obstacle);
    }

    public void RemoveObstacles(Obstacle obstacle)
    {
        obstacles.Remove(obstacle);

        if (obstacles.Count == 0)
        {
            Debug.Log("Wave ended!");
        }
    }
}