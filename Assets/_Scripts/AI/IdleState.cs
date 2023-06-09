using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeeEnemy;

    public SphereCollider detectionCollider;
    public override State RunCurrentState()
    {
        if(canSeeEnemy)
        {
            return chaseState;
        }
        else 
        { 
            return this; 
        }
    }
}
