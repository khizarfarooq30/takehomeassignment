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
        Vector3 worldToScreenPoint = mainCam.WorldToScreenPoint(pos);
        
        Debug.Log(worldToScreenPoint);
        
        if (worldToScreenPoint.y > Screen.height + offset)
        {
            pos.y = -pos.y + 0.25f;

        }
        else if (worldToScreenPoint.y < -offset)
        {
            pos.y = Mathf.Abs(pos.y) - 0.25f;
        }

        if(worldToScreenPoint.x > Screen.width  + offset)
        {
            pos.x = -pos.x + 0.25f;
        }
        else if (worldToScreenPoint.x <  -offset )
        {
            pos.x = Mathf.Abs(pos.x) - 0.25f;
        }

        transform.position = pos;
    }
}