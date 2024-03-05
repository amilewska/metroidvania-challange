using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce;

    private Vector2 _moveDirection;

    public InputActionReference move;  
    public InputActionReference jump;  
    

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveDirection.x*moveSpeed, _moveDirection.y*moveSpeed);
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
