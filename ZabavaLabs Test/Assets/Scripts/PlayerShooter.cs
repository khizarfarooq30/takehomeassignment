using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
   
    PoolManager<Bullet> bulletPool => PoolManager<Bullet>.instance;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        bulletPool.SpawnFromPool(
                "Bullet",
                shootPoint.position, 
                Quaternion.identity)
                .Shoot(shootPoint.right);
    }
}