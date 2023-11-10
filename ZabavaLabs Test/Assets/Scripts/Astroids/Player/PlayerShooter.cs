using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
   
    private PoolManager<Bullet> bulletPool => PoolManager<Bullet>.instance;
    private AudioManager audioManager => AudioManager.instance;
    
    public void HandleShooting()
    {
        bulletPool.SpawnFromPool(PoolType.Bullet, shootPoint.position, Quaternion.identity)
            .Shoot(shootPoint.right);
        
        audioManager.Play(SoundType.Shoot);
    }

}