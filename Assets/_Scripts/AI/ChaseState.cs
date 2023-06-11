using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    StateManager stateManager;
    EnemyAnimationManager enemyAnimationManager;
    public AttackState attackState;
    public bool inAttackRange;

    public NavMeshAgent navAgent;
    public Transform target;
    public float distanceFromTarget;
    public float stoppingDistance = 0.5f;

    public float rotationSpeed = 15f;
    private void Start()
    {
        StateManager stateManager = transform.parent.GetComponent<StateManager>();
        enemyAnimationManager = transform.parent.GetComponent<EnemyAnimationManager>();
    }
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

    public void HandleMoveToTarget()
    {
        Vector3 targetDirection = target.position - transform.position;
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        //if performing action stop movement
        if (stateManager.isPerformingAction)
        {
            enemyAnimationManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            navAgent.enabled = false;
        }
        else
        {
            if(distanceFromTarget > stoppingDistance)
            {
                enemyAnimationManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            }
        }

        HandleRotateToTarget();
        navAgent.transform.localPosition = Vector3.zero;
        navAgent.transform.localRotation = Quaternion.identity;
    }
    private void HandleRotateToTarget()
    {
        //rotate manually
        if(stateManager.isPerformingAction)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero){ direction = transform.forward;}

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
        //rotate with navmesh
        else
        {
            //Vector3 relativeDirection = transform.InverseTransformDirection(navAgent.desiredVelocity);
            //Vector3 targetVelocity = rigidbody.velocity;
            navAgent.enabled = true;
            navAgent.SetDestination(target.position);
            //rigidbody.velocity = targetVelocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, navAgent.transform.rotation, rotationSpeed/Time.deltaTime);
        }

        
    }
}
