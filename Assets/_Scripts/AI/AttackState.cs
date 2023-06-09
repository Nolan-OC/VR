using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override State RunCurrentState()
    {
        Debug.Log(transform.name + " is attacking enemy!");

        // if in range return this, if not in range retrun chase
        return this;
    }
}
