using UnityEngine;

[RequireComponent(
   typeof(PlayerInputs), 
   typeof(PlayerMovement), 
   typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerShooter))]
public class PlayerController : MonoBehaviour
{
   private PlayerInputs playerInputs;
   private PlayerMovement playerMovement;
   private PositionResetter positionResetter;
   private PlayerShooter playerShooter;
   private Rigidbody2D rb;

   private Vector2 moveVector;
   
   private bool restrictControls;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      // rigidbody settings 
      rb.drag = 1.5f;
      rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
      rb.freezeRotation = true;
      
      playerInputs = GetComponent<PlayerInputs>();
      playerMovement = GetComponent<PlayerMovement>();
      positionResetter = GetComponent<PositionResetter>();
      playerShooter = GetComponent<PlayerShooter>();
   }

   private void Update()
   {
      if(restrictControls) return;
      
      playerInputs.HandleInputs(out moveVector);
      playerMovement.HandleRotation(rb, moveVector);
      positionResetter.ResetPositionOutOfBounds();

      if (playerInputs.isShootKeyPressed)
      {
         playerShooter.HandleShooting();
      }
   }

   private void FixedUpdate()
   {
      playerMovement.HandleMovement(rb, moveVector);
   }

   public void ResetPlayer()
   {
      rb.velocity = Vector2.zero;
      transform.position = Vector3.zero;
      transform.eulerAngles = new Vector3(0f, 0f, 90f);
   }

   public void RestrictControls(bool enable)
   {
      restrictControls = enable;
   }
}