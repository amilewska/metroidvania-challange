using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    public float dashVelocity = 5;
    public Rigidbody2D rb;

    public InputActionReference dash;

    public float cooldownTime = 1f;
    public float activeTime =0.5f;
    public bool canDash = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Dash.performed += Dash;
    }

    IEnumerator ActivateDash()
    {
        canDash = false;
        PlayerMovement movement = GetComponent<PlayerMovement>();
        movement.moveSpeed *= dashVelocity;
        yield return new WaitForSeconds(activeTime);
        movement.moveSpeed /= dashVelocity;
        yield return new WaitForSeconds(cooldownTime);
        canDash = true;
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed &&canDash)
        {
            Debug.Log("you are dashing");
            StartCoroutine(ActivateDash());
            //rb.velocity = new Vector2(rb.velocity.x* dashVelocity, rb.velocity.y);
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }
   
}
