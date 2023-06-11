using HurricaneVR.Framework.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableColliders : MonoBehaviour
{
    public Health health;
    public Collider[] hitBoxes;

    public string bodyPart;
    public float damageModifier;

    private void Start()
    {
        hitBoxes = GetComponentsInChildren<Collider>();
    }

    public void TakeDamage(float damage, float force, string type)
    {
        Debug.Log(transform.name + " was hit for \ndamage:" + damage + " force:" + force + " type:" + type);
        Debug.Log(bodyPart + " was hit " + damageModifier + "x modifier");

    }
}
