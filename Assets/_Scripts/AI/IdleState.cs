using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;

    [Header("Detection")]
    public LayerMask detectionLayer;
    public bool canSeeEnemy;
    public float detectionRadius = 5f;

    //defines upper and lower bounds of FOV for ai
    public float detectionAngle = 50;

    public override State RunCurrentState()
    {
        HandleDetection();
        if(canSeeEnemy)
        {

            return chaseState;
        }
        else 
        { 
            return this; 
        }
    }
    public void HandleDetection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);


        for(int i = 0; i < colliders.Length; i++)
        {
            CharacterStats stats = colliders[i].GetComponent<CharacterStats>();
            if(stats == null) { continue; }

            Vector3 targetDirection = stats.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if(viewableAngle > -detectionAngle/2 && viewableAngle < detectionAngle/2)
            {
                //TODO not all npc's will go to chase state need to reword this
                GetComponent<ChaseState>().target = stats.transform;
                canSeeEnemy = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //this shows the detection angle
        // Convert the angles to radians
        float RayDistance = detectionRadius;

        // Calculate the directions of the rays
        Vector3 maxRayDirection = Quaternion.Euler(0f, detectionAngle/2, 0f) * transform.forward;
        Vector3 minRayDirection = Quaternion.Euler(0f, -detectionAngle/2, 0f) * transform.forward;

        // Draw the gizmos
        Gizmos.color = Color.red;
        //left and right angle
        Gizmos.DrawRay(transform.position, maxRayDirection * RayDistance);
        Gizmos.DrawRay(transform.position, minRayDirection * RayDistance);
        //forward 
        Gizmos.DrawRay(transform.position, transform.forward * RayDistance);
    }
}
