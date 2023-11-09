using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float rotationSpeed = 5f;
    
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    public void HandleMovement(Rigidbody2D rb, Vector2 moveVector)
    {
        if(moveVector.y > 0f)
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
    }

    public void HandleRotation(Rigidbody2D rb, Vector2 moveVector)
    {
        // Vector3 dir = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.Rotate(-rotationSpeed * Time.deltaTime * moveVector.x * transform.forward);
    }

    
}