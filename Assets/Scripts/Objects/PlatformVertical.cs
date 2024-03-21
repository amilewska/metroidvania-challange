using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformVertical : MonoBehaviour
{
    float distance = 2;
    public LayerMask platformLayer;

    private void Awake()
    {
        
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Down.performed += Down;
        
    }

    IEnumerator ActivateThroughPlatform()
    {
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        
    }


    public void Down(InputAction.CallbackContext context)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distance, platformLayer);
        if (context.performed && hit2D)
        {
            Debug.Log("down pressed)");
            StartCoroutine(ActivateThroughPlatform());
        }
        

    }
    
}
