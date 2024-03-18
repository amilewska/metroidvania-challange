using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInteraction : MonoBehaviour
{
    Animator animator;
    AbilityProgressBar abilityProgressBar;
    public InputActionReference interact;
    bool isClosed;

    void Start()
    {
        animator = GetComponent<Animator>();
        abilityProgressBar = GameObject.Find("AbilityBar").GetComponent<AbilityProgressBar>();


    }

    private void Awake()
    {
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact;
    }

    private bool IsNear()
    {
        return Physics2D.OverlapCircle(transform.position, 1f);
        
    }
    public void Interact(InputAction.CallbackContext context)
    {

        if (context.performed && IsNear() && !abilityProgressBar.IsMax() && !isClosed)
        {
            animator.SetBool("IsNear", true);
            abilityProgressBar.AddProgress(1);
            isClosed = true;
        }

        if (context.performed && IsNear() && abilityProgressBar.IsMax())
        {
            Debug.Log("You are too emotional to interact with");
        }

        if (context.performed && IsNear() && isClosed)
        {
            Debug.Log("You cannot interact with it anymore");
        }
        



    }
}
