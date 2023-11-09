using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public void HandleInputs(out Vector2 moveVector)
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
    }
}