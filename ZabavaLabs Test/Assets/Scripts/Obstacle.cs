using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float obstacleDespawVal = 0.4f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private PositionResetter positionResetter;

    [SerializeField] private float minSpeed = 0.6f;
    [SerializeField] private float maxSpeed = 2f;
    
    private PoolManager<Obstacle> obstaclePooler => PoolManager<Obstacle>.instance;
   
    private Transform playerTransform;
    
    private Vector3 directionToMove;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        var dir = playerTransform.position - transform.position;
        dir.Normalize();
        directionToMove = dir;

        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * directionToMove;
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
            // reset obstacles scale to random value between 1.25 to 2.5f
            float randomScale = Random.Range(1.25f, 2.5f);
            transform.localScale = Vector3.one * randomScale;
            obstaclePooler.Despawn(this);
        } 
    }

    private void Split()
    {
        Vector3 scale = transform.localScale;
        scale /= 2f;
        
        transform.localScale = scale;
        
       Obstacle obstacle = 
           obstaclePooler.SpawnFromPool("Obstacle", transform.position + 
                                                     Vector3.right * 0.5f, Quaternion.identity);
       obstacle.transform.localScale = transform.localScale;
       obstacle.directionToMove = -directionToMove;
    }
}

