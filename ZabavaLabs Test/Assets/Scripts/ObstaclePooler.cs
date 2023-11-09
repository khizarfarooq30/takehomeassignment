using UnityEngine;

public class ObstaclePooler : PoolManager<Obstacle>
{
    [SerializeField] private float spawnTimer = 5f;
    
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = spawnTimer;
            
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            SpawnFromPool("Obstacle", spawnPos, Quaternion.identity);
        }
    }
}