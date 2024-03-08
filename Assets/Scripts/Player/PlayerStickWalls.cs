using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStickWalls : MonoBehaviour
{
    Vector2 forceDirection = Vector2.down;
    float range=200;
    float gravityMultiplier;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2[] directions = new Vector2[4];
        directions[0] = Vector2.down;
        directions[1] = Vector2.right;
        directions[2] = Vector2.up;
        directions[3] = Vector2.left;

        foreach (Vector2 v in directions)
        {
            if (Physics2D.Raycast(transform.position, v, range))
                forceDirection = v;
        }

        rb.AddForce(forceDirection * gravityMultiplier);
    }
    
}
