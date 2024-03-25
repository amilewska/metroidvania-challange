using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    [SerializeField] private InputActionReference move;
    [SerializeField] private GameObject sprites;

    [Header("Movement values")]
    [SerializeField] public float moveSpeed; //cooperate with playerdash
    [SerializeField] private float moveSpeedWeb;
    [SerializeField] public Vector2 _moveDirection; //cooperate with playerdash
    [SerializeField] private Transform groundCheck;

    [Header("Booleans")]
    [SerializeField] private bool isClimbing;
    [SerializeField] public bool isDashing; //cooperate with playerdash
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool isWallWalking;


    [Header("Layer masks")]
    [SerializeField] private LayerMask Ground;
    [SerializeField] private LayerMask WallLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        _moveDirection = move.action.ReadValue<Vector2>();
        SurfaceAligment();
        WallWalk();
        Flip();
    }
   
    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }

        
        
        if (isClimbing)
        {
            
            rb.velocity = new Vector2(_moveDirection.x * moveSpeedWeb, _moveDirection.y * moveSpeedWeb);
        }
        else
        {
            
            rb.velocity = new Vector2(_moveDirection.x * moveSpeed , rb.velocity.y);
            
            //Vector2 moveDirection = new Vector2(_moveDirection.x, _moveDirection.y);
            //rb.AddForce(moveDirection*moveSpeed);
            //rb.AddForce(new Vector2(_moveDirection.x * moveSpeed, rb.velocity.y));
            
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
        if (isFacingRight && _moveDirection.x > 0f || !isFacingRight && _moveDirection.x < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = sprites.transform.localScale;
            localScale.x *= -1f;
            sprites.transform.localScale = localScale;
        }
    }

    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 2f, Ground);
    }

    private void WallWalk()
    {
        if (Physics2D.Raycast(transform.position,Vector2.left,2,WallLayer))
        {
            //it is for left wall
            Debug.Log("wall walk");
            isWallWalking = true;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(-9.8f, -_moveDirection.x * moveSpeed);

        }

        else if (Physics2D.Raycast(transform.position, Vector2.right,2,WallLayer))
        {
            //it is for right wall
            Debug.Log("wall walk");
            isWallWalking = true;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(9.8f, _moveDirection.x * moveSpeed);

        }

        else
        {
            isWallWalking = false; 
            rb.gravityScale = 3;
        }
    }
}
