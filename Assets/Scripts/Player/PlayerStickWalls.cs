using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickWalls : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    public float gravityMultiplier;
    public float maxspeed;

    public Vector2[] directions;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        foreach (Vector2 v in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, v, 4);

            if (hit.collider != null)
            {
                AddForce(v);
            }

            Debug.DrawRay(this.transform.position, v*200, Color.red);
        }
    }

    private void AddForce(Vector2 direction)
    {
        if (m_Rigidbody2D.velocity.magnitude > maxspeed)
            return;
        if (direction == directions[0])
        {
            m_Rigidbody2D.AddForce(Vector2.right * gravityMultiplier);
        }
        else if (direction == directions[1])
        {
            m_Rigidbody2D.AddForce(Vector2.up * gravityMultiplier);
        }
        else if (direction == directions[2])
        {
            m_Rigidbody2D.AddForce(Vector2.left * gravityMultiplier);
        }
        else if (direction == directions[3])
        {
            m_Rigidbody2D.AddForce(Vector2.down * gravityMultiplier);
        }
        else if (direction == directions[4])
        {
            m_Rigidbody2D.AddForce(Vector2.left * gravityMultiplier);
            m_Rigidbody2D.AddForce(Vector2.up * gravityMultiplier);
        }
        else if (direction == directions[5])
        {
            m_Rigidbody2D.AddForce(Vector2.right * gravityMultiplier);
            m_Rigidbody2D.AddForce(Vector2.down * gravityMultiplier);
        }
        else if (direction == directions[6])
        {
            m_Rigidbody2D.AddForce(Vector2.right * gravityMultiplier);
            m_Rigidbody2D.AddForce(Vector2.up * gravityMultiplier);
        }
        else if (direction == directions[7])
        {
            m_Rigidbody2D.AddForce(Vector2.left * gravityMultiplier);
            m_Rigidbody2D.AddForce(Vector2.down * gravityMultiplier);
        }
        Debug.Log(direction);
    }

    private void OnDrawGizmos()
    {
        foreach (Vector2 v in directions)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, new Vector2(v.x * 1.5f + transform.position.x, v.y * 1.5f + transform.position.y));
        }
    }
}
