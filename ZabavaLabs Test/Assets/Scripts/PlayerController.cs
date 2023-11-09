using System;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

[RequireComponent(typeof(PlayerInputs), typeof(PlayerMovement), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
   private PlayerInputs playerInputs;
   private PlayerMovement playerMovement;
   private Rigidbody2D rb;

   private Vector2 moveVector;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      // rigidbody settings 
      rb.drag = 1.5f;
      rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
      rb.freezeRotation = true;
      
      playerInputs = GetComponent<PlayerInputs>();
      playerMovement = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
      playerInputs.HandleInputs(out moveVector);
      playerMovement.HandleRotation();
   }

   private void FixedUpdate()
   {
      playerMovement.HandleMovement(rb, moveVector);
   }
}