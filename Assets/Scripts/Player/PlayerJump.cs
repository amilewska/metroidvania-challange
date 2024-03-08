using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;

    public InputActionReference jump;

    public Transform groundCheck;
    public LayerMask groundLayer;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 2f, groundLayer);
    }

   
    public void Jump(InputAction.CallbackContext context)
    {
        
        if (context.performed && IsGrounded())
         {
             Debug.Log("Can jump");
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
             //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         }

         /*if (rb.velocity.y > 0f)
         {
             Debug.Log("Cannot jump - in the air");
             rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
         }*/


    }
}

