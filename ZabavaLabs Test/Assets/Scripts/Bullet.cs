using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
   
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector3 direction)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    
    
}