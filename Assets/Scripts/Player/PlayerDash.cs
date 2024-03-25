using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    private AbilityProgressBar abilityProgressBar;
    private Rigidbody2D rb;

    [SerializeField] private InputActionReference dash;

    [Header("Dashing Values")]
    [SerializeField] private float dashVelocity;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float activeTime;
    [SerializeField] private bool canDash = true;
    private Vector2 actualDierection;

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
        movement.isDashing = true;
        float originalGravity = rb.gravityScale;

        rb.gravityScale = 0;
        rb.velocity = new Vector2(actualDierection.x*movement.moveSpeed * dashVelocity, 0);
        transform.localScale /= 2;

        yield return new WaitForSeconds(activeTime);

        rb.gravityScale = originalGravity;
        transform.localScale *= 2;

        movement.isDashing = false;
        yield return new WaitForSeconds(cooldownTime);
        canDash = true;
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash /*&& abilityProgressBar.slider.value>0*/)
        {
            Debug.Log("you are dashing");

            PlayerMovement movement = GetComponent<PlayerMovement>();
            actualDierection = movement._moveDirection;


            StartCoroutine(ActivateDash());

            abilityProgressBar.AddProgress(-1);
            
        }

    }
   
}
