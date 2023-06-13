using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObj : MonoBehaviour
{
    public Health health;

    public string bodyPart;
    public float damageModifier;

    public void TakeDamage(float damage, float force, string type)
    {
        Debug.Log(transform.name + " was hit for \ndamage:" + damage + " force:" + force + " type:" + type);
        Debug.Log(bodyPart + " was hit " + damageModifier + "x modifier");

        float calculatedDamage = damage;
        if(health != null)
        {
            health.takeDamage(calculatedDamage, this.transform);
        }
    }
}
