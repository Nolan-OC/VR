using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool inAttackRange;
    public LayerMask enemyLayer;
    public override State RunCurrentState()
    {
        if(inAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == enemyLayer)
        {
            Debug.Log("Collided with " + other.gameObject.name);
        }
    }
}
