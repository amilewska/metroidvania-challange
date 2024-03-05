using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        
        movement.moveSpeed *= dashVelocity; 
    }

    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        movement.moveSpeed /= dashVelocity;
    }
}
