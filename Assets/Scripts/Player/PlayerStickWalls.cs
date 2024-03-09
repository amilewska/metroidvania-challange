using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerStickWalls : MonoBehaviour
{
    Vector2 forceDirection = Vector2.down;
    float range=200;
    float gravityMultiplier;
    Rigidbody2D rb;

    GravityDirection gravityDirection;
    enum GravityDirection
    {
        Down,
        Up,
        Left,
        Right

    }

    public  Transform start;
    public Transform end;
    float timeCount=0.0f;
    float speed=0.01f;

    private void Start()
    {
        start = transform;
        gravityDirection = GravityDirection.Down;
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        switch(gravityDirection)
        {

            case GravityDirection.Down:
                Physics2D.gravity = new Vector2(0, -9.8f);
                break;

            case GravityDirection.Up:
                Physics2D.gravity = new Vector2(0, 9.8f);
                break;

            case GravityDirection.Left:
                Physics2D.gravity = new Vector2(-9.8f, 0);
                break;

            case GravityDirection.Right:
                Physics2D.gravity = new Vector2(9.8f,0);
                break;

        }
    }
    private void Update()
    {
        
        if (Physics2D.Raycast(transform.position, Vector2.left))
        {
            rb.AddForce(new Vector2(-9.8f, 0));
            gameObject.transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;
        }

        /*Vector2[] directions = new Vector2[4];
        directions[0] = Vector2.down;
        directions[1] = Vector2.right;
        directions[2] = Vector2.up;
        directions[3] = Vector2.left;

        foreach (Vector2 v in directions)
        {
           //if (Physics2D.Raycast(transform.position, v, range))
                //forceDirection = v;
                //gravityDirection = GravityDirection.Left;
            //Debug.DrawRay(transform.position, v, color:UnityEngine.Color.red,range);
        }
        
        //rb.AddForce(forceDirection * gravityMultiplier);*/
    }
    
}
