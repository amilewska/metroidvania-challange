using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 _moveDirection;

    public InputActionReference move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }
   
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(_moveDirection.x*moveSpeed, rb.velocity.y);
        rb.velocity = new Vector2(_moveDirection.x*moveSpeed, _moveDirection.y * moveSpeed);
    }

}
