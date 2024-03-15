using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_BasicMove : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int wapointIndex;
    Vector2 target;
    float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    public void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target) < 0)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[wapointIndex].position;
        agent.destination = target;
        rb.position = Vector2.MoveTowards(transform.position, waypoints[wapointIndex].position, speed * Time.fixedDeltaTime);
    }

    void IterateWaypointIndex()
    {
        wapointIndex++;
        if(wapointIndex==waypoints.Length)
        {
            wapointIndex = 0;
        }
    }


}
