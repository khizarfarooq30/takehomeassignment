using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private float offset = 5f;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void ResetPositionOutOfBounds()
    {
        // When go out of screen, warp to the other side
        Vector3 pos = transform.position;
        Vector3 playerPosInScreenSpace = mainCam.WorldToScreenPoint(pos);
        
        if (playerPosInScreenSpace.y + offset > Screen.height)
        {
            pos.y = -pos.y + 0.5f;

        }
        else if (playerPosInScreenSpace.y - offset < 0f)
        {
            pos.y = Mathf.Abs(pos.y) - 0.5f;
        }

        if(playerPosInScreenSpace.x + offset > Screen.width)
        {
            pos.x = -pos.x + 0.5f;
        }
        else if (playerPosInScreenSpace.x - offset < 0f)
        {
            pos.x = Mathf.Abs(pos.x) - 0.5f;
        }

        transform.position = pos;
    }
}