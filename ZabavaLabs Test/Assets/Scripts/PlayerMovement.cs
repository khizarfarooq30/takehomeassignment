using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    public void HandleMovement(Rigidbody2D rb, Vector2 moveVector)
    {
        rb.AddForce(moveVector * speed, ForceMode2D.Force);
    }

    public void HandleRotation()
    {
        Vector3 dir = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    
}