using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    private AbilityProgressBar abilityProgressBar;

    public float dashVelocity = 5;
    public Rigidbody2D rb;

    public InputActionReference dash;

    public float cooldownTime = 1f;
    public float activeTime =0.5f;
    public bool canDash = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        abilityProgressBar = GameObject.Find("AbilityBar").GetComponent<AbilityProgressBar>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Dash.performed += Dash;
    }

    IEnumerator ActivateDash()
    {
        canDash = false;
        PlayerMovement movement = GetComponent<PlayerMovement>();

        
        float originalGravity = movement.rb.gravityScale;
        rb.gravityScale = 0;

        movement.moveSpeed *= dashVelocity;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        transform.localScale /= 2;

        yield return new WaitForSeconds(activeTime);

        rb.gravityScale = originalGravity;
        transform.localScale *= 2;
        movement.moveSpeed /= dashVelocity;
        yield return new WaitForSeconds(cooldownTime);
        canDash = true;
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash /*&& abilityProgressBar.slider.value>0*/)
        {
            Debug.Log("you are dashing");
            StartCoroutine(ActivateDash());

            

            abilityProgressBar.AddProgress(-1);


        }

    }
   
}
