using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_BasicMove : MonoBehaviour
{
    public Transform[] positions;
    Transform nextPos;
    int nextPosIndex;
    public float speed = 4;
    Rigidbody2D rb;

    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        nextPos = positions[0];
    }

    public void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if (transform.position.x == nextPos.position.x)
        {
            nextPosIndex++;
            if (nextPosIndex >= positions.Length)
            {
                nextPosIndex = 0;
            }
            nextPos = positions[nextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed*Time.fixedDeltaTime);
        }
    }




}
