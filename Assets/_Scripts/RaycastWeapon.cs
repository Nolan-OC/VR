using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    [Header("ParticleHitEffects")]
    [SerializeField] ParticleSystem hitMetal;
    [SerializeField] ParticleSystem hitFlesh;
    [SerializeField] ParticleSystem hitDirt;
    [SerializeField] ParticleSystem hitWood;
    [SerializeField] ParticleSystem hitBone;

    public void Raycast()
    {
        // Define the raycast origin and direction
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        // Define the maximum distance for the raycast
        float maxDistance = 10f;

        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistance))
        {
            // A hit was detected
            Debug.Log("hit a " + hit.collider.transform.name);

            if (hit.collider.TryGetComponent(out Shootable hitShootable))
            {
                hitShootable.Shot(10f, transform);
                Debug.Log(DetermineHitEffects(hitShootable).ToString());
            }
        }
        else
        {
            Debug.Log("no hit detected");
        }
    }
    private ParticleSystem DetermineHitEffects(Shootable shootable)
    {
        //returns an int to be used in particle system array
        if (shootable.madeOf == Shootable.MadeOf.metal)
        {
            return hitMetal;
        }
        else if (shootable.madeOf == Shootable.MadeOf.flesh)
        {
            return hitFlesh;
        }
        else if (shootable.madeOf == Shootable.MadeOf.dirt)
        {
            return hitDirt;
        }
        else if (shootable.madeOf == Shootable.MadeOf.wood)
        {
            return hitWood;
        }

        return hitMetal;
    }
}
