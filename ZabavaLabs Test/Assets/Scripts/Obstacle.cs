using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private PositionResetter positionResetter;
    
    [SerializeField] private float obstacleDespawVal = 0.4f;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float minSpeed = 0.6f;
    [SerializeField] private float maxSpeed = 2f;
    
    private ObstaclePooler obstaclePooler;
  
    private Vector3 directionToMove;

    private void Awake()
    {
        obstaclePooler = FindObjectOfType<ObstaclePooler>(true);
    }


    private void Start()
    {
        float randomVal = Random.Range(-1f, 1f);
        directionToMove =  new Vector2(randomVal, randomVal).normalized;
        
       
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime *directionToMove;
        positionResetter.ResetPositionOutOfBounds();
    }

    public void SplitOrDestroy()
    {
        if (transform.localScale.x > obstacleDespawVal)
        {
            Split();
        }
        else
        {
            float randomScale = Random.Range(1.25f, 2.5f);
            transform.localScale = Vector3.one * randomScale;
            obstaclePooler.Remove(this);
            obstaclePooler.Despawn(this);
        } 
    }

    private void Split()
    {
        Vector3 scale = transform.localScale;
        scale /= 2f;
        
        transform.localScale = scale;
        
       Obstacle obstacle = 
           obstaclePooler.SpawnFromPool(PoolType.Obstacle, transform.position + 
                                                               Vector3.right * 0.5f, Quaternion.identity);

       obstacle.transform.localScale = scale;
       
       float randomVal = Random.Range(-1f, 1f);
       directionToMove =  new Vector2(randomVal, randomVal).normalized;


       float speedRand = Random.Range(minSpeed, maxSpeed);
       obstacle.speed = speedRand;
    }
}

