using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed;
    public float moveSpeedWeb;
    public float rotationSpeed;
    bool isFacingRight;
    bool isWallWalking;

    private Vector2 _moveDirection;

    public InputActionReference move;
    public LayerMask Ground;
    public LayerMask WallLayer;

    public Transform groundCheck;

    bool isClimbing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        SurfaceAligment();
        WallWalk();
    }
   
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            
            rb.velocity = new Vector2(_moveDirection.x * moveSpeedWeb, _moveDirection.y * moveSpeedWeb);
        }
        else
        {
            //
            //rb.velocity = new Vector2(_moveDirection.x * moveSpeed, rb.velocity.y);
            
            //Vector2 moveDirection = new Vector2(_moveDirection.x, _moveDirection.y);
            //rb.AddForce(moveDirection*moveSpeed);
            rb.AddForce(new Vector2(_moveDirection.x * moveSpeed, rb.velocity.y));
            
        }
        
    }

    public void SurfaceAligment()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit info = new RaycastHit();
        Quaternion RotationRef = Quaternion.Euler(0,0,0);

        if(Physics.Raycast(ray, out info, Ground))
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, info.normal);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Web"))
        {
            isClimbing = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Web"))
        {
            isClimbing = true;
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Web"))
        {
            isClimbing = false ;
            rb.gravityScale = 3;
        }
    }

    private void Flip()
    {
        if (isFacingRight && _moveDirection.x < 0f || !isFacingRight && _moveDirection.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(transform.position, 2f, WallLayer);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 2f, Ground);
    }

    private void WallWalk()
    {
        if (IsWalled())
        {
            //it is for left wall
            Debug.Log("wall walk");
            isWallWalking = true;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, -_moveDirection.x * 10);

        }
        else
        {
            isWallWalking = false; 
            rb.gravityScale = 3;
        }
    }
}
