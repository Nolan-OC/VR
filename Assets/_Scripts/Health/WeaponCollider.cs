using HurricaneVR.Framework.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public HVRGrabbableImpactHaptics haptics;
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the objects you want to damage
        if (collision.transform.TryGetComponent(out DamageableColliders damageable))
        {
            damageable.TakeDamage(10,haptics.Force, "cutting");
        }
    }
}
