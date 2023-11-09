using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    PoolManager<Bullet> bulletPool => PoolManager<Bullet>.instance;

    private Rigidbody2D rb;
    Camera mainCam;
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    private void Update()
    {
        var currentScreenPos = mainCam.WorldToScreenPoint(transform.position);

        if (currentScreenPos.x > Screen.width || currentScreenPos.x < 0f ||
            currentScreenPos.y > Screen.height || currentScreenPos.y < 0f)
        {
            bulletPool.Despawn(this);
        }
        
    }

    public void Shoot(Vector3 direction)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Obstacle obstacles))
        {
            bulletPool.Despawn(this);
            obstacles.SplitOrDestroy();
        }
    }
}