using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInteraction : MonoBehaviour
{
    Animation anim;
    Animator animator;
    public InputActionReference interact;
    void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
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

        if (context.performed && IsNear())
        {
            animator.SetBool("IsNear", true);
            //anim.Play();
        }



    }
}
