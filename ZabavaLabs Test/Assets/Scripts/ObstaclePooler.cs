using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : PoolManager<Obstacle>
{
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private int initialSpawnCount = 4;
    
    List<Obstacle> obstacles = new List<Obstacle>();
    
    private float timer;
    
    private void Start()
    {
        SpawnLevelObstacles();
    }

    private void SpawnLevelObstacles()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-12f, 12f), Random.Range(-5f, 5f), 0f);
            Obstacle obstacle = SpawnFromPool(PoolType.Obstacle, spawnPos, Quaternion.identity);
            obstacles.Add(obstacle);
        }
    }

    public void Remove(Obstacle obstacle)
    {
        obstacles.Remove(obstacle);
    }
}